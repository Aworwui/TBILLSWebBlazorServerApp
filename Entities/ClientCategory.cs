using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Mapping;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("CLIENT_CATEGORIES")]
    public partial class ClientCategory
    {
        public ClientCategory()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("CLIENT_CATEGORY_NO")]
        public int ClientCategoryNo { get; set; }
        [Column("CLIENT_CATEGORY_CODE")]
        [StringLength(18)]
        [Required]
        public string ClientCategoryCode { get; set; }
        [Column("CLIENT_CATEGORY")]
        [StringLength(18)]
        public string ClientCategory1 { get; set; }
        [Column("TAXABLE")]
        [StringLength(1)]
        public string Taxable { get; set; }
        [Column("TAX_RATE", TypeName = "decimal(5, 2)")]
        public decimal? TaxRate { get; set; }
        [Column("TAX_ACCOUNT")]
        [StringLength(18)]
        public string TaxAccount { get; set; }

        [InverseProperty(nameof(Client.ClientCategoryNoNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }

    public class ClientCategoryMap : EntityMap<ClientCategory>
    {
        public ClientCategoryMap()
        {
            Map(p => p.ClientCategoryNo).ToColumn("CLIENT_CATEGORY_NO");
            Map(p => p.ClientCategoryCode).ToColumn("CLIENT_CATEGORY_CODE");
            Map(p => p.ClientCategory1).ToColumn("CLIENT_CATEGORY");
            Map(p => p.Taxable).ToColumn("TAXABLE");
            Map(p => p.TaxRate).ToColumn("TAX_RATE");
            Map(p => p.TaxAccount).ToColumn("TAX_ACCOUNT");
        }
    }
}
