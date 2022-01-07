using System;
using System.Collections.Generic;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class AssetType
    {
        public AssetType() { Securities = new HashSet<Security>();
        }
        public int AssetTypeNo { get; set; }
        public string AssetTypeCode { get; set; }
        public string AssetType1 { get; set; }

        public virtual ICollection<Security> Securities { get; set; }
    }
}
