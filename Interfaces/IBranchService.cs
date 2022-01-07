using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IBranchService : ICrudDataService<Branch>
    {

        IEnumerable<SelectItem> GetAllBranches();
        public ItemsDTO<Branch> GetClientAccountGridRows(Action<IGridColumnCollection<Branch>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<Branch> GetBranch(int id);
        Task UpdateAndSave(Branch branch);

    }
}
