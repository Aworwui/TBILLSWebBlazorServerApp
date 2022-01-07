using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class PaymentVoucher
    {
        public PaymentVoucher()
        {
            PaymentVoucherDetails = new HashSet<PaymentVoucherDetail>();
        }

        public long PvNo { get; set; }
        public DateTime? PvDate { get; set; }
        public decimal AcctNo { get; set; }

        public virtual ICollection<PaymentVoucherDetail> PaymentVoucherDetails { get; set; }
        public virtual ClientAccount ClientAccount { get; set; }
    }
}
