using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface ITradingSessionService : ICrudDataService<TradingSession>
    {
        public ItemsDTO<TradingSession> GetTradingSessionGridRows(Action<IGridColumnCollection<TradingSession>> columns, QueryDictionary<StringValues> query);
        Task<TradingSession> GetTradingSession(Int64 sessionNrmber);
        Task UpdateAndSave(TradingSession tradingSession);
        ItemsDTO<TradingSession> GetTradingSessionGridRows(QueryDictionary<StringValues> query);
        ItemsDTO<TradingSession> GetTradingSessionWithErrorGridRows(Action<IGridColumnCollection<TradingSession>> columns, QueryDictionary<StringValues> query);
        IEnumerable<SelectItem> GetAllSessionNumbers();
    }
}
