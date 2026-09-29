namespace Mart_Management_System.Models
{
    public abstract class AuditableEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public abstract string GetDisplayName();
    }
}
