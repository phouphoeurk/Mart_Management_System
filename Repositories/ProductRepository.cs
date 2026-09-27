using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetAll(
            string? keyword = null,
            int? categoryId = null,
            bool activeOnly = false
        )
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c
                    ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s
                    ON s.SupplierId = p.SupplierId
                WHERE (@keyword IS NULL
                       OR p.ProductName LIKE @keyword
                       OR p.Barcode LIKE @keyword)
                  AND (@categoryId IS NULL OR p.CategoryId = @categoryId)
                  AND (@activeOnly = 0 OR p.IsActive = 1)
                ORDER BY p.ProductName;
                """;

            List<Product> products = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@keyword", SqlDbType.NVarChar, 150).Value =
                string.IsNullOrWhiteSpace(keyword)
                    ? DBNull.Value
                    : $"%{keyword.Trim()}%";
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value =
                (object?)categoryId ?? DBNull.Value;
            command.Parameters.Add("@activeOnly", SqlDbType.Bit).Value = activeOnly;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(MapProduct(reader));
            }

            return products;
        }

        public Product? GetById(int productId)
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c
                    ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s
                    ON s.SupplierId = p.SupplierId
                WHERE p.ProductId = @productId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            return reader.Read() ? MapProduct(reader) : null;
        }

        public bool Create(
            Product product,
            int? inventoryUserId = null,
            string? inventoryNotes = null
        )
        {
            ArgumentNullException.ThrowIfNull(product);
            ValidateProduct(product);

            const string sql = """
                INSERT INTO dbo.Products
                    (ProductName, Barcode, CategoryId, SupplierId, CostPrice,
                     SellingPrice, StockQuantity, ReorderLevel, ExpiryDate,
                     IsActive, CreatedAt)
                OUTPUT INSERTED.ProductId
                VALUES
                    (@productName, @barcode, @categoryId, @supplierId, @costPrice,
                     @sellingPrice, @stockQuantity, @reorderLevel, @expiryDate,
                     @isActive, SYSUTCDATETIME());
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                using SqlCommand command = new(sql, connection, transaction);
                AddParameters(command, product);
                int productId = (int)command.ExecuteScalar();

                if (inventoryUserId.HasValue && product.StockQuantity != 0)
                {
                    InventoryRepository.InsertTransaction(
                        connection,
                        transaction,
                        productId,
                        inventoryUserId.Value,
                        InventoryTransactionType.Adjustment,
                        product.StockQuantity,
                        null,
                        null,
                        inventoryNotes ?? "Initial product stock"
                    );
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Update(
            Product product,
            int? inventoryUserId = null,
            string? inventoryNotes = null
        )
        {
            ArgumentNullException.ThrowIfNull(product);
            ValidateProduct(product);

            const string currentStockSql = """
                SELECT StockQuantity
                FROM dbo.Products WITH (UPDLOCK, ROWLOCK)
                WHERE ProductId = @productId;
                """;

            const string updateSql = """
                UPDATE dbo.Products
                SET ProductName = @productName,
                    Barcode = @barcode,
                    CategoryId = @categoryId,
                    SupplierId = @supplierId,
                    CostPrice = @costPrice,
                    SellingPrice = @sellingPrice,
                    StockQuantity = @stockQuantity,
                    ReorderLevel = @reorderLevel,
                    ExpiryDate = @expiryDate,
                    IsActive = @isActive
                WHERE ProductId = @productId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int currentStock = product.StockQuantity;
                if (inventoryUserId.HasValue)
                {
                    using SqlCommand currentStockCommand = new(
                        currentStockSql,
                        connection,
                        transaction
                    );
                    currentStockCommand.Parameters.Add(
                        "@productId",
                        SqlDbType.Int
                    ).Value = product.ProductId;
                    object? value = currentStockCommand.ExecuteScalar();
                    if (value is null)
                    {
                        throw new InvalidOperationException("Product not found.");
                    }

                    currentStock = Convert.ToInt32(value);
                }

                using (SqlCommand updateCommand = new(updateSql, connection, transaction))
                {
                    AddParameters(updateCommand, product);
                    updateCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                        product.ProductId;
                    if (updateCommand.ExecuteNonQuery() != 1)
                    {
                        throw new InvalidOperationException("Product not found.");
                    }
                }

                int stockDelta = product.StockQuantity - currentStock;
                if (inventoryUserId.HasValue && stockDelta != 0)
                {
                    InventoryRepository.InsertTransaction(
                        connection,
                        transaction,
                        product.ProductId,
                        inventoryUserId.Value,
                        InventoryTransactionType.Adjustment,
                        stockDelta,
                        null,
                        null,
                        inventoryNotes ?? "Product stock edited"
                    );
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool SetActive(int productId, bool isActive)
        {
            const string sql = """
                UPDATE dbo.Products
                SET IsActive = @isActive
                WHERE ProductId = @productId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = isActive;
            command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

            connection.Open();
            return command.ExecuteNonQuery() == 1;
        }

        private static void AddParameters(SqlCommand command, Product product)
        {
            command.Parameters.Add("@productName", SqlDbType.NVarChar, 150).Value =
                product.ProductName.Trim();
            command.Parameters.Add("@barcode", SqlDbType.NVarChar, 50).Value =
                (object?)product.Barcode ?? DBNull.Value;
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value =
                product.CategoryId;
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value =
                (object?)product.SupplierId ?? DBNull.Value;
            command.Parameters.Add("@costPrice", SqlDbType.Decimal).Value =
                product.CostPrice;
            command.Parameters.Add("@sellingPrice", SqlDbType.Decimal).Value =
                product.SellingPrice;
            command.Parameters.Add("@stockQuantity", SqlDbType.Int).Value =
                product.StockQuantity;
            command.Parameters.Add("@reorderLevel", SqlDbType.Int).Value =
                product.ReorderLevel;
            command.Parameters.Add("@expiryDate", SqlDbType.DateTime2).Value =
                (object?)product.ExpiryDate ?? DBNull.Value;
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = product.IsActive;
        }

        private static void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                throw new ArgumentException("Product name is required.");
            }

            if (product.ProductName.Trim().Length > 150)
            {
                throw new ArgumentException(
                    "Product name cannot exceed 150 characters."
                );
            }

            if (product.Barcode?.Length > 50)
            {
                throw new ArgumentException("Barcode cannot exceed 50 characters.");
            }

            if (product.CategoryId <= 0)
            {
                throw new ArgumentException("A category is required.");
            }

            if (product.CostPrice < 0 || product.SellingPrice < 0)
            {
                throw new ArgumentException("Prices cannot be negative.");
            }

            if (product.StockQuantity < 0 || product.ReorderLevel < 0)
            {
                throw new ArgumentException(
                    "Stock quantity and reorder level cannot be negative."
                );
            }
        }

        private static Product MapProduct(SqlDataReader reader)
        {
            return new Product
            {
                ProductId = reader.GetInt32(0),
                ProductName = reader.GetString(1),
                Barcode = reader.IsDBNull(2) ? null : reader.GetString(2),
                CategoryId = reader.GetInt32(3),
                SupplierId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                CostPrice = reader.GetDecimal(5),
                SellingPrice = reader.GetDecimal(6),
                StockQuantity = reader.GetInt32(7),
                ReorderLevel = reader.GetInt32(8),
                ExpiryDate = reader.IsDBNull(9)
                    ? null
                    : reader.GetDateTime(9),
                IsActive = reader.GetBoolean(10),
                CreatedAt = reader.GetDateTime(11),
                CategoryName = reader.GetString(12),
                SupplierName = reader.IsDBNull(13)
                    ? null
                    : reader.GetString(13)
            };
        }
    }
}
