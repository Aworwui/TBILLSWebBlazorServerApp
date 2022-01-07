using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Mapping;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("CLIENTS")]
    public partial class Client
    {
        public Client()
        {
            ClientAccounts = new HashSet<ClientAccount>();
        }

        [Key]
        [Column("CLIENT_ID")]
        public int ClientId { get; set; }
        [Column("CLIENT_NAME")]
        [StringLength(150)]
        public string ClientName { get; set; }
        [Column("CLIENT_CATEGORY_NO")]
        public int? ClientCategoryNo { get; set; }
        [Column("CLIENT_TYPE_NO")]
        public int? ClientTypeNo { get; set; }
        [Column("CSD_CLIENT_TYPE_NO")]
        public int? CsdClientTypeNo { get; set; }
        [Column("CSD_CLIENT_ID")]
        [StringLength(30)]
        public string CsdClientId { get; set; }
        [Column("TAXABLE")]
        [StringLength(50)]
        public string Taxable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [StringLength(50)]
        public string EnteredBy { get; set; }
        [Required]
        public byte[] LastModified { get; set; }

        [ForeignKey(nameof(ClientCategoryNo))]
        [InverseProperty(nameof(ClientCategory.Clients))]
        public virtual ClientCategory ClientCategoryNoNavigation { get; set; }
        [ForeignKey(nameof(ClientTypeNo))]
        [InverseProperty(nameof(ClientType.Clients))]
        public virtual ClientType ClientTypeNoNavigation { get; set; }
        [ForeignKey(nameof(CsdClientTypeNo))]
        [InverseProperty(nameof(CsdClientType.Clients))]
        public virtual CsdClientType CsdClientTypeNoNavigation { get; set; }
        [InverseProperty(nameof(ClientAccount.Client))]
        public virtual ICollection<ClientAccount> ClientAccounts { get; set; }
    }

    public class ClientMap : EntityMap<Client>
    {
        public ClientMap()
        {
            Map(p => p.ClientId).ToColumn("CLIENT_ID");
            Map(p => p.ClientName).ToColumn("CLIENT_NAME");
            Map(p => p.ClientCategoryNo).ToColumn("CLIENT_CATEGORY_NO");
            Map(p => p.ClientTypeNo).ToColumn("CLIENT_TYPE_NO");
            Map(p => p.CsdClientTypeNo).ToColumn("CSD_CLIENT_TYPE_NO");
            Map(p => p.CsdClientId).ToColumn("CSD_CLIENT_ID");
            Map(p => p.Taxable).ToColumn("TAXABLE");

            // Ignore the 'LastModified' property when mapping.
            //Map(p => p.LastModified).Ignore();
            //Map(p => p.EntryDate).Ignore();
            //Map(p => p.EnteredBy).Ignore();
        }
    }

    public class ClientLookup: Client
    {
        public string CategoryName { get; set; }
        public string ClientTypeName { get; set; }
        public string CsdTypeName { get; set; }
    }

}
