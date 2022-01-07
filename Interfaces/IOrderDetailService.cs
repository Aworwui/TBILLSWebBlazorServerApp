using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IOrderDetailService : ICrudDataService<OrderDetail>
    {
        public ItemsDTO<OrderDetail> GetOrderDetailsGridRows(Action<IGridColumnCollection<OrderDetail>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<OrderDetail> GetOrderDetail(decimal orderDetailid);
        Task UpdateAndSave(OrderDetail orderDetail);
        ItemsDTO<OrderDetail> GetOrderDetailsGridRows(object[] keys, QueryDictionary<StringValues> query);
        ItemsDTO<OrderDetail> GetOrderDetailsWithErrorGridRows(Action<IGridColumnCollection<OrderDetail>> columns, object[] keys, QueryDictionary<StringValues> query);
    }
}
