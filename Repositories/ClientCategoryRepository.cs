using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class ClientCategoryRepository : SqlRepository<ClientCategory>, IClientCategoryRepository
    {
        public ClientCategoryRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(ClientCategory clientCat)
        {
            EfDbSet.Remove(clientCat);
        }

        public async override Task<ClientCategory> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.ClientCategoryNo == (int)id);
        }

        public async Task Insert(ClientCategory clientCat)
        {
            await EfDbSet.AddAsync(clientCat);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(ClientCategory clientCat)
        {
            var entry = Context.Entry(clientCat);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(clientCat.ClientCategoryNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(clientCat);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override IQueryable<ClientCategory> GetAll()
        {
            return EfDbSet;
        }
    }

    public interface IClientCategoryRepository
    {
        Task Insert(ClientCategory clientCat);
        Task Update(ClientCategory clientCat);
        void Delete(ClientCategory clientCat);
        void Save();
    }
}
