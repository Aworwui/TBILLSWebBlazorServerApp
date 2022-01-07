using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IOrderService : ICrudDataService<Order>
    {
        public ItemsDTO<Order> GetOrderGridRows(Action<IGridColumnCollection<Order>> columns, QueryDictionary<StringValues> query);
        Task<Order> GetOrder(decimal OrderID);
        Task UpdateAndSave(Order order);
        ItemsDTO<Order> GetOrderGridRows(QueryDictionary<StringValues> query);
        ItemsDTO<Order> GetOrderWithErrorGridRows(Action<IGridColumnCollection<Order>> columns, QueryDictionary<StringValues> query);
        public List<OrderReportType> GetOrderReportTypeBySessionNum(long sessionNumber);
        public List<OrderReportType> GetOrderReportTypeByOrderID(long orderID);
    }
}
