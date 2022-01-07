using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class Instruction
    {
        public Instruction()
        {
            Allotments = new HashSet<Allotment>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int InstructionNo { get; set; }
        public string InstructionCode { get; set; }
        public string Instruction1 { get; set; }
        public string RolloverAs { get; set; }
        public string RolloverAmount { get; set; }
        public string VariableAmount { get; set; }
        public string ChangeSecurity { get; set; }
        public string Operator { get; set; }
        public string Rediscount { get; set; }

        public virtual ICollection<Allotment> Allotments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
