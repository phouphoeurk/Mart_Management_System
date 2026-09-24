using System;

namespace Mart_Management_System.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; } // ដាក់សញ្ញា ? ព្រោះអាច null បាន
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime? ExpiryDate { get; set; } // អាច null បាន
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}