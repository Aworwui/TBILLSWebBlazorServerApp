using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IAllotmentService: ICrudDataService<Allotment>
    {
        public ItemsDTO<Allotment> GetCsdClientTypesGridRows(Action<IGridColumnCollection<Allotment>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<Allotment> GetAllotment(Int64 allotmentid);
        Task UpdateAndSave(Allotment tradingSession);
        ItemsDTO<Allotment> GetAllotmentGridRows(Action<IGridColumnCollection<Allotment>> columns, QueryDictionary<StringValues> query);
        ItemsDTO<Allotment> GetOrdersWithErrorGridRows(Action<IGridColumnCollection<Allotment>> columns, object[] keys, QueryDictionary<StringValues> query);
    }
}
