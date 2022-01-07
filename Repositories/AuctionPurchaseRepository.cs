using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class AuctionPurchaseRepository : SqlRepository<AuctionPurchase>, IAuctionPurchaseRepository
    {
        public AuctionPurchaseRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(AuctionPurchase auctionPurchase)
        {
            EfDbSet.Remove(auctionPurchase);
        }

        public async override Task<AuctionPurchase> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.AuctionId == (long)id);
        }

        public override IQueryable<AuctionPurchase> GetAll()
        {
            return EfDbSet.Include(r=>r.TradingSession).Include(s=>s.Security);
        }

        public async Task Insert(AuctionPurchase auctionPurchase)
        {
            await EfDbSet.AddAsync(auctionPurchase);
        }

        public IEnumerable<AuctionPurchase> GetAuctionPurchaseByTradingSessionNumber(long id)
        {
            return GetAll().Where(o => o.SessionNumber == id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(AuctionPurchase auctionPurchase)
        {
            var entry = Context.Entry(auctionPurchase);
            if (entry.State == EntityState.Detached)
            {
                var ap = await GetById(auctionPurchase.AuctionId);
                if (ap != null)
                {
                    Context.Entry(ap).CurrentValues.SetValues(auctionPurchase);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IAuctionPurchaseRepository
    {
        public IQueryable<AuctionPurchase> GetAll();
        Task Insert(AuctionPurchase auctionPurchase);
        Task Update(AuctionPurchase auctionPurchase);
        void Delete(AuctionPurchase auctionPurchase);
        void Save();
    }
}
