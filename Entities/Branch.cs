
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Mapping;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("BRANCH")]
    public partial class Branch
    {
        public Branch()
        {
            ClientAccounts = new HashSet<ClientAccount>();
        }

        [Key]
        [Required]
        [Column("BRANCH_ID")]
        public int BranchId { get; set; }

        [Column("BRANCH")]
        [Required]
        [StringLength(25)]
        public string Branch1 { get; set; }
        [Column("BRANCH_CODE")]
        [Required]
        [StringLength(9)]
        public string BranchCode { get; set; }
        [Column("REGION")]
        [Required]
        [StringLength(45)]
        public string Region { get; set; }

        [InverseProperty(nameof(ClientAccount.Branch))]
        public virtual ICollection<ClientAccount> ClientAccounts { get; set; }
    }

    public class BranchMap : EntityMap<Branch>
    {
        public BranchMap()
        {
            Map(p => p.BranchId).ToColumn("BRANCH_ID");
            Map(p => p.Branch1).ToColumn("BRANCH");
            Map(p => p.BranchCode).ToColumn("BRANCH_CODE");
            Map(p => p.Region).ToColumn("REGION");
        }
    }
}
