using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class Taxation
    {
        public int TaxId { get; set; }
        public decimal? TaxRate { get; set; }
        public string TaxAccount { get; set; }
    }
}
