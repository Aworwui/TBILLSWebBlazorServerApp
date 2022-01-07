using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class OrderTypeRepository : SqlRepository<OrderType>, IOrderTypeRepository
    {
        public OrderTypeRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(OrderType orderType)
        {
            EfDbSet.Remove(orderType);
        }

        public async override Task<OrderType> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.OrderTypeNo == (int)id);
        }

        public async Task Insert(OrderType orderType)
        {
            await EfDbSet.AddAsync(orderType);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(OrderType orderType)
        {
            var entry = Context.Entry(orderType);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(orderType.OrderTypeNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(orderType);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override IQueryable<OrderType> GetAll()
        {
            return EfDbSet;
        }
    }

    public interface IOrderTypeRepository
    {
        Task Insert(OrderType orderType);
        Task Update(OrderType orderType);
        void Delete(OrderType orderType);
        void Save();
    }
}
