using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public DateTime? OrderDate { get; set; }
        public string Remarks { get; set; }
        public long SessionNumber { get; set; }
        public DateTime? SessionDate { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionType { get; set; }
        public string Words { get; set; }
        public decimal? Figure { get; set; }
        public decimal? AcctNo { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ClientAccount ClientAccount { get; set; }
    }
}
