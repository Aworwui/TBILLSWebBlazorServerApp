using System;
using System.Threading.Tasks;
using GridCore.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;
using TBILLSWebBlazorServerApp.Interfaces;
using TBILLSWebBlazorServerApp.Repositories;

namespace TBILLSWebBlazorServerApp.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public OrderDetailService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var orderDetail = await Get(keys);
                    var repository = new OrderDetailRepository(context);
                    repository.Delete(orderDetail);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Order Detail");
                }
            }
        }

        public async Task<OrderDetail> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new OrderDetailRepository(context);
                return await repository.GetById(id);
            }
        }

        public async Task<OrderDetail> GetOrderDetail(decimal orderDetailid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderDetailRepository(context);
                return await repository.GetById(orderDetailid);
            }
        }

        public ItemsDTO<OrderDetail> GetOrderDetailsGridRows(Action<IGridColumnCollection<OrderDetail>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new OrderDetailRepository(context);
                var server = new GridCoreServer<OrderDetail>(repository.GetOrderDetailByOrderID(id), new QueryCollection(query), true, "orderDetailGrid", columns, 25)
                    .Sortable()
                    .Filterable()
                    .Searchable();
                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<OrderDetail> GetOrderDetailsGridRows(object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new OrderDetailRepository(context);
                var server = new GridCoreServer<OrderDetail>(repository.GetOrderDetailByOrderID(id), query, true, "orderDetailGrid", null)
                        .AutoGenerateColumns()
                        .Sortable()
                        .WithPaging(25)
                        .Filterable()
                        .WithMultipleFilters()
                        .Groupable(true)
                        .Searchable(true, false, false);
                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<OrderDetail> GetOrderDetailsWithErrorGridRows(Action<IGridColumnCollection<OrderDetail>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new OrderDetailRepository(context);
                var server = new GridCoreServer<OrderDetail>(repository.GetOrderDetailByOrderID(id), query, true, "orderDetailGrid", columns)
                        .Sortable()
                        .WithPaging(25)
                        .Filterable()
                        .WithMultipleFilters()
                        .Groupable(true)
                        .Searchable(true, false, false);

                var items = server.ItemsToDisplay;
                return items;
            }
        }

        public async Task Insert(OrderDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderDetailRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ORDSRV-01", e);
                }
            }
        }

        public async Task Update(OrderDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderDetailRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(OrderDetail orderDetail)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderDetailRepository(context);
                await repository.Update(orderDetail);
                repository.Save();
            }
        }
    }
}
