using Mart_Management_System.Enums;

namespace Mart_Management_System.Models
{
    public class InventoryTransaction
    {
        public int InventoryTransactionId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public InventoryTransactionType TransactionType { get; set; }

        public int QuantityChange { get; set; }

        public int? SaleId { get; set; }

        public int? PurchaseOrderId { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
    }
}
