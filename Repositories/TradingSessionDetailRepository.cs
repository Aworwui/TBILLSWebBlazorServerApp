using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class TradingSessionDetailRepository : SqlRepository<TradingSessionDetail>, ITradingSessionDetailRepository
    {
        public TradingSessionDetailRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(TradingSessionDetail tsd)
        {
            EfDbSet.Remove(tsd);
        }

        public override IQueryable<TradingSessionDetail> GetAll()
        {
            return EfDbSet.Include(r=>r.TradingSession);
        }

        public override async Task<TradingSessionDetail> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.SessionDetailId==(Int64) id);
        }

        public IEnumerable<TradingSessionDetail> GetDetailByTradingSession(long id)
        {
            return GetAll().Where(o => o.SessionNumber == id);
        }

        public async Task Insert(TradingSessionDetail tsd)
        {
            await EfDbSet.AddAsync(tsd);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(TradingSessionDetail tsd)
        {
            var entry = Context.Entry(tsd);
            if (entry.State == EntityState.Detached)
            {
                var attachedTSd = await GetById(tsd.SessionDetailId);
                if (attachedTSd != null)
                {
                    Context.Entry(attachedTSd).CurrentValues.SetValues(tsd);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface ITradingSessionDetailRepository
    {
        Task Insert(TradingSessionDetail tsd);
        Task Update(TradingSessionDetail tsd);
        void Delete(TradingSessionDetail tsd);
        void Save();
    }
}
