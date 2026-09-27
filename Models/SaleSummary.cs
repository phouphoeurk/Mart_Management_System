namespace Mart_Management_System.Models
{
    public class SaleSummary
    {
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }

        public int CashierUserId { get; set; }

        public string CashierName { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
