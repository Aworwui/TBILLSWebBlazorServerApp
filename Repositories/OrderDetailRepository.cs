using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class OrderDetailRepository : SqlRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(OrderDetail orderDetail)
        {
            EfDbSet.Remove(orderDetail);
        }

        public override IQueryable<OrderDetail> GetAll()
        {
            return EfDbSet.Include(c => c.Order).Include(r => r.Instruction).Include(a => a.Security).Include(o=>o.OrderType);
        }

        public async override Task<OrderDetail> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.OrderDetailId == (decimal)id);
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(decimal id)
        {
            return GetAll().Where(o => o.OrderId == id);
        }

        public async Task Insert(OrderDetail orderDetail)
        {
            await EfDbSet.AddAsync(orderDetail);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(OrderDetail orderDetail)
        {
            var entry = Context.Entry(orderDetail);
            if (entry.State == EntityState.Detached)
            {
                var attachedTSd = await GetById(orderDetail.OrderDetailId);
                if (attachedTSd != null)
                {
                    Context.Entry(attachedTSd).CurrentValues.SetValues(orderDetail);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IOrderDetailRepository
    {
        Task Insert(OrderDetail orderDetail);
        Task Update(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
        void Save();
    }
}
