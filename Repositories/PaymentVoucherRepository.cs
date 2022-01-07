using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class PaymentVoucherRepository: SqlRepository<PaymentVoucher>, IPaymentVoucherRepository
    {
        public PaymentVoucherRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(PaymentVoucher pv)
        {
            EfDbSet.Remove(pv);
        }

        public override IQueryable<PaymentVoucher> GetAll()
        {
            return EfDbSet.Include(a=>a.PaymentVoucherDetails).Include(q=>q.ClientAccount);
        }

        public async override Task<PaymentVoucher> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.PvNo == (long)id);
        }

        public async Task Insert(PaymentVoucher pv)
        {
            await EfDbSet.AddAsync(pv);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(PaymentVoucher pv)
        {
            var entry = Context.Entry(pv);
            if (entry.State == EntityState.Detached)
            {
                var attachedTS = await GetById(pv.PvNo);
                if (attachedTS != null)
                {
                    Context.Entry(attachedTS).CurrentValues.SetValues(pv);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IPaymentVoucherRepository
    {
        Task Insert(PaymentVoucher pv);
        Task Update(PaymentVoucher pv);
        void Delete(PaymentVoucher pv);
        void Save();
    }
}
