using Mart_Management_System.Enums;

namespace Mart_Management_System.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public int SupplierId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public PurchaseOrderStatus Status { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string SupplierName { get; set; } = string.Empty;

        public string CreatedByName { get; set; } = string.Empty;

        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new();
    }
}
