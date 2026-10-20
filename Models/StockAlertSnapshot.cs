using System.Collections.Generic;

namespace Mart_Management_System.Models
{
    public sealed class StockAlertSnapshot
    {
        public List<Product> LowStock { get; set; } = new();

        public List<Product> OutOfStock { get; set; } = new();

        public List<Product> ExpiringSoon { get; set; } = new();

        public List<Product> Expired { get; set; } = new();

        public List<InventoryTransaction> RecentHistory { get; set; } = new();
    }
}
