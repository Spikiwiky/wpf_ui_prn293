using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? StaffId { get; set; }
        public string? ReceiverFullname { get; set; }
        public string? ReceiverGender { get; set; }
        public string? ReceiverEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ReceiverAddress { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalCost { get; set; }
        public string? Note { get; set; }
        public string? OrderStatus { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual staff? Staff { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
