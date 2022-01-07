
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Mapping;
using GridShared.DataAnnotations;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("CSD_CLIENT_TYPES")]
    public partial class CsdClientType
    {
        public CsdClientType()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("CSD_CLIENT_TYPE_NO")]
        [GridColumn(Position = 0, Title = "ID", SortEnabled = true, FilterEnabled = true)]
        public int CsdClientTypeNo { get; set; }
        [Column("CSD_CLIENT_TYPE_CODE")]
        [StringLength(18)]
        [GridColumn(Position = 1, Title = "Type Code", SortEnabled = true, FilterEnabled = true)]
        public string CsdClientTypeCode { get; set; }
        [Column("CSD_CLIENT_TYPE")]
        [StringLength(90)]
        [GridColumn(Position = 0, Title = "Csd Type", SortEnabled = true, FilterEnabled = true)]
        public string CsdClientType1 { get; set; }

        [InverseProperty(nameof(Client.CsdClientTypeNoNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }

    public class CsdClientTypeMap : EntityMap<CsdClientType>
    {
        public CsdClientTypeMap()
        {
            Map(p => p.CsdClientTypeNo).ToColumn("CSD_CLIENT_TYPE_NO");
            Map(p => p.CsdClientTypeCode).ToColumn("CSD_CLIENT_TYPE_CODE");
            Map(p => p.CsdClientType1).ToColumn("CSD_CLIENT_TYPE");
        }
    }
}
