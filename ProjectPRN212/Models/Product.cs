using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class Product
    {
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? OriginalPrice { get; set; }
        public double? SalePrice { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public string? ProductImage { get; set; }
        public string? Summary { get; set; }
        public string? ProductDetail { get; set; }
        public bool? ProductStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
