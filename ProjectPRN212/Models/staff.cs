using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class staff
    {
        public staff()
        {
            Orders = new HashSet<Order>();
        }

        public int StaffId { get; set; }
        public string? Fullname { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IsDeleted { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
