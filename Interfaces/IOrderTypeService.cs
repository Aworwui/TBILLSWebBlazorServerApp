using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IOrderTypeService : ICrudDataService<OrderType>
    {
        public ItemsDTO<OrderType> GetOrderTypeGridRows(Action<IGridColumnCollection<OrderType>> columns, QueryDictionary<StringValues> query);
        Task<OrderType> GetOrderType(int id);
        Task UpdateAndSave(OrderType orderType);
        public IEnumerable<SelectItem> GetAllOrderTypes();
    }
}
