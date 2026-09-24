using Mart_Management_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart_Management_System.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public UserRole role { get; set; }
        public bool isActive { get; set; }
        public DateTime createdAt { get; set; }
    }
}
