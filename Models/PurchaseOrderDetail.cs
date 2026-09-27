namespace Mart_Management_System.Models
{
    public class PurchaseOrderDetail
    {
        public int PurchaseOrderDetailId { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitCost { get; set; }

        public decimal LineSubtotal { get; set; }
    }
}
