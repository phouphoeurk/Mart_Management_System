using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class InventoryRepository
    {
        public List<InventoryTransaction> GetRecent(
            int limit = 200,
            int? productId = null
        )
        {
            const string sql = """
                SELECT TOP (@limit)
                       it.InventoryTransactionId, it.ProductId, it.UserId,
                       it.TransactionType, it.QuantityChange, it.SaleId,
                       it.PurchaseOrderId, it.Notes, it.CreatedAt,
                       p.ProductName, u.FullName
                FROM dbo.InventoryTransactions AS it
                INNER JOIN dbo.Products AS p ON p.ProductId = it.ProductId
                INNER JOIN dbo.Users AS u ON u.UserId = it.UserId
                WHERE @productId IS NULL OR it.ProductId = @productId
                ORDER BY it.CreatedAt DESC, it.InventoryTransactionId DESC;
                """;

            List<InventoryTransaction> transactions = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@limit", SqlDbType.Int).Value = limit;
            command.Parameters.Add("@productId", SqlDbType.Int).Value =
                (object?)productId ?? DBNull.Value;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                transactions.Add(new InventoryTransaction
                {
                    InventoryTransactionId = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    UserId = reader.GetInt32(2),
                    TransactionType = ParseType(reader.GetString(3)),
                    QuantityChange = reader.GetInt32(4),
                    SaleId = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    PurchaseOrderId = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                    Notes = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CreatedAt = reader.GetDateTime(8),
                    ProductName = reader.GetString(9),
                    UserName = reader.GetString(10)
                });
            }

            return transactions;
        }

        public List<Product> GetLowStockProducts()
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s ON s.SupplierId = p.SupplierId
                WHERE p.IsActive = 1
                  AND p.StockQuantity <= p.ReorderLevel
                ORDER BY p.StockQuantity, p.ProductName;
                """;

            return ReadProducts(sql);
        }

        public List<Product> GetOutOfStockProducts()
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s ON s.SupplierId = p.SupplierId
                WHERE p.IsActive = 1
                  AND p.StockQuantity = 0
                ORDER BY p.ProductName;
                """;

            return ReadProducts(sql);
        }

        public List<Product> GetExpiringProducts(int days = 30)
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s ON s.SupplierId = p.SupplierId
                WHERE p.IsActive = 1
                  AND p.ExpiryDate IS NOT NULL
                  AND p.ExpiryDate >= CAST(GETDATE() AS date)
                  AND p.ExpiryDate < DATEADD(DAY, @days, CAST(GETDATE() AS date))
                ORDER BY p.ExpiryDate, p.ProductName;
                """;

            List<Product> products = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@days", SqlDbType.Int).Value = days;
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(MapProduct(reader));
            }

            return products;
        }

        public List<Product> GetExpiredProducts()
        {
            const string sql = """
                SELECT p.ProductId, p.ProductName, p.Barcode, p.CategoryId,
                       p.SupplierId, p.CostPrice, p.SellingPrice, p.StockQuantity,
                       p.ReorderLevel, p.ExpiryDate, p.IsActive, p.CreatedAt,
                       c.CategoryName, s.SupplierName
                FROM dbo.Products AS p
                INNER JOIN dbo.Categories AS c ON c.CategoryId = p.CategoryId
                LEFT JOIN dbo.Suppliers AS s ON s.SupplierId = p.SupplierId
                WHERE p.IsActive = 1
                  AND p.ExpiryDate IS NOT NULL
                  AND p.ExpiryDate < CAST(GETDATE() AS date)
                ORDER BY p.ExpiryDate, p.ProductName;
                """;

            return ReadProducts(sql);
        }

        public bool AdjustStock(
            int productId,
            int quantityDelta,
            int userId,
            string? notes = null
        )
        {
            if (quantityDelta == 0)
            {
                throw new ArgumentException(
                    "Stock adjustment cannot be zero.",
                    nameof(quantityDelta)
                );
            }

            const string updateSql = """
                UPDATE dbo.Products
                SET StockQuantity = StockQuantity + @quantityDelta
                WHERE ProductId = @productId
                  AND IsActive = 1
                  AND StockQuantity + @quantityDelta >= 0;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                using (SqlCommand updateCommand = new(
                    updateSql,
                    connection,
                    transaction
                ))
                {
                    updateCommand.Parameters.Add(
                        "@quantityDelta",
                        SqlDbType.Int
                    ).Value = quantityDelta;
                    updateCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                        productId;
                    if (updateCommand.ExecuteNonQuery() != 1)
                    {
                        throw new InvalidOperationException(
                            "The stock adjustment would result in invalid stock."
                        );
                    }
                }

                InsertTransaction(
                    connection,
                    transaction,
                    productId,
                    userId,
                    InventoryTransactionType.Adjustment,
                    quantityDelta,
                    null,
                    null,
                    notes
                );

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static void InsertTransaction(
            SqlConnection connection,
            SqlTransaction transaction,
            int productId,
            int userId,
            InventoryTransactionType type,
            int quantityChange,
            int? saleId,
            int? purchaseOrderId,
            string? notes
        )
        {
            const string sql = """
                INSERT INTO dbo.InventoryTransactions
                    (ProductId, UserId, TransactionType, QuantityChange,
                     SaleId, PurchaseOrderId, Notes, CreatedAt)
                VALUES
                    (@productId, @userId, @transactionType, @quantityChange,
                     @saleId, @purchaseOrderId, @notes, SYSUTCDATETIME());
                """;

            using SqlCommand command = new(sql, connection, transaction);
            command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@transactionType", SqlDbType.NVarChar, 20).Value =
                type.ToString();
            command.Parameters.Add("@quantityChange", SqlDbType.Int).Value =
                quantityChange;
            command.Parameters.Add("@saleId", SqlDbType.Int).Value =
                (object?)saleId ?? DBNull.Value;
            command.Parameters.Add("@purchaseOrderId", SqlDbType.Int).Value =
                (object?)purchaseOrderId ?? DBNull.Value;
            command.Parameters.Add("@notes", SqlDbType.NVarChar, 255).Value =
                (object?)notes ?? DBNull.Value;
            command.ExecuteNonQuery();
        }

        private static List<Product> ReadProducts(string sql)
        {
            List<Product> products = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(MapProduct(reader));
            }

            return products;
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
                ExpiryDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9),
                IsActive = reader.GetBoolean(10),
                CreatedAt = reader.GetDateTime(11),
                CategoryName = reader.GetString(12),
                SupplierName = reader.IsDBNull(13) ? null : reader.GetString(13)
            };
        }

        private static InventoryTransactionType ParseType(string value)
        {
            if (!Enum.TryParse(value, ignoreCase: true, out InventoryTransactionType result))
            {
                throw new InvalidOperationException(
                    $"Unsupported inventory transaction type '{value}'."
                );
            }

            return result;
        }
    }
}
