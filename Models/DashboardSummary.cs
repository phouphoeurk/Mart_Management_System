namespace Mart_Management_System.Models
{
    public class DashboardSummary
    {
        public decimal TodayRevenue { get; set; }

        public int TodaySalesCount { get; set; }

        public int ActiveProducts { get; set; }

        public int LowStockCount { get; set; }

        public int ExpiringSoonCount { get; set; }

        public string TopSellingProduct { get; set; } = "No sales yet";

        public decimal TopSellingQuantity { get; set; }
    }
}
