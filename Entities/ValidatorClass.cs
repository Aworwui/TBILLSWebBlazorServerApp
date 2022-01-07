using FluentValidation;

namespace TBILLSWebBlazorServerApp.Entities
{
    public class TSDetailValidator : AbstractValidator<TradingSessionDetail>
    {
        public TSDetailValidator()
        {
            RuleFor(p => p.SecurityCode).NotEmpty().WithMessage("You must enter a Security code");
            RuleFor(p => p.SessionNumber).NotEmpty().WithMessage("You must enter Session Number");
        }
    }

    public class TSValidator : AbstractValidator<TradingSession>
    {
    public TSValidator()
        {
            RuleFor(p => p.TenderDate).NotEmpty().WithMessage("You must enter a Tender Date");
         
        }

    }

    public class AllotmentValidator : AbstractValidator<Allotment>
    {
        public AllotmentValidator()
        {
            RuleFor(p => p.AllotmentNo).NotEmpty().WithMessage("You must enter a Allotment No:");
            RuleFor(p => p.SessionNumber).NotEmpty().WithMessage("You must enter Session Number");
            RuleFor(p => p.AcctNo).NotEmpty().WithMessage("You must enter Acct Number");
            RuleFor(p => p.InstructionNo).NotEmpty().WithMessage("You must enter Instruction Number");
            RuleFor(p => p.MaturityDate).NotEmpty().WithMessage("You must enter Maturity Date");
            RuleFor(p => p.Cost).NotEmpty().WithMessage("You must enter Cost");
        }
    }

    public class AuctionPurchaseValidator : AbstractValidator<AuctionPurchase>
    {
        public AuctionPurchaseValidator()
        {
            RuleFor(p => p.SecurityNo).NotEmpty().WithMessage("You must enter a Security No:");
            RuleFor(p => p.SessionNumber).NotEmpty().WithMessage("You must enter Session Number");
            RuleFor(p => p.Price).NotEmpty().WithMessage("You must enter Price");
            RuleFor(p => p.Cost).NotEmpty().WithMessage("You must enter Cost");
        }
    }

    public class pvDetailValidator : AbstractValidator<PaymentVoucherDetail>
    {
        public pvDetailValidator()
        {
            RuleFor(p => p.ChequeNo).NotEmpty().WithMessage("You must enter a Cheque No");
            RuleFor(p => p.Amount).NotEmpty().WithMessage("You must enter Amount");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero");
            RuleFor(p => p.Description).NotEmpty().WithMessage("You must enter a Description");
        }
    }

    public class pvValidator : AbstractValidator<PaymentVoucher>
    {
        public pvValidator()
        {
            RuleFor(p => p.AcctNo).NotEmpty().WithMessage("You must enter a Account Name");
            RuleFor(p => p.PvDate).NotEmpty().WithMessage("You must enter a Payment Date");
        }

    }

    public class oDetailValidator : AbstractValidator<OrderDetail>
    {
        public oDetailValidator()
        {
            RuleFor(p => p.MaturityDate).NotEmpty().WithMessage("You must enter a Maturity Date");
            RuleFor(p => p.Cost).NotEmpty().WithMessage("You must enter Cost");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
            RuleFor(p => p.InstructionNo).NotEmpty().WithMessage("You must enter a Description");
        }
    }

    public class oValidator : AbstractValidator<Order>
    {
        public oValidator()
        {
            RuleFor(p => p.AcctNo).NotEmpty().WithMessage("You must enter a Account Name");
            RuleFor(p => p.OrderDate).NotEmpty().WithMessage("You must enter a Order Date");
     
        }

    }

    public class ClientAccountValidator : AbstractValidator<ClientAccount>
    {
        public ClientAccountValidator()
        {
            RuleFor(p => p.AccountName).NotEmpty().WithMessage("You must enter the Account Name");
            RuleFor(p => p.Address).NotEmpty().WithMessage("You must enter Address");
            RuleFor(p => p.BranchId).GreaterThan(0).WithMessage("You must be greater than zero");
            RuleFor(p => p.City).NotEmpty().WithMessage("You must enter the City");
        }
    }

    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(p => p.ClientName).NotEmpty().WithMessage("You must enter the Client Name");
        }
    }
}
