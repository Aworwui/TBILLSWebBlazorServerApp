using System;
using Microsoft.EntityFrameworkCore;

namespace TBILLSWebBlazorServerApp.Entities
{
    public partial class TBILLSGBContext : SharedDbContext<TBILLSGBContext>
    {
        public TBILLSGBContext(DbContextOptions<TBILLSGBContext> options) :
         base(options){ }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }
        public DbSet<ClientCategory> ClientCategories { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<CsdClientType> CsdClientTypes { get; set; }
        public virtual DbSet<Tender> Tenders { get; set; }
        public virtual DbSet<TradingSession> TradingSessions { get; set; }
        public virtual DbSet<TradingSessionDetail> TradingSessionDetails { get; set; }
        public virtual DbSet<Allotment> Allotments { get; set; }
        public virtual DbSet<AssetType> AssetTypes { get; set; }
        public virtual DbSet<AuctionPurchase> AuctionPurchases { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<Taxation> Taxations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<PaymentVoucher> PaymentVouches { get; set; }
        public virtual DbSet<PaymentVoucherDetail> PaymentVoucherDetails { get; set; }
        public virtual DbSet<OrderReportType> OrderReportTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.HasKey(e => e.TenderDate);

                entity.ToTable("TENDERS");

                entity.Property(e => e.TenderDate)
                    .ValueGeneratedNever()
                    .HasColumnName("TENDER_DATE");

                entity.Property(e => e.ApDate)
                    .HasColumnType("datetime")
                    .HasColumnName("AP_DATE");
            });

            modelBuilder.Entity<TradingSession>(entity =>
            {
                entity.HasKey(e => e.SessionNumber);

                entity.ToTable("TRADING_SESSION");

                entity.Property(e => e.SessionNumber).HasColumnName("SESSION_NUMBER");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .HasColumnName("CLOSED");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.TenderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TENDER_DATE");

                entity.Property(e => e.TotalAmountOffered)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("TOTAL_AMOUNT_OFFERED");

                entity.Property(e => e.TotalSales)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("TOTAL_SALES");
            });

            modelBuilder.Entity<TradingSessionDetail>(entity =>
            {
                entity.HasKey(e => e.SessionDetailId);

                entity.ToTable("TRADING_SESSION_DETAILS");

                entity.Property(e => e.SessionDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("SESSION_DETAIL_ID");

                entity.Property(e => e.DiscWeightedAveRate)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("DISC_WEIGHTED_AVE_RATE");

                entity.Property(e => e.HighestBid)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("HIGHEST_BID");

                entity.Property(e => e.HighestDiscBidRateAllotted)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("HIGHEST_DISC_BID_RATE_ALLOTTED");

                entity.Property(e => e.HighestIntBidRateAllotted)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("HIGHEST_INT_BID_RATE_ALLOTTED");

                entity.Property(e => e.IntWeightedAveRate)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("INT_WEIGHTED_AVE_RATE");

                entity.Property(e => e.LowestBid)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("LOWEST_BID");

                entity.Property(e => e.LowestDiscBidRateAllotted)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("LOWEST_DISC_BID_RATE_ALLOTTED");

                entity.Property(e => e.LowestIntBidRateAllotted)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("LOWEST_INT_BID_RATE_ALLOTTED");

                entity.Property(e => e.SecurityCode)
                    .HasMaxLength(9)
                    .HasColumnName("SECURITY_CODE");

                entity.Property(e => e.SessionNumber).HasColumnName("SESSION_NUMBER");

                entity.HasOne(d => d.TradingSession)
                    .WithMany(p => p.TradingSessionDetails)
                    .HasForeignKey(d => d.SessionNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRADING_SESSION_DETAILS_TRADING_SESSION");
            });
            modelBuilder.Entity<Allotment>(entity =>
            {
                entity.HasKey(e => e.AllotmentId);

                entity.ToTable("ALLOTMENTS");

                entity.Property(e => e.AcctNo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ACCT_NO");

                entity.Property(e => e.AllotmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ALLOTMENT_ID");

                entity.Property(e => e.AllotmentNo)
                    .HasMaxLength(30)
                    .HasColumnName("ALLOTMENT_NO");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("COST");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DISCOUNT_RATE");

                entity.Property(e => e.FaceValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("FACE_VALUE");

                entity.Property(e => e.InstructionNo)
                    .HasColumnType("int")
                    .HasColumnName("INSTRUCTION_NO");

                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("INTEREST_RATE");

                entity.Property(e => e.LastPaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_PAYMENT_DATE");

                entity.Property(e => e.LineNumber)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("LINE_NUMBER");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MATURITY_DATE");

                entity.Property(e => e.NewSecurityNo)
                    .HasColumnType("int")
                    .HasColumnName("NEW_SECURITY_NO");

                entity.Property(e => e.OldCost)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("OLD_COST");

                entity.Property(e => e.OldFaceValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("OLD_FACE_VALUE");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(12)
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.Period)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("PERIOD");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RediscountConfirmation)
                    .HasMaxLength(1)
                    .HasColumnName("REDISCOUNT_CONFIRMATION");

                entity.Property(e => e.RediscountDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REDISCOUNT_DATE");

                entity.Property(e => e.RediscountProceeds)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("REDISCOUNT_PROCEEDS");

                entity.Property(e => e.RediscountRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("REDISCOUNT_RATE");

                entity.Property(e => e.SecurityNo)
                    .HasColumnType("int")
                    .HasColumnName("SECURITY_NO");

                entity.Property(e => e.SessionNumber).HasColumnName("SESSION_NUMBER")
                .HasColumnType("INT64");

                entity.HasOne(d => d.TradingSession)
                      .WithMany(p => p.Allotments)
                      .HasForeignKey(d => d.SessionNumber)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_ALLOTMENTS_TRADING_SESSION");

                entity.HasOne(d => d.Security)
                     .WithMany(p => p.Allotments)
                     .HasForeignKey(d => d.SecurityNo)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ALLOTMENTS_SECURITY_NO");

                entity.HasOne(d => d.ClientAccount)
                .WithMany(a =>a.Allotments)
                .HasForeignKey(f=>f.AcctNo)
                .HasPrincipalKey(a=>a.AcctNo);

                  

                entity.HasOne(d => d.Instruction)
                     .WithMany(p => p.Allotments)
                     .HasForeignKey(d => d.InstructionNo)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ALLOTMENTS_INSTRUCTION_NO");

                entity.Property(e => e.TakeOverFlag)
                    .HasMaxLength(1)
                    .HasColumnName("TAKE_OVER_FLAG");

                entity.Property(e => e.VariableAmount)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("VARIABLE_AMOUNT");

                entity.Property(e => e.ROAllotmentID)
                    .HasColumnType("bigint")
                    .HasColumnName("RO_ALLOTMENT_ID");

                entity.Property(e => e.RolloverFlag)
                    .HasColumnType("bit")
                    .HasColumnName("ROLLOVER_FLAG");

                entity.Property(e => e.OrderDetailID)
                      .HasColumnType("bigint")
                      .HasColumnName("ORDER_DETAIL_ID");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(e => e.AssetTypeNo);

                entity.ToTable("ASSET_TYPE");

                entity.Property(e => e.AssetTypeNo).HasColumnName("ASSET_TYPE_NO");

                entity.Property(e => e.AssetType1)
                    .HasMaxLength(30)
                    .HasColumnName("ASSET_TYPE");

                entity.Property(e => e.AssetTypeCode)
                    .HasMaxLength(9)
                    .HasColumnName("ASSET_TYPE_CODE");
            });

            modelBuilder.Entity<AuctionPurchase>(entity =>
            {
                entity.HasKey(r=>r.AuctionId);

                entity.ToTable("AUCTION_PURCHASES");

                entity.Property(e => e.AuctionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AUCTION_ID");

                entity.Property(e => e.Competitiveness)
                    .HasMaxLength(1)
                    .HasColumnName("COMPETITIVENESS");

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .HasColumnName("CONFIRMED");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("COST");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DISCOUNT_RATE");

                entity.Property(e => e.FaceValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("FACE_VALUE");

                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("INTEREST_RATE");

                entity.Property(e => e.InterestRateSpread)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("INTEREST_RATE_SPREAD");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(18)
                    .HasColumnName("REFERENCE_NUMBER");

                entity.Property(e => e.SecurityNo)
                    .HasColumnType("int)")
                    .HasColumnName("SECURITY_NO");

                entity.Property(e => e.SessionNumber).HasColumnName("SESSION_NUMBER");

                entity.HasOne(d => d.TradingSession)
                     .WithMany(p => p.AuctionPurchases)
                     .HasForeignKey(d => d.SessionNumber)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_AUCTION_PURCHASES_TRADING_SESSION");

                entity.HasOne(d => d.Security)
                     .WithMany(p => p.AuctionPurchases)
                     .HasForeignKey(d => d.SecurityNo)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_AUCTION_PURCHASES_SECURITIES");

                entity.Property(e => e.WeightedAverage)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("WEIGHTED_AVERAGE");
            });

            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.HasKey(e=>e.InstructionNo);

                entity.ToTable("INSTRUCTION");

                entity.Property(e => e.ChangeSecurity)
                    .HasMaxLength(2)
                    .HasColumnName("CHANGE_SECURITY");

                entity.Property(e => e.Instruction1)
                    .HasMaxLength(90)
                    .HasColumnName("INSTRUCTION");

                entity.Property(e => e.InstructionCode)
                    .HasMaxLength(9)
                    .HasColumnName("INSTRUCTION_CODE");

                entity.Property(e => e.InstructionNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INSTRUCTION_NO");

                entity.Property(e => e.Operator)
                    .HasMaxLength(18)
                    .HasColumnName("OPERATOR");

                entity.Property(e => e.Rediscount)
                    .HasMaxLength(1)
                    .HasColumnName("REDISCOUNT");

                entity.Property(e => e.RolloverAmount)
                    .HasMaxLength(18)
                    .HasColumnName("ROLLOVER_AMOUNT");

                entity.Property(e => e.RolloverAs)
                    .HasMaxLength(18)
                    .HasColumnName("ROLLOVER_AS");

                entity.Property(e => e.VariableAmount)
                    .HasMaxLength(2)
                    .HasColumnName("VARIABLE_AMOUNT");
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.HasKey(r=>r.SecurityNo);

                entity.ToTable("SECURITIES");

                entity.Property(e => e.AnnualDays)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("ANNUAL_DAYS");

                entity.Property(e => e.AssetTypeNo)
                    .HasColumnType("int")
                    .HasColumnName("ASSET_TYPE_NO");

                entity.Property(e => e.InterestPayableFrequency)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("INTEREST_PAYABLE_FREQUENCY");

                entity.Property(e => e.IssuerNo)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("ISSUER_NO");

                entity.Property(e => e.Msecurity)
                    .HasMaxLength(9)
                    .HasColumnName("MSECURITY");

                entity.Property(e => e.Period)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("PERIOD");

                entity.Property(e => e.RateType)
                    .HasMaxLength(18)
                    .HasColumnName("RATE_TYPE");

                entity.Property(e => e.SecurityCode)
                    .HasMaxLength(18)
                    .HasColumnName("SECURITY_CODE");

                entity.Property(e => e.SecurityDescription)
                    .HasMaxLength(60)
                    .HasColumnName("SECURITY_DESCRIPTION");

                entity.Property(e => e.SecurityLinkedTo)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("SECURITY_LINKED_TO");

                entity.Property(e => e.SecurityNo)
                    .HasColumnType("int")
                    .HasColumnName("SECURITY_NO");

                entity.Property(e => e.SecurityType)
                    .HasMaxLength(15)
                    .HasColumnName("SECURITY_TYPE");

                entity.HasOne(d => d.AssetType)
                      .WithMany(p => p.Securities)
                      .HasForeignKey(d => d.AssetTypeNo)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_SECURITIES_ASSET_TYPE");
            });

            modelBuilder.Entity<Taxation>(entity =>
            {
                entity.HasKey(e => e.TaxId);

                entity.ToTable("TAXATION");

                entity.Property(e => e.TaxAccount)
                    .HasMaxLength(18)
                    .HasColumnName("TAX_ACCOUNT");

                entity.Property(e => e.TaxId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TAX_RATE");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS")
                      .HasKey(a => a.OrderId);

                entity.Property(e => e.OrderId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.AcctNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ACCT_NO");

                entity.Property(e => e.Figure)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("FIGURE");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ORDER_DATE");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(12)
                    .HasColumnName("ORDER_NO");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(60)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.SessionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SESSION_DATE");

                entity.Property(e => e.SessionNumber)
                    .HasColumnName("SESSION_NUMBER");

                entity.Property(e => e.TransactionCode)
                    .HasMaxLength(9)
                    .HasColumnName("TRANSACTION_CODE");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(9)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.Words).HasColumnName("WORDS");

                entity.HasOne(d => d.ClientAccount)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AcctNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_ACCOUNT_ORDERS")
                    .HasPrincipalKey(o=>o.AcctNo);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("ORDER_DETAILS");

                entity.Property(e => e.OrderDetailId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_DETAIL_ID");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("COST");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DISCOUNT_RATE");

                entity.Property(e => e.FaceValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("FACE_VALUE");

                entity.Property(e => e.Flag)
                    .HasMaxLength(1)
                    .HasColumnName("FLAG");

                entity.Property(e => e.GlobusRef)
                    .HasMaxLength(10)
                    .HasColumnName("GLOBUS_REF");

                entity.Property(e => e.InstructionNo)
                    .HasColumnName("INSTRUCTION_NO");

                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("INTEREST_RATE");

                entity.Property(e => e.LineNumber).HasColumnName("LINE_NUMBER");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MATURITY_DATE");

                entity.Property(e => e.NewSecurityNo)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("NEW_SECURITY_NO");

                entity.Property(e => e.OldOrNew)
                    .HasMaxLength(3)
                    .HasColumnName("OLD_OR_NEW");

                entity.Property(e => e.OrderId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(12)
                    .HasColumnName("ORDER_NO");

                entity.Property(e => e.OrderTypeNo).HasColumnName("ORDER_TYPE_NO");

                entity.Property(e => e.Period)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("PERIOD");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.QuotedRate)
                    .HasMaxLength(9)
                    .HasColumnName("QUOTED_RATE");

                entity.Property(e => e.SecurityNo).HasColumnName("SECURITY_NO");

                entity.Property(e => e.TransferAccount)
                    .HasMaxLength(18)
                    .HasColumnName("TRANSFER_ACCOUNT");

                entity.Property(e => e.VariableAmount)
                    .HasColumnType("decimal(22, 2)")
                    .HasColumnName("VARIABLE_AMOUNT");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ORDER_DETAILS_ORDERS");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderTypeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_TYPE_ORDER_DETAILS");

                entity.HasOne(d => d.Instruction)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.InstructionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_DETAILS_INSTRUCTION")
                    .HasPrincipalKey(a=>a.InstructionNo);

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SecurityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_DETAILS_SECURITY")
                    .HasPrincipalKey(a => a.SecurityNo);
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.OrderTypeNo)
                    .HasName("PK_ORDER_TYPE_NO");

                entity.ToTable("ORDER_TYPE");

                entity.Property(e => e.OrderTypeNo)
                    .ValueGeneratedNever()
                    .HasColumnName("ORDER_TYPE_NO");

                entity.Property(e => e.OrderType1)
                    .HasMaxLength(18)
                    .HasColumnName("ORDER_TYPE");
            });

            modelBuilder.Entity<PaymentVoucher>(entity =>
            {
                entity.HasKey(e => e.PvNo)
                    .HasName("PK_PV_NO");

                entity.ToTable("PVS");

                entity.Property(e => e.PvNo)
                    .ValueGeneratedNever()
                    .HasColumnName("PV_NO");

                entity.Property(e => e.AcctNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ACCT_NO");

                entity.Property(e => e.PvDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PV_DATE");

                entity.HasOne(d => d.ClientAccount)
                   .WithMany(p => p.PaymentVouchers)
                   .HasForeignKey(d => d.AcctNo)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_CLIENT_ACCOUNT_PVS")
                   .HasPrincipalKey(a => a.AcctNo); ;

            });

            modelBuilder.Entity<PaymentVoucherDetail>(entity =>
            {
                entity.ToTable("PV_DETAILS")
                .HasKey(p => p.PvDetailId)
                .HasName("PV_DETAIL_ID");

                entity.Property(e => e.PvDetailId).HasColumnName("PV_DETAIL_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.ChequeNo)
                    .HasMaxLength(18)
                    .HasColumnName("CHEQUE_NO");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.LineNo).HasColumnName("LINE_NO");

                entity.Property(e => e.Paid)
                    .HasMaxLength(1)
                    .HasColumnName("PAID");

                entity.Property(e => e.PvNo).HasColumnName("PV_NO");

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .HasColumnName("REFERENCE");

                entity.HasOne(d => d.PaymentVoucher)
                    .WithMany(p => p.PaymentVoucherDetails)
                    .HasForeignKey(d => d.PvNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PV_DETAILS_PVS");
           
            });
            modelBuilder.Entity<OrderReportType>(entity => 
            {
                entity.ToTable("OrderDetailView")
                    .HasKey(e => e.OrderDetailId);

                entity.Property(e => e.OrderDetailId)
                    .HasColumnName("ORDER_DETAIL_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("COST");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DISCOUNT_RATE");

                entity.Property(e => e.FaceValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasColumnName("FACE_VALUE");
                entity.Property(e => e.AccountName)
                    .HasColumnName("ACCOUNT_NAME")
                    .HasMaxLength(90);
                entity.Property(e => e.AccountNumber)
                    .HasColumnName("ACCOUNT_NUMBER")
                    .HasMaxLength(18);
                entity.Property(e=>e.AcctNo)
                    .HasColumnName("ACCT_NO")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Address)
                    .HasMaxLength(90);
                entity.Property(e => e.City)
                    .HasMaxLength(30);
                entity.Property(e => e.ClientAcctId)
                    .HasColumnName("CLIENT_ACCT_ID")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.ClientId)
                    .HasColumnName("CLIENT_ID")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Instruction)
                    .HasMaxLength(100)
                    .HasColumnName("INSTRUCTION");
                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("INTEREST_RATE");
                entity.Property(e => e.MaturityDate)
                     .HasColumnType("datetime")
                     .HasColumnName("MATURITY_DATE");
                entity.Property(e => e.OrderType)
                    .HasColumnName("ORDER_TYPE")
                    .HasMaxLength(18);
                entity.Property(e=>e.Period)
                     .HasColumnType("decimal(4, 0)")
                    .HasColumnName("PERIOD");
                entity.Property(e=>e.Price)
                     .HasColumnType("decimal(24, 2)")
                    .HasColumnName("PRICE");
                entity.Property(e=>e.SecurityDescription)
                    .HasMaxLength(60)
                    .HasColumnName("SECURITY_DESCRIPTION");
                entity.Property(e => e.SessionNumber)
                    .HasColumnName("SESSION_NUMBER")
                    .HasColumnType("numeric(18, 0)");
            });

                OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    //Shared DbContext
    //

    public class SharedDbContext<TContext> : DbContext
        where TContext : SharedDbContext<TContext>
    {

        public SharedDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }
    }
}
