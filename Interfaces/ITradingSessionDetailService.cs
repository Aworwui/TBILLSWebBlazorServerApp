using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface ITradingSessionDetailService : ICrudDataService<TradingSessionDetail>
    {
        public ItemsDTO<TradingSessionDetail> GetTradingSessionDetailGridRows(Action<IGridColumnCollection<TradingSessionDetail>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<TradingSessionDetail> GetTradingSessionDetail(Int64 sessionNrmber);
        Task UpdateAndSave(TradingSessionDetail tradingSession);
        ItemsDTO<TradingSessionDetail> GetTradingSessionDetailGridRows(object[] keys, QueryDictionary<StringValues> query);
        ItemsDTO<TradingSessionDetail> GetTSDWithErrorGridRows(Action<IGridColumnCollection<TradingSessionDetail>> columns, object[] keys, QueryDictionary<StringValues> query);
    }
}
