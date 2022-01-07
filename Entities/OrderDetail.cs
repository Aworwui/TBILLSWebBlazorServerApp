using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class OrderDetail
    {
        public decimal? Period { get; set; }
        public DateTime? MaturityDate { get; set; }
        public int? LineNumber { get; set; }
        public string Flag { get; set; }
        public decimal? VariableAmount { get; set; }
        public string TransferAccount { get; set; }
        public string GlobusRef { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? InterestRate { get; set; }
        public int SecurityNo { get; set; }
        public int InstructionNo { get; set; }
        public decimal? Cost { get; set; }
        public decimal? FaceValue { get; set; }
        public decimal? NewSecurityNo { get; set; }
        public int OrderTypeNo { get; set; }
        public string OldOrNew { get; set; }
        public string QuotedRate { get; set; }
        public decimal? Price { get; set; }
        public string OrderNo { get; set; }
        public decimal? OrderId { get; set; }
        public decimal OrderDetailId { get; set; }
        public Boolean Active { get { return MaturityDate < DateTime.Now; } }
        public virtual Order Order { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Security Security { get; set; }
        public virtual Instruction Instruction { get; set; }
    }
}
