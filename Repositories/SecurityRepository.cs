using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class SecurityRepository: SqlRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Security security)
        {
            EfDbSet.Remove(security);
        }

        public override IQueryable<Security> GetAll()
        {
            return EfDbSet;
        }

        public  async override  Task<Security> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.SecurityNo == (int)id);
        }

        public async Task Insert(Security security)
        {
            await EfDbSet.AddAsync(security);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Security security)
        {
            var entry = Context.Entry(security);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(security.SecurityNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(security);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
    public interface ISecurityRepository
    {
        Task Insert(Security security);
        Task Update(Security security);
        void Delete(Security security);
        void Save();
    }
}
