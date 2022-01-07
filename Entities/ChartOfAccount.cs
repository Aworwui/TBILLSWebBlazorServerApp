
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    
    [Table("CHART_OF_ACCOUNT")]
    public partial class ChartOfAccount
    {
        [Key]
        [Column("ACCOUNT_CODE")]
        [Required]
        [StringLength(45)]
        public string AccountCode { get; set; }
        [Column("ACCOUNT_DESCRIPTION")]
        [Required]
        [StringLength(45)]
        public string AccountDescription { get; set; }
    }
}
