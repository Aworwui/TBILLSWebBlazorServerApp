using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TBILLSWebBlazorServerApp.Entities
{
    [Table("CLIENT_ACCOUNTS")]
    public partial class ClientAccount
    {
        public ClientAccount() {
            Allotments = new HashSet<Allotment>();
            PaymentVouchers = new HashSet<PaymentVoucher>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("CLIENT_ACCT_ID")]
        public int ClientAcctId { get; set; }
        [Column("CLIENT_ID")]
        public int ClientId { get; set; }
        [Column("ACCT_NO", TypeName = "numeric(18, 0)")]
        public decimal? AcctNo { get; set; }
        [Column("ACCOUNT_NAME")]
        [Required]
        [StringLength(90)]
        public string AccountName { get; set; }
        [Column("ACCOUNT_NUMBER")]
        [StringLength(18)]
        [Required]
        public string AccountNumber { get; set; }
        [Column("BRANCH_ID")]
        public int? BranchId { get; set; }
        [Column("ADDRESS")]
        [StringLength(90)]
        [Required]
        public string Address { get; set; }
        [Column("ADDRESS1")]
        [StringLength(90)]
        public string Address1 { get; set; }
        [Column("CITY")]
        [StringLength(30)]
        [Required]
        public string City { get; set; }
        [Column("COUNTRY")]
        [StringLength(30)]
        public string Country { get; set; }
        [Column("PHONE")]
        [StringLength(30)]
        public string Phone { get; set; }
        [Column("MOBILE_PHONE")]
        [StringLength(30)]
        public string MobilePhone { get; set; }
        [Column("FAX")]
        [StringLength(30)]
        public string Fax { get; set; }
        [Column("EMAIL")]
        [StringLength(60)]
        public string Email { get; set; }
        [Column("ACCOUNT_OPENING_DATE", TypeName = "datetime")]
        public DateTime? AccountOpeningDate { get; set; }
        [Column("NEXT_OF_KIN")]
        [StringLength(180)]
        public string NextOfKin { get; set; }
        [Column("CONTACT_ADDRESS")]
        [StringLength(180)]
        public string ContactAddress { get; set; }
        [Column("CONTACT_NO")]
        [StringLength(60)]
        public string ContactNo { get; set; }
        [Column("CONFIRMATION_RECEIPT_MODE")]
        [StringLength(1)]
        public string ConfirmationReceiptMode { get; set; }
        [Column("ADDRESS2")]
        [StringLength(60)]
        public string Address2 { get; set; }
        [Column("ADDRESS3")]
        [StringLength(60)]
        public string Address3 { get; set; }
        [Column("CSD_CLIENT_ACCOUNT")]
        [StringLength(30)]
        public string CsdClientAccount { get; set; }
        [Column("STATUS")]
        [StringLength(10)]
        public string Status { get; set; }

        [ForeignKey(nameof(BranchId))]
        [InverseProperty("ClientAccounts")]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientAccounts")]
        public virtual Client Client { get; set; }

        public virtual ICollection<Allotment> Allotments { get; set; }
        public virtual ICollection<PaymentVoucher> PaymentVouchers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
