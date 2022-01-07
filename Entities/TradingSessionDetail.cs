using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class TradingSessionDetail
    {
        public long SessionDetailId { get; set; }
        public long SessionNumber { get; set; }
        public string SecurityCode { get; set; }
        public decimal? LowestBid { get; set; }
        public decimal? HighestBid { get; set; }
        public decimal? LowestDiscBidRateAllotted { get; set; }
        public decimal? HighestDiscBidRateAllotted { get; set; }
        public decimal? LowestIntBidRateAllotted { get; set; }
        public decimal? HighestIntBidRateAllotted { get; set; }
        public decimal? DiscWeightedAveRate { get; set; }
        public decimal? IntWeightedAveRate { get; set; }

        public virtual TradingSession TradingSession { get; set; }
        /*public virtual Security Security { get; set; }*/
    }
}
