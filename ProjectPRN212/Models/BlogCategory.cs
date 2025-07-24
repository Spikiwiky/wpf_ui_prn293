using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
