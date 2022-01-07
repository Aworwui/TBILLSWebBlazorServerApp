using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class Security
    {
        public Security() {
            AuctionPurchases =  new HashSet<AuctionPurchase>();
            Allotments = new HashSet<Allotment>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int SecurityNo { get; set; }
        public string SecurityCode { get; set; }
        public string SecurityDescription { get; set; }
        public decimal? IssuerNo { get; set; }
        public int? AssetTypeNo { get; set; }
        public decimal? Period { get; set; }
        public decimal? AnnualDays { get; set; }
        public string Msecurity { get; set; }
        public string RateType { get; set; }
        public decimal? SecurityLinkedTo { get; set; }
        public decimal? InterestPayableFrequency { get; set; }
        public string SecurityType { get; set; }

        public virtual AssetType AssetType { get; set; }
        public virtual ICollection<AuctionPurchase> AuctionPurchases { get; set; }
        public virtual ICollection<Allotment> Allotments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
