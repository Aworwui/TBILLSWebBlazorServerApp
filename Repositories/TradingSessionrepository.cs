using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class TradingSessionRepository : SqlRepository<TradingSession>, ITradingSessionRepository
    {
        public TradingSessionRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(TradingSession tradingSession)
        {
            EfDbSet.Remove(tradingSession);
        }

        public override IQueryable<TradingSession> GetAll()
        {
            return EfDbSet.Include(o=>o.TradingSessionDetails).Include(a=>a.Allotments).Include(r=>r.AuctionPurchases).OrderByDescending(z=>z.SessionNumber);
        }
        public override async Task<TradingSession> GetById(object Id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.SessionNumber == (int)Id);
        }

        public async Task Insert(TradingSession tradingSession)
        {
            await EfDbSet.AddAsync(tradingSession);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(TradingSession tradingSession)
        {
            var entry = Context.Entry(tradingSession);
            if (entry.State == EntityState.Detached)
            {
                var attachedTS = await GetById(tradingSession.SessionNumber);
                if (attachedTS != null)
                {
                    Context.Entry(attachedTS).CurrentValues.SetValues(tradingSession);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface ITradingSessionRepository
    {
        Task Insert(TradingSession tradingSession);
        Task Update(TradingSession tradingSession);
        void Delete(TradingSession tradingSession);
        void Save();
    }
}