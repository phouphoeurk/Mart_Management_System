using Mart_Management_System.Enums;

namespace Mart_Management_System.Models
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public DateTime UpdatedAt { get; set; }

        public override string GetDisplayName() => FullName;
    }
}
