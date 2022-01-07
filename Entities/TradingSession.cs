using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class TradingSession
    {
        public TradingSession()
        {
            TradingSessionDetails = new HashSet<TradingSessionDetail>();
            Allotments = new HashSet<Allotment>();
            AuctionPurchases = new HashSet<AuctionPurchase>();
    }

    public long SessionNumber { get; set; }
        public DateTime TenderDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalAmountOffered { get; set; }
        public decimal? TotalSales { get; set; }
        public string Closed { get; set; }

        public virtual ICollection<TradingSessionDetail> TradingSessionDetails { get; set; }
        public virtual ICollection<Allotment> Allotments { get; set; }
        public virtual ICollection<AuctionPurchase> AuctionPurchases { get; set; }
    }
}
