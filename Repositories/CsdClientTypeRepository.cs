using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class CsdClientTypeRepository : SqlRepository<CsdClientType>, ICsdClientTypeRepository
    {
        public CsdClientTypeRepository(TBILLSGBContext context)
            : base(context)
        { }

        public override IQueryable<CsdClientType> GetAll()
        {
            return EfDbSet;
        }

        public override async Task<CsdClientType> GetById(object Id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.CsdClientTypeNo == (int)Id);
        }

        public void Delete(CsdClientType csdClientType)
        {
            EfDbSet.Remove(csdClientType);
        }

        public async Task Insert(CsdClientType csdClientType)
        {
             await EfDbSet.AddAsync(csdClientType);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(CsdClientType csdClientType)
        {
            var entry = Context.Entry(csdClientType);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(csdClientType.CsdClientTypeNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(csdClientType);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface ICsdClientTypeRepository
    {
        Task Insert(CsdClientType csdClientType);
        Task Update(CsdClientType csdClientType);
        void Delete(CsdClientType csdClientType);
        void Save();
    }
}
