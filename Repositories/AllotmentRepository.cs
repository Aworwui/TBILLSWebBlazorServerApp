using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class AllotmentRepository : SqlRepository<Allotment>, IAllotmentRepository
    {
        public AllotmentRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Allotment allotment)
        {
            EfDbSet.Remove(allotment);
        }

        public override IQueryable<Allotment> GetAll()
        {
            return EfDbSet.Include(c=>c.TradingSession).Include(r=>r.Instruction).Include(a=>a.Security).Include(s=>s.ClientAccount);
        }

        public async override Task<Allotment> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.AllotmentId == (Int64)id);
        }

        public IEnumerable<Allotment> GetAllotmentsByTradingSessionNumber(long id)
        {
            return GetAll().Where(o => o.SessionNumber == id);
        }

        public async Task Insert(Allotment allotment)
        {
            await EfDbSet.AddAsync(allotment);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Allotment allotment)
        {
            var entry = Context.Entry(allotment);
            if (entry.State == EntityState.Detached)
            {
                var attachedTSd = await GetById(allotment.AllotmentId);
                if (attachedTSd != null)
                {
                    Context.Entry(attachedTSd).CurrentValues.SetValues(allotment);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IAllotmentRepository
    {
        Task Insert(Allotment allotment);
        Task Update(Allotment allotment);
        void Delete(Allotment allotment);
        void Save();
    }
}
