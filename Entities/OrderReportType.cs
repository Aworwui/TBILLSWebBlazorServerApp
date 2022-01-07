using System;

namespace TBILLSWebBlazorServerApp.Entities
{
    public class OrderReportType
    {
        public OrderReportType()
        {
        }

        public decimal OrderDetailId { get; set; }
        public decimal OrderId { get; set; }
        public int ClientAcctId { get; set; }
        public int ClientId { get; set; }
        public decimal? AcctNo { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public long SessionNumber { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public decimal? FaceValue { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? InterestRate { get; set; }
        public string Instruction { get; set; }
        public string OrderType { get; set; }
        public decimal? Period { get; set; }
        public string SecurityDescription { get; set; }
        public DateTime? MaturityDate { get; set; }

    }
}
