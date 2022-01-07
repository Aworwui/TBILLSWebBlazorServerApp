using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class AuctionPurchase
    {
        public long AuctionId { get; set; }
        public long SessionNumber { get; set; }
        public int SecurityNo { get; set; }
        public decimal? Cost { get; set; }
        public decimal? FaceValue { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? InterestRate { get; set; }
        public string ReferenceNumber { get; set; }
        public string Confirmed { get; set; }
        public decimal? InterestRateSpread { get; set; }
        public decimal? WeightedAverage { get; set; }
        public string Competitiveness { get; set; }
        public decimal? Price { get; set; }

        public virtual TradingSession TradingSession { get; set; }
        public virtual Security Security { get; set; }
    }
}
