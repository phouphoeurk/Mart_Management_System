using System.Data;
using Mart_Management_System.Data;
using Mart_Management_System.Models;
using Mart_Management_System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Mart_Management_System.Repositories
{
    public class DashboardRepository
    {
        public DashboardSummary GetSummary()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetSummary");
            const string sql = """
                SELECT
                    ISNULL((
                        SELECT SUM(s.TotalAmount)
                        FROM dbo.Sales AS s
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @today
                          AND s.SaleDate < @tomorrow
                    ), 0),
                    ISNULL((
                        SELECT COUNT(*)
                        FROM dbo.Sales AS s
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @today
                          AND s.SaleDate < @tomorrow
                    ), 0),
                    (SELECT COUNT(*) FROM dbo.Products WHERE IsActive = 1),
                    (SELECT COUNT(*)
                     FROM dbo.Products
                     WHERE IsActive = 1
                       AND StockQuantity <= ReorderLevel),
                    (SELECT COUNT(*)
                     FROM dbo.Products
                     WHERE IsActive = 1
                       AND ExpiryDate >= @today
                       AND ExpiryDate < DATEADD(DAY, 30, @tomorrow)),
                    COALESCE((
                        SELECT TOP 1 p.ProductName
                        FROM dbo.SaleDetails AS sd
                        INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                        INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
                        WHERE s.Status = 'Completed'
                        GROUP BY p.ProductName
                        ORDER BY SUM(sd.Quantity) DESC, p.ProductName
                    ), 'No sales yet'),
                    CAST(COALESCE((
                        SELECT TOP 1 SUM(sd.Quantity)
                        FROM dbo.SaleDetails AS sd
                        INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                        WHERE s.Status = 'Completed'
                        GROUP BY sd.ProductId
                        ORDER BY SUM(sd.Quantity) DESC, sd.ProductId
                    ), 0) AS decimal(18,2));
                """;

            DateTime today = DateTime.Today;
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@today", SqlDbType.DateTime2).Value = today;
            command.Parameters.Add("@tomorrow", SqlDbType.DateTime2).Value = today.AddDays(1);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return new DashboardSummary();
            }

            return new DashboardSummary
            {
                TodayRevenue = reader.GetDecimal(0),
                TodaySalesCount = reader.GetInt32(1),
                ActiveProducts = reader.GetInt32(2),
                LowStockCount = reader.GetInt32(3),
                ExpiringSoonCount = reader.GetInt32(4),
                TopSellingProduct = reader.GetString(5),
                TopSellingQuantity = reader.GetDecimal(6)
            };
        }

        public RangeSummary GetRangeSummary(DateTime fromDate, DateTime toDate)
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetRangeSummary");
            const string sql = """
                SELECT
                    ISNULL((
                        SELECT SUM(s.TotalAmount)
                        FROM dbo.Sales AS s
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                    ), 0),
                    ISNULL((
                        SELECT COUNT(*)
                        FROM dbo.Sales AS s
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                    ), 0),
                    COALESCE((
                        SELECT TOP 1 p.ProductName
                        FROM dbo.SaleDetails AS sd
                        INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                        INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                        GROUP BY p.ProductId, p.ProductName
                        ORDER BY SUM(sd.Quantity) DESC, p.ProductName
                    ), 'No sales yet'),
                    CAST(COALESCE((
                        SELECT TOP 1 SUM(sd.Quantity)
                        FROM dbo.SaleDetails AS sd
                        INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                        GROUP BY sd.ProductId
                        ORDER BY SUM(sd.Quantity) DESC, sd.ProductId
                    ), 0) AS decimal(18,2));
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value =
                fromDate.Date;
            command.Parameters.Add("@toNextDay", SqlDbType.DateTime2).Value =
                toDate.Date.AddDays(1);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return new RangeSummary();
            }

            return new RangeSummary
            {
                Revenue = reader.GetDecimal(0),
                SalesCount = reader.GetInt32(1),
                TopSellingProduct = reader.GetString(2),
                TopSellingQuantity = reader.GetDecimal(3)
            };
        }

        public List<ReportRow> GetHourlyTrend(DateTime date)
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetHourlyTrend");
            const string sql = """
                SELECT DATEPART(HOUR, s.SaleDate) AS SaleHour,
                       SUM(s.TotalAmount) AS Revenue
                FROM dbo.Sales AS s
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY DATEPART(HOUR, s.SaleDate)
                ORDER BY SaleHour;
                """;

            return ReadRows(
                sql,
                (reader, row) =>
                {
                    row.Label = reader.GetInt32(0).ToString("00");
                    row.Value = reader.GetDecimal(1);
                    row.DisplayValue = row.Value.ToString("C2");
                },
                date,
                date
            );
        }

        public List<SaleSummary> GetRecentSales(int limit = 5)
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetRecentSales");
            const string sql = """
                SELECT TOP (@limit)
                       s.SaleId, s.SaleDate, s.CashierUserId,
                       ISNULL(NULLIF(u.FullName, ''), u.Username) AS CashierName,
                       s.PaymentMethod, s.TotalAmount, s.Status
                FROM dbo.Sales AS s
                INNER JOIN dbo.Users AS u
                    ON u.UserId = s.CashierUserId
                ORDER BY s.SaleDate DESC, s.SaleId DESC;
                """;

            List<SaleSummary> sales = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@limit", SqlDbType.Int).Value = limit;

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

        public List<ReportRow> GetLowStockProducts(int limit = 5)
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetLowStockProducts");
            const string sql = """
                SELECT TOP (@limit)
                       ProductName, StockQuantity, ReorderLevel
                FROM dbo.Products
                WHERE IsActive = 1
                  AND StockQuantity <= ReorderLevel
                ORDER BY (CAST(StockQuantity AS decimal(18,2))
                          / NULLIF(ReorderLevel, 0)) ASC,
                         StockQuantity ASC,
                         ProductName;
                """;

            return ReadLowStock(sql, limit);
        }

        public List<ReportRow> GetLowStockReport()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetLowStockReport");
            const string sql = """
                SELECT ProductName, StockQuantity, ReorderLevel
                FROM dbo.Products
                WHERE IsActive = 1
                  AND StockQuantity <= ReorderLevel
                ORDER BY (CAST(StockQuantity AS decimal(18,2))
                          / NULLIF(ReorderLevel, 0)) ASC,
                         StockQuantity ASC,
                         ProductName;
                """;

            return ReadLowStock(sql, limit: null);
        }

        private static List<ReportRow> ReadLowStock(string sql, int? limit)
        {
            List<ReportRow> rows = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            if (limit.HasValue)
            {
                command.Parameters.Add("@limit", SqlDbType.Int).Value =
                    limit.Value;
            }

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int stock = reader.GetInt32(1);
                int reorder = reader.GetInt32(2);
                rows.Add(new ReportRow
                {
                    Label = reader.GetString(0),
                    Value = stock,
                    DisplayValue = reorder > 0
                        ? $"{stock} / reorder {reorder}"
                        : $"{stock} left"
                });
            }

            return rows;
        }

        public List<ReportRow> GetSalesByProduct(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetSalesByProduct");
            const string sql = """
                SELECT p.ProductName,
                       SUM(sd.LineSubtotal) AS Revenue,
                       SUM(sd.Quantity) AS Quantity
                FROM dbo.SaleDetails AS sd
                INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY p.ProductId, p.ProductName
                ORDER BY Revenue DESC, p.ProductName;
                """;

            List<ReportRow> rows = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddDateParameters(command, fromDate, toDate);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                decimal revenue = reader.GetDecimalSafe(1);
                decimal quantity = reader.GetDecimalSafe(2);
                rows.Add(new ReportRow
                {
                    Label = reader.GetStringSafe(0),
                    Value = revenue,
                    DisplayValue =
                        $"{revenue:C2} \u00B7 {quantity:0} units"
                });
            }

            return rows;
        }

        public List<ReportRow> GetProfitReport(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetProfitReport");
            const string sql = """
                SELECT
                    ISNULL((
                        SELECT SUM(s.TotalAmount)
                        FROM dbo.Sales AS s
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                    ), 0),
                    ISNULL((
                        SELECT SUM(CAST(sd.Quantity AS decimal(18,2))
                                   * p.CostPrice)
                        FROM dbo.SaleDetails AS sd
                        INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                        INNER JOIN dbo.Products AS p
                            ON p.ProductId = sd.ProductId
                        WHERE s.Status = 'Completed'
                          AND s.SaleDate >= @fromDate
                          AND s.SaleDate < @toNextDay
                    ), 0);
                """;

            decimal revenue;
            decimal costOfGoodsSold;
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (SqlCommand command = new(sql, connection))
            {
                AddDateParameters(command, fromDate, toDate);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return new List<ReportRow>();
                }

                revenue = reader.GetDecimal(0);
                costOfGoodsSold = reader.GetDecimal(1);
            }

            decimal grossProfit = revenue - costOfGoodsSold;
            return new List<ReportRow>
            {
                new()
                {
                    Label = "Revenue",
                    Value = revenue,
                    DisplayValue = revenue.ToString("C2")
                },
                new()
                {
                    Label = "Cost of goods sold",
                    Value = costOfGoodsSold,
                    DisplayValue = costOfGoodsSold.ToString("C2")
                },
                new()
                {
                    Label = "Gross profit",
                    Value = grossProfit,
                    DisplayValue = grossProfit.ToString("C2")
                }
            };
        }

        public ReportTotals GetPeriodTotals()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetPeriodTotals");
            DateTime today = DateTime.Today;
            DateTime weekStart = today.AddDays(-(int)today.DayOfWeek);
            DateTime monthStart = new(today.Year, today.Month, 1);

            return new ReportTotals
            {
                DailySales = GetRevenueBetween(today, today),
                WeeklySales = GetRevenueBetween(weekStart, today),
                MonthlySales = GetRevenueBetween(monthStart, today)
            };
        }

        public List<ReportRow> GetSalesTrend(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetSalesTrend");
            const string sql = """
                SELECT CAST(s.SaleDate AS date) AS SaleDay,
                       SUM(s.TotalAmount) AS Revenue
                FROM dbo.Sales AS s
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY CAST(s.SaleDate AS date)
                ORDER BY SaleDay;
                """;

            return ReadRows(
                sql,
                (reader, row) =>
                {
                    row.Label = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                    row.Value = reader.GetDecimal(1);
                    row.DisplayValue = row.Value.ToString("C2");
                },
                fromDate,
                toDate
            );
        }

        public List<ReportRow> GetRevenueByCashier(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetRevenueByCashier");
            const string sql = """
                SELECT COALESCE(NULLIF(u.FullName, ''), u.Username),
                       SUM(s.TotalAmount)
                FROM dbo.Sales AS s
                INNER JOIN dbo.Users AS u ON u.UserId = s.CashierUserId
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY u.UserId, u.FullName, u.Username
                ORDER BY SUM(s.TotalAmount) DESC;
                """;

            return ReadRows(
                sql,
                (reader, row) =>
                {
                    row.Label = reader.GetString(0);
                    row.Value = reader.GetDecimal(1);
                    row.DisplayValue = row.Value.ToString("C2");
                },
                fromDate,
                toDate
            );
        }

        public List<ReportRow> GetRevenueByPaymentMethod(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetRevenueByPaymentMethod");
            const string sql = """
                SELECT s.PaymentMethod, SUM(s.TotalAmount)
                FROM dbo.Sales AS s
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY s.PaymentMethod
                ORDER BY SUM(s.TotalAmount) DESC;
                """;

            return ReadRows(
                sql,
                (reader, row) =>
                {
                    row.Label = reader.GetString(0);
                    row.Value = reader.GetDecimal(1);
                    row.DisplayValue = row.Value.ToString("C2");
                },
                fromDate,
                toDate
            );
        }

        public List<ReportRow> GetTopProducts(
            DateTime fromDate,
            DateTime toDate,
            int limit = 10
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetTopProducts");
            const string sql = """
                SELECT TOP (@limit)
                       p.ProductName,
                       SUM(sd.Quantity) AS Quantity,
                       SUM(sd.LineSubtotal) AS Revenue
                FROM dbo.SaleDetails AS sd
                INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY p.ProductId, p.ProductName
                ORDER BY Quantity DESC, p.ProductName;
                """;

            List<ReportRow> rows = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddDateParameters(command, fromDate, toDate);
            command.Parameters.Add("@limit", SqlDbType.Int).Value = limit;

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                decimal quantity = Convert.ToDecimal(reader.GetValue(1));
                decimal revenue = Convert.ToDecimal(reader.GetValue(2));
                rows.Add(new ReportRow
                {
                    Label = reader.GetString(0),
                    Value = quantity,
                    DisplayValue = $"{quantity:0} units / {revenue:C2}"
                });
            }

            return rows;
        }

        public List<ReportRow> GetSalesByCategory(
            DateTime fromDate,
            DateTime toDate
        )
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetSalesByCategory");
            const string sql = """
                SELECT c.CategoryName, SUM(sd.LineSubtotal)
                FROM dbo.SaleDetails AS sd
                INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
                INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
                INNER JOIN dbo.Categories AS c ON c.CategoryId = p.CategoryId
                WHERE s.Status = 'Completed'
                  AND s.SaleDate >= @fromDate
                  AND s.SaleDate < @toNextDay
                GROUP BY c.CategoryId, c.CategoryName
                ORDER BY SUM(sd.LineSubtotal) DESC;
                """;

            return ReadRows(
                sql,
                (reader, row) =>
                {
                    row.Label = reader.GetString(0);
                    row.Value = reader.GetDecimal(1);
                    row.DisplayValue = row.Value.ToString("C2");
                },
                fromDate,
                toDate
            );
        }

        public List<ReportRow> GetSupplierPurchaseHistory()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetSupplierPurchaseHistory");
            const string sql = """
                SELECT s.SupplierName, SUM(po.TotalAmount)
                FROM dbo.PurchaseOrders AS po
                INNER JOIN dbo.Suppliers AS s
                    ON s.SupplierId = po.SupplierId
                WHERE po.Status = 'Received'
                GROUP BY s.SupplierId, s.SupplierName
                ORDER BY SUM(po.TotalAmount) DESC;
                """;

            List<ReportRow> rows = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                decimal total = reader.GetDecimal(1);
                rows.Add(new ReportRow
                {
                    Label = reader.GetString(0),
                    Value = total,
                    DisplayValue = total.ToString("C2")
                });
            }

            return rows;
        }

        public decimal GetAllTimeRevenue()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetAllTimeRevenue");
            return GetRevenueBetween(new DateTime(2000, 1, 1), DateTime.Today);
        }

        public decimal GetInventoryValue()
        {
            using var __perf = Mart_Management_System.Diagnostics.PerfTimer.Measure("DashboardRepository.GetInventoryValue");
            const string sql = """
                SELECT ISNULL(SUM(CAST(StockQuantity AS decimal(18,2)) * CostPrice), 0)
                FROM dbo.Products
                WHERE IsActive = 1;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            connection.Open();
            return (decimal)command.ExecuteScalar();
        }

        private decimal GetRevenueBetween(DateTime fromDate, DateTime toDate)
        {
            const string sql = """
                SELECT ISNULL(SUM(TotalAmount), 0)
                FROM dbo.Sales
                WHERE Status = 'Completed'
                  AND SaleDate >= @fromDate
                  AND SaleDate < @toNextDay;
                """;

            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddDateParameters(command, fromDate, toDate);
            connection.Open();
            return (decimal)command.ExecuteScalar();
        }

        private static List<ReportRow> ReadRows(
            string sql,
            Action<SqlDataReader, ReportRow> map,
            DateTime fromDate,
            DateTime toDate
        )
        {
            List<ReportRow> rows = new();
            using SqlConnection connection = DatabaseConnection.GetConnection();
            using SqlCommand command = new(sql, connection);
            AddDateParameters(command, fromDate, toDate);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReportRow row = new();
                map(reader, row);
                rows.Add(row);
            }

            return rows;
        }

        private static void AddDateParameters(
            SqlCommand command,
            DateTime fromDate,
            DateTime toDate
        )
        {
            command.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value =
                fromDate.Date;
            command.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = toDate.Date;
            command.Parameters.Add("@toNextDay", SqlDbType.DateTime2).Value =
                toDate.Date.AddDays(1);
        }
    }
}
