namespace Mart_Management_System.Models
{
    public class RangeSummary
    {
        public decimal Revenue { get; set; }

        public int SalesCount { get; set; }

        public string TopSellingProduct { get; set; } = "No sales yet";

        public decimal TopSellingQuantity { get; set; }
    }
}
