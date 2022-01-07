using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class BranchRepository : SqlRepository<Branch>, IBranchRepository
    {
        public BranchRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Branch branch)
        {
            EfDbSet.Remove(branch);
        }

        public async override Task<Branch> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.BranchId == (int)id);
        }

        public async Task Insert(Branch branch)
        {
            await EfDbSet.AddAsync(branch);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Branch branch)
        {
            var entry = Context.Entry(branch);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(branch.BranchId);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(branch);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override IQueryable<Branch> GetAll()
        {
            return EfDbSet;
        }
    }

    public interface IBranchRepository
    {
        Task Insert(Branch branch);
        Task Update(Branch branch);
        void Delete(Branch branch);
        void Save();
    }
}
