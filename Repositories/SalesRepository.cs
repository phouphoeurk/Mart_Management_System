using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class SalesRepository
    {
        public List<SaleSummary> GetHistory(SaleHistoryFilter filter)
        {
            ArgumentNullException.ThrowIfNull(filter);

            const string sql = """
                SELECT s.SaleId, s.SaleDate, s.CashierUserId, u.FullName,
                       s.PaymentMethod, s.TotalAmount, s.Status
                FROM dbo.Sales AS s
                INNER JOIN dbo.Users AS u
                    ON u.UserId = s.CashierUserId
                WHERE (@fromDate IS NULL OR s.SaleDate >= @fromDate)
                  AND (@toDate IS NULL OR s.SaleDate < DATEADD(DAY, 1, @toDate))
                  AND (@cashierUserId IS NULL OR s.CashierUserId = @cashierUserId)
                  AND (@paymentMethod IS NULL OR s.PaymentMethod = @paymentMethod)
                  AND (@status IS NULL OR s.Status = @status)
                  AND (@keyword IS NULL
                       OR CAST(s.SaleId AS nvarchar(20)) LIKE @keyword)
                ORDER BY s.SaleDate DESC, s.SaleId DESC;
                """;

            List<SaleSummary> sales = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value =
                (object?)filter.FromDate?.Date ?? DBNull.Value;
            command.Parameters.Add("@toDate", SqlDbType.DateTime2).Value =
                (object?)filter.ToDate?.Date ?? DBNull.Value;
            command.Parameters.Add("@cashierUserId", SqlDbType.Int).Value =
                (object?)filter.CashierUserId ?? DBNull.Value;
            command.Parameters.Add("@paymentMethod", SqlDbType.NVarChar, 20).Value =
                (object?)filter.PaymentMethod ?? DBNull.Value;
            command.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value =
                (object?)filter.Status ?? DBNull.Value;
            command.Parameters.Add("@keyword", SqlDbType.NVarChar, 20).Value =
                string.IsNullOrWhiteSpace(filter.Keyword)
                    ? DBNull.Value
                    : $"%{filter.Keyword.Trim()}%";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sales.Add(new SaleSummary
                {
                    SaleId = reader.GetInt32(0),
                    SaleDate = reader.GetDateTime(1),
                    CashierUserId = reader.GetInt32(2),
                    CashierName = reader.GetString(3),
                    PaymentMethod = reader.GetString(4),
                    TotalAmount = reader.GetDecimal(5),
                    Status = reader.GetString(6)
                });
            }

            return sales;
        }

        public Sale? GetSale(int saleId)
        {
            const string headerSql = """
                SELECT s.SaleId, s.CashierUserId, s.SaleDate, s.Subtotal,
                       s.DiscountAmount, s.TotalAmount, s.PaymentMethod,
                       s.AmountReceived, s.ChangeAmount, s.Status, u.FullName
                FROM dbo.Sales AS s
                INNER JOIN dbo.Users AS u
                    ON u.UserId = s.CashierUserId
                WHERE s.SaleId = @saleId;
                """;

            const string detailSql = """
                SELECT sd.SaleDetailId, sd.SaleId, sd.ProductId,
                       sd.Quantity, sd.UnitPrice, sd.DiscountAmount,
                       sd.LineSubtotal, p.ProductName
                FROM dbo.SaleDetails AS sd
                INNER JOIN dbo.Products AS p
                    ON p.ProductId = sd.ProductId
                WHERE sd.SaleId = @saleId
                ORDER BY sd.SaleDetailId;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand headerCommand = new(headerSql, connection);
            headerCommand.Parameters.Add("@saleId", SqlDbType.Int).Value = saleId;

            connection.Open();
            Sale? sale;
            using (SqlDataReader reader = headerCommand.ExecuteReader())
            {
                sale = reader.Read()
                    ? new Sale
                    {
                        SaleId = reader.GetInt32(0),
                        CashierUserId = reader.GetInt32(1),
                        SaleDate = reader.GetDateTime(2),
                        Subtotal = reader.GetDecimal(3),
                        DiscountAmount = reader.GetDecimal(4),
                        TotalAmount = reader.GetDecimal(5),
                        PaymentMethod = ParsePaymentMethod(reader.GetString(6)),
                        AmountReceived = reader.IsDBNull(7)
                            ? null
                            : reader.GetDecimal(7),
                        ChangeAmount = reader.IsDBNull(8)
                            ? null
                            : reader.GetDecimal(8),
                        Status = ParseSaleStatus(reader.GetString(9)),
                        CashierName = reader.GetString(10)
                    }
                    : null;
            }

            if (sale is null)
            {
                return null;
            }

            using SqlCommand detailCommand = new(detailSql, connection);
            detailCommand.Parameters.Add("@saleId", SqlDbType.Int).Value = saleId;
            using SqlDataReader detailReader = detailCommand.ExecuteReader();
            while (detailReader.Read())
            {
                sale.SaleDetails.Add(new SaleDetail
                {
                    SaleDetailId = detailReader.GetInt32(0),
                    SaleId = detailReader.GetInt32(1),
                    ProductId = detailReader.GetInt32(2),
                    Quantity = detailReader.GetInt32(3),
                    UnitPrice = detailReader.GetDecimal(4),
                    DiscountAmount = detailReader.GetDecimal(5),
                    LineSubtotal = detailReader.GetDecimal(6),
                    ProductName = detailReader.GetString(7)
                });
            }

            return sale;
        }

        public int CreateCompletedSale(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            ValidateSale(sale);

            const string saleSql = """
                INSERT INTO dbo.Sales
                    (CashierUserId, SaleDate, Subtotal, DiscountAmount,
                     TotalAmount, PaymentMethod, AmountReceived, ChangeAmount,
                     Status)
                VALUES
                    (@cashierUserId, @saleDate, @subtotal, @discountAmount,
                     @totalAmount, @paymentMethod, @amountReceived,
                     @changeAmount, @status);
                SELECT CAST(SCOPE_IDENTITY() AS int);
                """;

            const string detailSql = """
                INSERT INTO dbo.SaleDetails
                    (SaleId, ProductId, Quantity, UnitPrice, DiscountAmount,
                     LineSubtotal)
                VALUES
                    (@saleId, @productId, @quantity, @unitPrice,
                     @discountAmount, @lineSubtotal);
                """;

            const string stockSql = """
                UPDATE dbo.Products
                SET StockQuantity = StockQuantity - @quantity
                WHERE ProductId = @productId
                  AND IsActive = 1
                  AND StockQuantity >= @quantity;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int saleId;
                using (SqlCommand saleCommand = new(saleSql, connection, transaction))
                {
                    saleCommand.Parameters.Add("@cashierUserId", SqlDbType.Int).Value =
                        sale.CashierUserId;
                    saleCommand.Parameters.Add("@saleDate", SqlDbType.DateTime2).Value =
                        sale.SaleDate;
                    saleCommand.Parameters.Add("@subtotal", SqlDbType.Decimal).Value =
                        sale.Subtotal;
                    saleCommand.Parameters.Add(
                        "@discountAmount",
                        SqlDbType.Decimal
                    ).Value = sale.DiscountAmount;
                    saleCommand.Parameters.Add("@totalAmount", SqlDbType.Decimal).Value =
                        sale.TotalAmount;
                    saleCommand.Parameters.Add(
                        "@paymentMethod",
                        SqlDbType.NVarChar,
                        20
                    ).Value = sale.PaymentMethod.ToString();
                    saleCommand.Parameters.Add(
                        "@amountReceived",
                        SqlDbType.Decimal
                    ).Value = (object?)sale.AmountReceived ?? DBNull.Value;
                    saleCommand.Parameters.Add(
                        "@changeAmount",
                        SqlDbType.Decimal
                    ).Value = (object?)sale.ChangeAmount ?? DBNull.Value;
                    saleCommand.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value =
                        SaleStatus.Completed.ToString();

                    saleId = (int)saleCommand.ExecuteScalar();
                }

                foreach (SaleDetail detail in sale.SaleDetails)
                {
                    using (SqlCommand detailCommand = new(
                        detailSql,
                        connection,
                        transaction
                    ))
                    {
                        detailCommand.Parameters.Add("@saleId", SqlDbType.Int).Value = saleId;
                        detailCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                            detail.ProductId;
                        detailCommand.Parameters.Add("@quantity", SqlDbType.Int).Value =
                            detail.Quantity;
                        detailCommand.Parameters.Add("@unitPrice", SqlDbType.Decimal).Value =
                            detail.UnitPrice;
                        detailCommand.Parameters.Add(
                            "@discountAmount",
                            SqlDbType.Decimal
                        ).Value = detail.DiscountAmount;
                        detailCommand.Parameters.Add(
                            "@lineSubtotal",
                            SqlDbType.Decimal
                        ).Value = detail.LineSubtotal;
                        detailCommand.ExecuteNonQuery();
                    }

                    using SqlCommand stockCommand = new(stockSql, connection, transaction);
                    stockCommand.Parameters.Add("@quantity", SqlDbType.Int).Value =
                        detail.Quantity;
                    stockCommand.Parameters.Add("@productId", SqlDbType.Int).Value =
                        detail.ProductId;
                    if (stockCommand.ExecuteNonQuery() != 1)
                    {
                        throw new InvalidOperationException(
                            $"Insufficient stock for product {detail.ProductId}."
                        );
                    }

                    InventoryRepository.InsertTransaction(
                        connection,
                        transaction,
                        detail.ProductId,
                        sale.CashierUserId,
                        InventoryTransactionType.Sale,
                        -detail.Quantity,
                        saleId,
                        null,
                        "POS sale completed"
                    );
                }

                transaction.Commit();
                return saleId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static PaymentMethod ParsePaymentMethod(string value)
        {
            if (!Enum.TryParse(value, ignoreCase: true, out PaymentMethod result))
            {
                throw new InvalidOperationException(
                    $"Unsupported payment method '{value}'."
                );
            }

            return result;
        }

        private static SaleStatus ParseSaleStatus(string value)
        {
            if (!Enum.TryParse(value, ignoreCase: true, out SaleStatus result))
            {
                throw new InvalidOperationException(
                    $"Unsupported sale status '{value}'."
                );
            }

            return result;
        }

        private static void ValidateSale(Sale sale)
        {
            if (sale.CashierUserId <= 0)
            {
                throw new ArgumentException("A cashier is required.", nameof(sale));
            }

            if (sale.SaleDetails.Count == 0)
            {
                throw new ArgumentException(
                    "A sale must contain at least one product.",
                    nameof(sale)
                );
            }

            if (sale.DiscountAmount < 0 || sale.DiscountAmount > sale.Subtotal)
            {
                throw new ArgumentException(
                    "The discount must be between zero and the subtotal.",
                    nameof(sale)
                );
            }

            if (sale.TotalAmount < 0)
            {
                throw new ArgumentException("The total cannot be negative.", nameof(sale));
            }

            if (sale.PaymentMethod == PaymentMethod.Cash
                && (sale.AmountReceived is null
                    || sale.AmountReceived < sale.TotalAmount))
            {
                throw new ArgumentException(
                    "Cash received must cover the total amount.",
                    nameof(sale)
                );
            }

            foreach (SaleDetail detail in sale.SaleDetails)
            {
                if (detail.ProductId <= 0 || detail.Quantity <= 0)
                {
                    throw new ArgumentException(
                        "Each sale product must have a positive quantity.",
                        nameof(sale)
                    );
                }

                if (detail.UnitPrice < 0 || detail.DiscountAmount < 0)
                {
                    throw new ArgumentException(
                        "Sale prices and discounts cannot be negative.",
                        nameof(sale)
                    );
                }
            }
        }
    }
}
