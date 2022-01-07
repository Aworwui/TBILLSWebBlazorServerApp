using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IInstructionService : ICrudDataService<Instruction>
    {
        public ItemsDTO<Instruction> GetInstructionGridRows(Action<IGridColumnCollection<Instruction>> columns, QueryDictionary<StringValues> query);
        Task<Instruction> GetInstruction(int taxid);
        Task UpdateAndSave(Instruction instruction);
        public IEnumerable<SelectItem> GetAllInstructions();
    }
}
