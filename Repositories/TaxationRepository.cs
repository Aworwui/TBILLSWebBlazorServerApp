using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class TaxationRepository : SqlRepository<Taxation>, ITaxationRepository
    {
        public TaxationRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Taxation taxation)
        {
            EfDbSet.Remove(taxation);
        }

        public override IQueryable<Taxation> GetAll()
        {
            return EfDbSet;
        }

        public async override Task<Taxation> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.TaxId == (int)id);
        }

        public async Task Insert(Taxation taxation)
        {
            await EfDbSet.AddAsync(taxation);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Taxation taxation)
        {
            var entry = Context.Entry(taxation);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(taxation.TaxId);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(taxation);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface ITaxationRepository
    {
        Task Insert(Taxation taxation);
        Task Update(Taxation taxation);
        void Delete(Taxation taxation);
        void Save();
    }
}
