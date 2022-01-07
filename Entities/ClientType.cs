
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Mapping;


#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("CLIENT_TYPES")]
    public partial class ClientType
    {
        public ClientType()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("CLIENT_TYPE_NO")]
        public int ClientTypeNo { get; set; }
        [Column("CLIENT_TYPE_CODE")]
        [Required]
        [StringLength(18)]
        public string ClientTypeCode { get; set; }
        [Column("PARTICIPANT_ID")]
        [StringLength(18)]
        public string ParticipantId { get; set; }
        [Column("CLIENT_TYPE")]
        [Required]
        [StringLength(90)]
        public string ClientType1 { get; set; }
        [Column("CLIENT_TYPE_PREFIX")]
        [StringLength(5)]
        public string ClientTypePrefix { get; set; }

        [InverseProperty(nameof(Client.ClientTypeNoNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }

    public class ClientTypeMap : EntityMap<ClientType>
    {
        public ClientTypeMap()
        {
            Map(p => p.ClientTypeNo).ToColumn("CLIENT_TYPE_NO");
            Map(p => p.ClientTypeCode).ToColumn("CLIENT_TYPE_CODE");
            Map(p => p.ClientType1).ToColumn("CLIENT_TYPE");
            Map(p => p.ParticipantId).ToColumn("PARTICIPANT_ID");
            Map(p => p.ClientTypePrefix).ToColumn("CLIENT_TYPE_PREFIX");
        }
    }
}
