using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class ClientAccountRepository : SqlRepository<ClientAccount>, IClientAccountRepository
    {
        public ClientAccountRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(ClientAccount cAccount)
        {
            EfDbSet.Remove(cAccount);
        }

        public override IQueryable<ClientAccount> GetAll()
        {
            return EfDbSet;
        }

        public async override Task<ClientAccount> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.ClientAcctId == (long)id);
        }

        public async Task Insert(ClientAccount cAccount)
        {
            await EfDbSet.AddAsync(cAccount);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(ClientAccount cAccount)
        {
            var entry = Context.Entry(cAccount);
            if (entry.State == EntityState.Detached)
            {
                var ca = await GetById(cAccount.ClientAcctId);
                if (ca != null)
                {
                    Context.Entry(ca).CurrentValues.SetValues(cAccount);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IClientAccountRepository
    {
        Task Insert(ClientAccount cAccount);
        Task Update(ClientAccount cAccount);
        void Delete(ClientAccount cAccount);
        void Save();
    }
}
