namespace Mart_Management_System.Models
{
    public class Supplier : AuditableEntity
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public override string GetDisplayName() => SupplierName;
    }
}
