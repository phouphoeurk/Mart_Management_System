using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class PurchaseOrderRepository
    {
        public List<PurchaseOrder> GetAll(PurchaseOrderStatus? status = null)
        {
            const string sql = """
                SELECT po.PurchaseOrderId, po.SupplierId, po.CreatedByUserId,
                       po.PurchaseDate, po.Status, po.Subtotal,
                       po.DiscountAmount, po.TotalAmount,
                       s.SupplierName, u.FullName
                FROM dbo.PurchaseOrders AS po
                INNER JOIN dbo.Suppliers AS s
                    ON s.SupplierId = po.SupplierId
                INNER JOIN dbo.Users AS u
                    ON u.UserId = po.CreatedByUserId
                WHERE @status IS NULL OR po.Status = @status
                ORDER BY po.PurchaseDate DESC, po.PurchaseOrderId DESC;
                """;

            List<PurchaseOrder> orders = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value =
                (object?)status?.ToString() ?? DBNull.Value;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new PurchaseOrder
                {
                    PurchaseOrderId = reader.GetInt32(0),
                    SupplierId = reader.GetInt32(1),
                    CreatedByUserId = reader.GetInt32(2),
                    PurchaseDate = reader.GetDateTime(3),
                    Status = ParseStatus(reader.GetString(4)),
                    Subtotal = reader.GetDecimal(5),
                    DiscountAmount = reader.GetDecimal(6),
                    TotalAmount = reader.GetDecimal(7),
                    PurchaseOrderDetails = new List<PurchaseOrderDetail>()
                });
            }

            return orders;
        }

        public PurchaseOrder? GetById(int purchaseOrderId)
        {
            const string headerSql = """
                SELECT po.PurchaseOrderId, po.SupplierId, po.CreatedByUserId,
                       po.PurchaseDate, po.Status, po.Subtotal,
                       po.DiscountAmount, po.TotalAmount
                FROM dbo.PurchaseOrders AS po
                WHERE po.PurchaseOrderId = @purchaseOrderId;
                """;

            const string detailSql = """
                SELECT PurchaseOrderDetailId, PurchaseOrderId, ProductId,
                       Quantity, UnitCost, LineSubtotal
                FROM dbo.PurchaseOrderDetails
                WHERE PurchaseOrderId = @purchaseOrderId
                ORDER BY PurchaseOrderDetailId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand headerCommand = new(headerSql, connection);
            headerCommand.Parameters.Add("@purchaseOrderId", SqlDbType.Int).Value =
                purchaseOrderId;

            connection.Open();
            PurchaseOrder? order;
            using (SqlDataReader reader = headerCommand.ExecuteReader())
            {
                order = reader.Read()
                    ? new PurchaseOrder
                    {
                        PurchaseOrderId = reader.GetInt32(0),
                        SupplierId = reader.GetInt32(1),
                        CreatedByUserId = reader.GetInt32(2),
                        PurchaseDate = reader.GetDateTime(3),
                        Status = ParseStatus(reader.GetString(4)),
                        Subtotal = reader.GetDecimal(5),
                        DiscountAmount = reader.GetDecimal(6),
                        TotalAmount = reader.GetDecimal(7)
                    }
                    : null;
            }

            if (order is null)
            {
                return null;
            }

            using SqlCommand detailCommand = new(detailSql, connection);
            detailCommand.Parameters.Add("@purchaseOrderId", SqlDbType.Int).Value =
                purchaseOrderId;
            using SqlDataReader detailReader = detailCommand.ExecuteReader();
            while (detailReader.Read())
            {
                order.PurchaseOrderDetails.Add(new PurchaseOrderDetail
                {
                    PurchaseOrderDetailId = detailReader.GetInt32(0),
                    PurchaseOrderId = detailReader.GetInt32(1),
                    ProductId = detailReader.GetInt32(2),
                    Quantity = detailReader.GetInt32(3),
                    UnitCost = detailReader.GetDecimal(4),
                    LineSubtotal = detailReader.GetDecimal(5)
                });
            }

            return order;
        }

        public int CreateDraft(PurchaseOrder order)
        {
            ArgumentNullException.ThrowIfNull(order);
            ValidateOrder(order);

            const string headerSql = """
                INSERT INTO dbo.PurchaseOrders
                    (SupplierId, CreatedByUserId, PurchaseDate, Status,
                     Subtotal, DiscountAmount, TotalAmount)
                VALUES
                    (@supplierId, @createdByUserId, @purchaseDate, @status,
                     @subtotal, @discountAmount, @totalAmount);
                SELECT CAST(SCOPE_IDENTITY() AS int);
                """;

            const string detailSql = """
                INSERT INTO dbo.PurchaseOrderDetails
                    (PurchaseOrderId, ProductId, Quantity, UnitCost, LineSubtotal)
                VALUES
                    (@purchaseOrderId, @productId, @quantity, @unitCost,
                     @lineSubtotal);
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using SqlCommand headerCommand = new(headerSql, connection, transaction);
                headerCommand.Parameters.Add("@supplierId", SqlDbType.Int).Value =
                    order.SupplierId;
                headerCommand.Parameters.Add("@createdByUserId", SqlDbType.Int).Value =
                    order.CreatedByUserId;
                headerCommand.Parameters.Add("@purchaseDate", SqlDbType.DateTime2).Value =
                    order.PurchaseDate;
                headerCommand.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value =
                    PurchaseOrderStatus.Draft.ToString();
                headerCommand.Parameters.Add("@subtotal", SqlDbType.Decimal).Value =
                    order.Subtotal;
                headerCommand.Parameters.Add(
                    "@discountAmount",
                    SqlDbType.Decimal
                ).Value = order.DiscountAmount;
                headerCommand.Parameters.Add("@totalAmount", SqlDbType.Decimal).Value =
                    order.TotalAmount;

                int purchaseOrderId = (int)headerCommand.ExecuteScalar();
                foreach (PurchaseOrderDetail detail in order.PurchaseOrderDetails)
                {
                    using SqlCommand detailCommand = new(detailSql, connection, transaction);
                    detailCommand.Parameters.Add(
                        "@purchaseOrderId",
                        SqlDbType.Int
                    ).Value = purchaseOrderId;
                    detailCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                        detail.ProductId;
                    detailCommand.Parameters.Add("@quantity", SqlDbType.Int).Value =
                        detail.Quantity;
                    detailCommand.Parameters.Add("@unitCost", SqlDbType.Decimal).Value =
                        detail.UnitCost;
                    detailCommand.Parameters.Add(
                        "@lineSubtotal",
                        SqlDbType.Decimal
                    ).Value = detail.LineSubtotal;
                    detailCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                return purchaseOrderId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Receive(int purchaseOrderId, int userId)
        {
            const string statusSql = """
                SELECT Status
                FROM dbo.PurchaseOrders WITH (UPDLOCK, ROWLOCK)
                WHERE PurchaseOrderId = @purchaseOrderId;
                """;

            const string detailSql = """
                SELECT ProductId, Quantity
                FROM dbo.PurchaseOrderDetails
                WHERE PurchaseOrderId = @purchaseOrderId;
                """;

            const string stockSql = """
                UPDATE dbo.Products
                SET StockQuantity = StockQuantity + @quantity
                WHERE ProductId = @productId
                  AND IsActive = 1;
                """;

            const string updateStatusSql = """
                UPDATE dbo.PurchaseOrders
                SET Status = @receivedStatus
                WHERE PurchaseOrderId = @purchaseOrderId
                  AND Status = @draftStatus;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                if (userId <= 0)
                {
                    throw new ArgumentException(
                        "A valid user is required to receive stock.",
                        nameof(userId)
                    );
                }

                using SqlCommand statusCommand = new(statusSql, connection, transaction);
                statusCommand.Parameters.Add("@purchaseOrderId", SqlDbType.Int).Value =
                    purchaseOrderId;
                string status = (string)statusCommand.ExecuteScalar();
                if (!string.Equals(
                    status,
                    PurchaseOrderStatus.Draft.ToString(),
                    StringComparison.OrdinalIgnoreCase
                ))
                {
                    throw new InvalidOperationException(
                        "Only Draft purchase orders can be received."
                    );
                }

                List<(int ProductId, int Quantity)> details = new();
                using (SqlCommand detailCommand = new(detailSql, connection, transaction))
                {
                    detailCommand.Parameters.Add("@purchaseOrderId", SqlDbType.Int).Value =
                        purchaseOrderId;
                    using SqlDataReader reader = detailCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        details.Add((reader.GetInt32(0), reader.GetInt32(1)));
                    }
                }

                foreach ((int productId, int quantity) in details)
                {
                    using SqlCommand stockCommand = new(
                        stockSql,
                        connection,
                        transaction
                    );
                    stockCommand.Parameters.Add("@quantity", SqlDbType.Int).Value =
                        quantity;
                    stockCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                        productId;
                    if (stockCommand.ExecuteNonQuery() != 1)
                    {
                        throw new InvalidOperationException(
                            "A product in the purchase order is inactive or missing."
                        );
                    }

                    InventoryRepository.InsertTransaction(
                        connection,
                        transaction,
                        productId,
                        userId,
                        InventoryTransactionType.Purchase,
                        quantity,
                        null,
                        purchaseOrderId,
                        "Purchase order received"
                    );
                }

                using SqlCommand updateStatusCommand = new(
                    updateStatusSql,
                    connection,
                    transaction
                );
                updateStatusCommand.Parameters.Add(
                    "@receivedStatus",
                    SqlDbType.NVarChar,
                    20
                ).Value = PurchaseOrderStatus.Received.ToString();
                updateStatusCommand.Parameters.Add(
                    "@draftStatus",
                    SqlDbType.NVarChar,
                    20
                ).Value = PurchaseOrderStatus.Draft.ToString();
                updateStatusCommand.Parameters.Add(
                    "@purchaseOrderId",
                    SqlDbType.Int
                ).Value = purchaseOrderId;

                if (updateStatusCommand.ExecuteNonQuery() != 1)
                {
                    throw new InvalidOperationException(
                        "The purchase order status could not be updated."
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

        private static void ValidateOrder(PurchaseOrder order)
        {
            if (order.SupplierId <= 0)
            {
                throw new ArgumentException("A supplier is required.", nameof(order));
            }

            if (order.CreatedByUserId <= 0)
            {
                throw new ArgumentException(
                    "A valid administrator is required.",
                    nameof(order)
                );
            }

            if (order.PurchaseOrderDetails.Count == 0)
            {
                throw new ArgumentException(
                    "A purchase order must contain at least one product.",
                    nameof(order)
                );
            }

            if (order.DiscountAmount < 0 || order.DiscountAmount > order.Subtotal)
            {
                throw new ArgumentException(
                    "The discount must be between zero and the subtotal.",
                    nameof(order)
                );
            }

            foreach (PurchaseOrderDetail detail in order.PurchaseOrderDetails)
            {
                if (detail.ProductId <= 0 || detail.Quantity <= 0)
                {
                    throw new ArgumentException(
                        "Each purchase product must have a positive quantity.",
                        nameof(order)
                    );
                }

                if (detail.UnitCost < 0)
                {
                    throw new ArgumentException(
                        "Purchase cost cannot be negative.",
                        nameof(order)
                    );
                }
            }
        }

        private static PurchaseOrderStatus ParseStatus(string status)
        {
            if (!Enum.TryParse(status, ignoreCase: true, out PurchaseOrderStatus result))
            {
                throw new InvalidOperationException($"Unsupported purchase status '{status}'.");
            }

            return result;
        }
    }
}
