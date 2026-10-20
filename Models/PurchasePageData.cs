using System.Collections.Generic;

namespace Mart_Management_System.Models
{
    public sealed class PurchasePageData
    {
        public List<PurchaseOrder> RecentOrders { get; set; } = new();

        public List<Supplier> ActiveSuppliers { get; set; } = new();

        public List<Product> ActiveProducts { get; set; } = new();
    }
}
