using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class Allotment
    {
        public long AllotmentId { get; set; }
        public string AllotmentNo { get; set; }
        public string OrderId { get; set; }
        public decimal? Period { get; set; }
        public DateTime? MaturityDate { get; set; }
        public decimal? LineNumber { get; set; }
        public decimal? VariableAmount { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? InterestRate { get; set; }
        public int? SecurityNo { get; set; }
        public int? InstructionNo { get; set; }
        public long SessionNumber { get; set; }
        public decimal? Cost { get; set; }
        public decimal? FaceValue { get; set; }
        public int? NewSecurityNo { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public decimal? OldCost { get; set; }
        public decimal? RediscountRate { get; set; }
        public decimal? OldFaceValue { get; set; }
        public decimal? AcctNo { get; set; }
        public decimal? RediscountProceeds { get; set; }
        public string RediscountConfirmation { get; set; }
        public DateTime? RediscountDate { get; set; }
        public string TakeOverFlag { get; set; }
        public decimal? Price { get; set; }
        public long? ROAllotmentID { get; set; }
        public bool? RolloverFlag { get; set; }
        public long? OrderDetailID { get; set; }

        public virtual TradingSession TradingSession { get; set; }
        public virtual Security Security { get; set; }
        public virtual Instruction Instruction { get; set; }
        public virtual ClientAccount ClientAccount { get; set; }
    }
}
