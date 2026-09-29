namespace Mart_Management_System.Models
{
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public override string GetDisplayName() => CategoryName;
    }
}
