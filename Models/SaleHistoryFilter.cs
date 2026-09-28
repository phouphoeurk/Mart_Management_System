namespace Mart_Management_System.Models
{
    public class SaleHistoryFilter
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? CashierUserId { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public string? Keyword { get; set; }
    }
}
