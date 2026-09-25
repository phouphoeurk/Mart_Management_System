using System;
using System.Collections.Generic; // សម្រាប់ប្រកាស List

namespace Mart_Management_System.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal AmountReceived { get; set; }
        public decimal ChangeAmount { get; set; }

        // OOP Composition: Sale មួយ ផ្ទុកទំនិញច្រើន (SaleDetails)
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}