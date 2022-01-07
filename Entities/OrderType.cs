using System;
using System.Collections.Generic;

#nullable disable

namespace  TBILLSWebBlazorServerApp.Entities
{
    public partial class OrderType
    {
        public OrderType()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderTypeNo { get; set; }
        public string OrderType1 { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
