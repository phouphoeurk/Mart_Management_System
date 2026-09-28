using Mart_Management_System.Enums;

namespace Mart_Management_System.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int CashierUserId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal? AmountReceived { get; set; }

        public decimal? ChangeAmount { get; set; }

        public SaleStatus Status { get; set; }

        public string CashierName { get; set; } = string.Empty;

        public List<SaleDetail> SaleDetails { get; set; } = new();
    }
}
