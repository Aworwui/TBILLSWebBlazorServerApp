using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class PaymentVoucherDetailRepository : SqlRepository<PaymentVoucherDetail>, IPaymentVoucherDetailRepository
    {
        public PaymentVoucherDetailRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(PaymentVoucherDetail pvDetail)
        {
            EfDbSet.Remove(pvDetail);
        }

        public override IQueryable<PaymentVoucherDetail> GetAll()
        {
            return EfDbSet.Include(r=>r.PaymentVoucher) ;
        }

        public async override Task<PaymentVoucherDetail> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.PvDetailId == (long)id);
        }

        public IEnumerable<PaymentVoucherDetail> GetpvDetailByPaymentVoucherID(long id)
        {
            return GetAll().Where(o => o.PvNo == id);
        }

        public async Task Insert(PaymentVoucherDetail pvDetail)
        {
            await EfDbSet.AddAsync(pvDetail);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(PaymentVoucherDetail pvDetail)
        {
            var entry = Context.Entry(pvDetail);
            if (entry.State == EntityState.Detached)
            {
                var attachedTS = await GetById(pvDetail.PvDetailId);
                if (attachedTS != null)
                {
                    Context.Entry(attachedTS).CurrentValues.SetValues(pvDetail);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IPaymentVoucherDetailRepository
    {
        Task Insert(PaymentVoucherDetail pvDetail);
        Task Update(PaymentVoucherDetail pvDetail);
        void Delete(PaymentVoucherDetail pvDetail);
        void Save();
    }
}
