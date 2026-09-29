namespace Mart_Management_System.Models
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string? Barcode { get; set; }

        public int CategoryId { get; set; }

        public int? SupplierId { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int StockQuantity { get; set; }

        public int ReorderLevel { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? SupplierName { get; set; }

        public override string GetDisplayName() => ProductName;
    }
}
