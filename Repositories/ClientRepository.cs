using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class ClientRepository : SqlRepository<Client>, IClientRepository
    {
        public ClientRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Client client)
        {
            EfDbSet.Remove(client);
        }

        public override IQueryable<Client> GetAll()
        {
            return EfDbSet.Include(a => a.ClientAccounts).Include(r=>r.ClientTypeNoNavigation).Include(c=>c.ClientCategoryNoNavigation)
                .Include(o=>o.CsdClientTypeNoNavigation).OrderByDescending(a => a.ClientId);
        }

        public async override Task<Client> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.ClientId == (decimal)id);
        }

        public async Task Insert(Client client)
        {
            await EfDbSet.AddAsync(client);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Client client)
        {
            var entry = Context.Entry(client);
            if (entry.State == EntityState.Detached)
            {
                var attachedTS = await GetById(client.ClientId);
                if (attachedTS != null)
                {
                    Context.Entry(attachedTS).CurrentValues.SetValues(client);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IClientRepository
    {
        Task Insert(Client client);
        Task Update(Client client);
        void Delete(Client client);
        void Save();
    }
}