
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class ClientTypeRepository : SqlRepository<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(ClientType clientType)
        {
            EfDbSet.Remove(clientType);
        }

        public async override Task<ClientType> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.ClientTypeNo == (int)id);
        }

        public async Task Insert(ClientType clientType)
        {
            await EfDbSet.AddAsync(clientType);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(ClientType clientType)
        {
            var entry = Context.Entry(clientType);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(clientType.ClientTypeNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(clientType);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override IQueryable<ClientType> GetAll()
        {
            return EfDbSet;
        }
    }

    public interface IClientTypeRepository
    {
        Task Insert(ClientType clientType);
        Task Update(ClientType clientType);
        void Delete(ClientType clientType);
        void Save();
    }
}
