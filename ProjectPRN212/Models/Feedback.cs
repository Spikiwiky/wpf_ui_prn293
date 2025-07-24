using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public string? FeedbackImage { get; set; }
        public string? FeedbackContent { get; set; }
        public double? RateStar { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
