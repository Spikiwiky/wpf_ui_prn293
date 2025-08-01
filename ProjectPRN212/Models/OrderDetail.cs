﻿using System;
using System.Collections.Generic;

namespace ProjectPRN212.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double? ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public double? TotalCost { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
