using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface ITaxationService : ICrudDataService<Taxation>
    {
        public ItemsDTO<Taxation> GetTaxationGridRows(Action<IGridColumnCollection<Taxation>> columns, QueryDictionary<StringValues> query);
        Task<Taxation> GetTaxation(int taxid);
        Task UpdateAndSave(Taxation taxation);
    }
}
