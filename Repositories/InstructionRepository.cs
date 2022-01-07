using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Repositories
{
    public class InstructionRepository : SqlRepository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(Instruction instruction)
        {
            EfDbSet.Remove(instruction);
        }

        public override IQueryable<Instruction> GetAll()
        {
            return EfDbSet;
        }

        public async override Task<Instruction> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.InstructionNo == (int)id);
        }

        public async Task Insert(Instruction instruction)
        {
            await EfDbSet.AddAsync(instruction);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(Instruction instruction)
        {
            var entry = Context.Entry(instruction);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(instruction.InstructionNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(instruction);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }

    public interface IInstructionRepository
    {
        Task Insert(Instruction instruction);
        Task Update(Instruction instruction);
        void Delete(Instruction instruction);
        void Save();
    }
}
