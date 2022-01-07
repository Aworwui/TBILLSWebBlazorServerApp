using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class OrderRepository : SqlRepository<Order>, IOrderRepository
    {
        public OrderRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Order order)
        {
            EfDbSet.Remove(order);
        }

        public override IQueryable<Order> GetAll()
        {
            return EfDbSet.Include(o=>o.OrderDetails).Include(a=>a.ClientAccount).OrderByDescending(a=>a.OrderId);
        }

        public async override Task<Order> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.OrderId == (decimal)id);
        }

        public async Task Insert(Order order)
        {
            await EfDbSet.AddAsync(order);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Order order)
        {
            var entry = Context.Entry(order);
            if (entry.State == EntityState.Detached)
            {
                var attachedTS = await GetById(order.OrderId);
                if (attachedTS != null)
                {
                    Context.Entry(attachedTS).CurrentValues.SetValues(order);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
    public interface IOrderRepository
    {
        Task Insert(Order order);
        Task Update(Order order);
        void Delete(Order order);
        void Save();
    }
}
