using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class PaymentVoucherDetail
    {
        public long PvNo { get; set; }
        public int? LineNo { get; set; }
        public string Reference { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public string Paid { get; set; }
        public string Description { get; set; }
        public long PvDetailId { get; set; }

        public virtual PaymentVoucher PaymentVoucher { get; set; }
    }
}
