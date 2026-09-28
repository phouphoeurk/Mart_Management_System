namespace Mart_Management_System.Models
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal LineSubtotal { get; set; }

        public string ProductName { get; set; } = string.Empty;
    }
}
