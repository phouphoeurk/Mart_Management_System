using System;

namespace Mart_Management_System.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; } 
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime? ExpiryDate { get; set; } 
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}