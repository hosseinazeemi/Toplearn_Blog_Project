using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplearnBlogProject.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public int RoleId { get; set; } // superadmin - admin
        public int BlogCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Role Role { get; set; }
    }
}
