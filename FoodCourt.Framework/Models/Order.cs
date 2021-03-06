﻿using System;
using System.Collections.Generic;

namespace FoodCourt.Framework.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public double? Total { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ReceiveTime { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual MyIdentity User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
