using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;

namespace TBILLSWebBlazorServerApp.Entities
{
    public class ColumnCollections
    {
        public static Action<IGridColumnCollection<TradingSessionDetail>>
           TSDetailColumnsCrud = (c) =>
           {
               c.Add(o => o.SessionDetailId, true).SetPrimaryKey(true).SetCrudWidth(15);
               c.Add(o => o.SessionNumber).Titled("Session No.").SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.SecurityCode).Titled("Security").SetCrudWidth(15);
               c.Add(o => o.HighestBid).Titled("Highest Bid").SetCrudWidth(20);
               c.Add(o => o.HighestDiscBidRateAllotted).Titled("HD Bid Rate Alloted").Format("{0:F}").SetCrudWidth(15);
               c.Add(o => o.HighestIntBidRateAllotted).Titled("HI Bid Rate Alloted").Format("{0:F}").SetCrudWidth(15);
               c.Add(o => o.IntWeightedAveRate).Titled("Int Weighted Avg Rate").Format("{0:F}").SetCrudWidth(15);
               c.Add(o => o.DiscWeightedAveRate).Titled("Int Weighted Avg Rate").Format("{0:F}").SetCrudWidth(15);
               c.Add(o => o.LowestBid).Titled("Lowest Bid").SetCrudWidth(20);
               c.Add(o => o.LowestDiscBidRateAllotted).Titled("LD Bid Rate Alloted").Format("{0:F}").SetCrudWidth(15);
               c.Add(o => o.LowestIntBidRateAllotted).Titled("LI Bid Rate Alloted").Format("{0:F}").SetCrudWidth(15);
           };

        public static Action<IGridColumnCollection<Allotment>, Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>,
            Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>>
           TSAllotmentColumnsCrud = (c, e, f, g, h,i) =>
           {
               c.Add(o => o.AllotmentId).Titled("Allotment ID").SetPrimaryKey(true).SetCrudWidth(15);
               c.Add(o => o.SessionNumber).Titled("Session No").SetSelectField(true, o => o.SessionNumber.ToString(),i).SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.AllotmentNo).Titled("Allotment No.").SetCrudWidth(20);
               c.Add(o => o.AcctNo, true).SetSelectField(true, o => o.ClientAccount.AccountNumber + " - " + o.ClientAccount.AccountName, e);

               c.Add(o => o.SecurityNo, true).SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, f);
               c.Add(o => o.OrderId).Titled("Order").SetCrudWidth(20);
               c.Add(o => o.Period).Titled("Period").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.MaturityDate).Titled("Maturity Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(20);
               c.Add(o => o.LineNumber).Titled("Line No").SetCrudWidth(20);
               c.Add(o => o.VariableAmount).Titled("Variable Amt").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.DiscountRate).Titled("Discount Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.InterestRate).Titled("Interest Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.InstructionNo, true).SetSelectField(true, o => o.Instruction.InstructionNo + " - " + o.Instruction.Instruction1, g);
               c.Add(o => o.Cost).Titled("Cost").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.FaceValue).Titled("Face Value").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.NewSecurityNo, true).SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, h);
               c.Add(o => o.LastPaymentDate).Titled("Last Payment Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(15);
               c.Add(o => o.OldCost).Titled("Old Cost").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.RediscountRate).Titled("Rediscount Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.OldFaceValue).Titled("Old Face Value").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.RediscountProceeds).Titled("Rediscount Proceeds").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.RediscountConfirmation).Titled("Rediscount Confirmation").SetCrudWidth(20);
               c.Add(o => o.RediscountDate).Titled("Rediscount Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(15);
               c.Add(o => o.TakeOverFlag).Titled("TakeOverFlag");
               c.Add(o => o.RolloverFlag).Titled("Rollover").SetCrudWidth(20);
               c.Add(o => o.ROAllotmentID).Titled("Rollovered Alllotment ID").SetCrudWidth(20);
           };

        public static Action<IGridColumnCollection<AuctionPurchase>, Func<AuctionPurchase, IEnumerable<SelectItem>>>
           TSAuctionPurchaseColumnsCrud = (c, e) =>
           {
               c.Add(o => o.AuctionId).Titled("Auction Purchase ID").SetPrimaryKey(true).SetCrudWidth(15);
               c.Add(o => o.SessionNumber).Titled("Session No").SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.SecurityNo).Titled("Secuirty Type").SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, e);
               c.Add(o => o.Competitiveness).Titled("Competitiveness").SetCrudWidth(20);
               c.Add(o => o.Confirmed).Titled("Confirmed").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.Cost).Titled("Cost").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.FaceValue).Titled("Face Value").Format("{0:F}").SetCrudWidth(20);
               //c.Add(o => o.DiscountRate).Titled("Discount Rate").SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, h);
               c.Add(o => o.InterestRate).Titled("Interest Rate").SetCrudWidth(15);
               c.Add(o => o.InterestRateSpread).Titled("Interest Rate Spread").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.Price).Titled("Price").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.ReferenceNumber).Titled("Reference No").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.WeightedAverage).Titled("Weighted Average").Format("{0:F}").SetCrudWidth(20);
           };

        public static Action<IGridColumnCollection<TradingSession>,
              Func<object[], bool, bool, bool, bool, Task<IGrid>>, Func<object[], bool, bool, bool, bool, Task<IGrid>>, Func<object[], bool, bool, bool, bool, Task<IGrid>>>
            TSColumnsWithNestedCrud = (c, subgrids, Allotmentsubgrids, APsubgrids) =>
            {
                c.Add(o => o.SessionNumber).SetPrimaryKey(true).Titled("Session No").SetCrudWidth(15);
                c.Add(o => o.TenderDate).Titled("Tender Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
                c.Add(o => o.StartDate).Titled("Start Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
                c.Add(o => o.EndDate).Titled("End Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
                c.Add(o => o.TotalAmountOffered).Titled("Total Offer").SetCrudWidth(20);
                c.Add(o => o.TotalSales).Titled("Total Sales").SetCrudWidth(20);
                c.Add(o => o.Closed).Titled("Closed Amount").SetCrudWidth(20);

                /* Adding hidden "Trading session Details" column for a CRUD subgrid: */
                c.Add(o => o.TradingSessionDetails).Titled("Session Details").SubGrid("tabGroup1", subgrids, ("SessionNumber", "SessionNumber"));
                c.Add(o => o.AuctionPurchases).Titled("Auction Purchases Details").SubGrid("tabGroup1", APsubgrids, ("SessionNumber", "SessionNumber"));
                c.Add(o => o.Allotments).Titled("Allotment Details").SubGrid("tabGroup1", Allotmentsubgrids, ("SessionNumber", "SessionNumber"));
                
            };

        public static Action<IGridColumnCollection<PaymentVoucherDetail>>
           pvDetailColumnsCrud = (c) =>
           {
               c.Add(o => o.PvDetailId).Titled("Payment Voucher Detail ID").SetPrimaryKey(true).SetCrudWidth(15).SetCrudHidden(true);
               c.Add(o => o.PvNo).Titled("Payment Voucher No").SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.Description).Titled("Description");
               c.Add(o => o.ChequeNo).Titled("Cheque No").SetCrudWidth(30);
               c.Add(o => o.Amount).Titled("Amount").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.Reference).Titled("Reference").SetCrudWidth(100);
               c.Add(o => o.Paid).Titled("Paid").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.LineNo).Titled("Line No").SetCrudWidth(15);
           };

        public static Action<IGridColumnCollection<PaymentVoucher>, Func<PaymentVoucher, IEnumerable<SelectItem>>, Func<object[], bool, bool, bool, bool, Task<IGrid>>>
           pvColumnsWithNestedCrud = (c, e, pvdSubgrids) =>
           {
               c.Add(o => o.PvNo).SetPrimaryKey(true).Titled("Payment Voucher No").SetTooltip("Payment Voucher No is ... ").SetCrudWidth(20).SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.PvDate).Titled("Payment Voucher Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
               c.Add(o => o.AcctNo).Titled("Account ").SetSelectField(true, o => o.ClientAccount.AcctNo + " - " + o.ClientAccount.AccountName, e); ;

               c.Add(o => o.PaymentVoucherDetails).Titled("Payment Voucher Details").SubGrid("tabGroup1", pvdSubgrids, ("PvNo", "PvNo"));

           };

        public static Action<IGridColumnCollection<OrderDetail>, Func<OrderDetail, IEnumerable<SelectItem>>, Func<OrderDetail, IEnumerable<SelectItem>>
            , Func<OrderDetail, IEnumerable<SelectItem>>, Func<OrderDetail, IEnumerable<SelectItem>>>
           OrderDetailColumnsCrud = (c, d, e, f, g) =>
           {
               c.Add(o => o.OrderDetailId).Titled("Order Detail ID").SetPrimaryKey(true).SetCrudWidth(15).SetCrudHidden(true);
               c.Add(o => o.OrderId).Titled("Order ID").SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.SecurityNo).Titled("Security Type").SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, d).SetCrudWidth(50);
               c.Add(o => o.InstructionNo).Titled("Cheque No").SetSelectField(true, o => o.Instruction.InstructionNo + " - " + o.Instruction.Instruction1, e).SetCrudWidth(50);
               c.Add(o => o.MaturityDate).Titled("Maturity Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
               c.Add(o => o.OrderTypeNo).Titled("Order Type").SetSelectField(true, o => o.OrderType.OrderTypeNo.ToString() + " - " + o.OrderType.OrderType1, f).SetCrudWidth(50);
               c.Add(o => o.Cost).Titled("Cost").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.Price).Titled("Price").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.QuotedRate).Titled("Quoted Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.DiscountRate).Titled("Discount Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.FaceValue).Titled("Facevalue").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.InterestRate).Titled("Interest Rate").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.NewSecurityNo).Titled("New Security Type").SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, g).SetCrudWidth(50);
               c.Add(o => o.GlobusRef).Titled("Globus Rer").SetCrudWidth(20);
               c.Add(o => o.Period).Titled("Period").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.TransferAccount).Titled("Transfer Account").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.VariableAmount).Titled("Variable Amount").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.OldOrNew).Titled("Old or New").SetCrudWidth(20);
               c.Add(o => o.LineNumber).Titled("Line No").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.Flag).Titled("Flag").SetCrudWidth(20);
           };

        public static Action<IGridColumnCollection<Order>, Func<Order, IEnumerable<SelectItem>>, Func<Order, IEnumerable<SelectItem>>, Func<object[], bool, bool, bool, bool, Task<IGrid>>>
           OrderColumnsWithNestedCrud = (c, e, f,orderDetailSubgrids) =>
           {
               c.Add(o => o.OrderId).SetPrimaryKey(true).Titled("Order ID").SetCrudWidth(15).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.OrderNo).Titled("Order No").SetCrudWidth(20);
               c.Add(o => o.OrderDate).Titled("Order Date").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
               c.Add(o => o.SessionNumber).Titled("Session No").SetSelectField(true, o => o.SessionNumber.ToString(), f)
               .SetCrudWidth(20).SetReadOnlyOnUpdate(true);
               c.Add(o => o.SessionDate).Titled("Session Number").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(20);
               c.Add(o => o.AcctNo).Titled("Account ").SetSelectField(true, o => o.ClientAccount.AcctNo + " - " + o.ClientAccount.AccountName, e).SetCrudWidth(50);
               c.Add(o => o.TransactionCode).Titled("Transtion Code").SetCrudWidth(20);
               c.Add(o => o.TransactionType).Titled("Transtion Type ").SetCrudWidth(50);
               c.Add(o => o.Words).Titled("Words ").SetCrudWidth(20);
               c.Add(o => o.Figure).Titled("Words ").SetCrudWidth(20);
               c.Add(o => o.OrderDetails).Titled("Order Details").SubGrid("tabGroup1", orderDetailSubgrids, ("OrderId", "OrderId"));
           };

        public static Action<IGridColumnCollection<Client>, Func<Client, IEnumerable<SelectItem>>, Func<Client, IEnumerable<SelectItem>>, Func<Client, IEnumerable<SelectItem>>, Func<object[], bool, bool, bool, bool, Task<IGrid>>>
            ClientColumnsCrud = (c, d, e,f, clientAccountSubgrids) =>
            {
                c.Add(o => o.ClientId).SetPrimaryKey(true).Titled("Client ID").SetCrudWidth(15);
                c.Add(o => o.ClientName).Titled("Client Name").SetCrudWidth(30);
                c.Add(o => o.ClientTypeNo).Titled("Type").SetSelectField(true, o => o.ClientTypeNoNavigation.ClientTypeNo + " - " + o.ClientTypeNoNavigation.ClientType1, d).SetCrudWidth(30);
                c.Add(o => o.ClientCategoryNo).Titled("Category").SetSelectField(true, o => o.ClientCategoryNoNavigation.ClientCategoryNo.ToString() + " - " + o.ClientCategoryNoNavigation.ClientCategory1, e).SetCrudWidth(30);
                c.Add(o => o.CsdClientId).Titled("CSD ID").SetCrudWidth(30);
                c.Add(o => o.CsdClientTypeNo).Titled("CSD Type").SetSelectField(true, o => o.CsdClientTypeNoNavigation.CsdClientTypeNo.ToString() + " - " + o.CsdClientTypeNoNavigation.CsdClientType1, f).SetCrudWidth(30);
                c.Add(o => o.Taxable).Titled("Taxable").SetCrudWidth(30);
                c.Add(o => o.EntryDate).Titled("Category").Format("{0:dd-MM-yyyy}").SetFilterWidgetType("DateTimeLocal").SetCrudWidth(30);
                c.Add(o => o.ClientAccounts).Titled("Client Account").SubGrid("tabGroup1", clientAccountSubgrids, ("ClientId", "ClientId"));
            };

        public static Action<IGridColumnCollection<ClientAccount>, Func<ClientAccount, IEnumerable<SelectItem>>> ClientAccountColumnsCrud = (c, d) =>
           {
               c.Add(o => o.ClientAcctId).Titled("Account ID").SetPrimaryKey(true).SetWidth(100).SetCrudWidth(15).SetCrudHidden(true);
               c.Add(o => o.ClientId).Titled("Client ID").SetCrudWidth(30).SetReadOnlyOnUpdate(true).SetReadOnlyOnCreate(true);
               c.Add(o => o.AcctNo).Titled("Account No").SetCrudWidth(30);
               c.Add(o => o.AccountName).Titled("Name").SetCrudWidth(50);
               c.Add(o => o.AccountNumber).Titled("Account Number").SetCrudWidth(20);
               c.Add(o => o.BranchId).Titled("Branch").SetSelectField(true, o => o.Branch.BranchId.ToString() + " - " + o.Branch.Branch1, d).SetCrudWidth(30);
               c.Add(o => o.Address).Titled("Address").SetCrudWidth(30);
               c.Add(o => o.Address1).Titled("Address1").SetCrudWidth(30);
               c.Add(o => o.Address2).Titled("Address2").SetCrudWidth(30);
               c.Add(o => o.Address3).Titled("Address3").SetCrudWidth(30);
               c.Add(o => o.City).Titled("City").SetCrudWidth(30);
               c.Add(o => o.Country).Titled("Country").SetCrudWidth(30);
               c.Add(o => o.Phone).Titled("Phone").SetCrudWidth(30);
               c.Add(o => o.MobilePhone).Titled("Mobile Phone").SetCrudWidth(30);
               c.Add(o => o.Fax).Titled("Fax").SetCrudWidth(30);
               c.Add(o => o.Email).Titled("Email").SetCrudWidth(30);
               c.Add(o => o.AccountOpeningDate).Titled("Acct. Opening Date").Format("{0:F}").SetCrudWidth(20);
               c.Add(o => o.NextOfKin).Titled("Next of Kin").SetCrudWidth(30);
               c.Add(o => o.ContactAddress).Titled("Contact Addresst").SetCrudWidth(30);
               c.Add(o => o.ContactNo).Titled("Contact No.").SetCrudWidth(30);
               c.Add(o => o.ConfirmationReceiptMode).Titled("Confirmation Receipt Mode").SetCrudWidth(20);
               c.Add(o => o.CsdClientAccount).Titled("Csd Client Account").SetCrudWidth(20);
               c.Add(o => o.Status).Titled("Status").SetCrudWidth(20);
           };

        public static Action<IGridColumnCollection<Allotment>, Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>,
            Func<Allotment, IEnumerable<SelectItem>>, Func<Allotment, IEnumerable<SelectItem>>> GetAllotmentcolumns = (c, e, f, g, h, i) =>
            {
                c.Add(o => o.AllotmentId).Titled("Allotment ID").SetPrimaryKey(true).SetCrudWidth(15);
                c.Add(o => o.SessionNumber).Titled("Session No").SetSelectField(true, o => o.SessionNumber.ToString(), e).SetCrudWidth(15).SetReadOnlyOnUpdate(true);
                c.Add(o => o.AllotmentNo).Titled("Allotment No.").SetCrudWidth(20);
                c.Add(o => o.AcctNo, true).SetSelectField(true, o => o.ClientAccount.AccountNumber + " - " + o.ClientAccount.AccountName, f);

                c.Add(o => o.SecurityNo, true).SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, g);
                c.Add(o => o.OrderId).Titled("Order").SetCrudWidth(20);
                c.Add(o => o.Period).Titled("Period").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.MaturityDate).Titled("Maturity Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(20);
                c.Add(o => o.LineNumber).Titled("Line No").SetCrudWidth(20);
                c.Add(o => o.VariableAmount).Titled("Variable Amt").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.DiscountRate).Titled("Discount Rate").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.InterestRate).Titled("Interest Rate").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.InstructionNo, true).SetSelectField(true, o => o.Instruction.InstructionNo + " - " + o.Instruction.Instruction1, h);
                c.Add(o => o.Cost).Titled("Cost").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.FaceValue).Titled("Face Value").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.NewSecurityNo, true).SetSelectField(true, o => o.Security.SecurityNo + " - " + o.Security.SecurityDescription, i);
                c.Add(o => o.LastPaymentDate).Titled("Last Payment Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(15);
                c.Add(o => o.OldCost).Titled("Old Cost").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.RediscountRate).Titled("Rediscount Rate").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.OldFaceValue).Titled("Old Face Value").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.RediscountProceeds).Titled("Rediscount Proceeds").Format("{0:F}").SetCrudWidth(20);
                c.Add(o => o.RediscountConfirmation).Titled("Rediscount Confirmation").SetCrudWidth(20);
                c.Add(o => o.RediscountDate).Titled("Rediscount Date").SetFilterWidgetType("DateTimeLocal").Format("{0:dd-MM-yyyy}").SetCrudWidth(15);
                c.Add(o => o.TakeOverFlag).Titled("TakeOverFlag");
                c.Add(o => o.RolloverFlag).Titled("Rollover").SetCrudWidth(20);
                c.Add(o => o.ROAllotmentID).Titled("Rollovered Alllotment ID").SetCrudWidth(20);
            };
    }
}