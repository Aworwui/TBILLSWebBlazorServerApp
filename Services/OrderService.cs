using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OrderService : IOrderService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public OrderService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var id = await Get(keys);
                    var repository = new OrderRepository(context);
                    repository.Delete(id);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Order");
                }
            }
        }

        public async Task<Order> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new OrderRepository(context);
                return await repository.GetById(id);
            }
        }

        public async Task<Order> GetOrder(decimal OrderID)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderRepository(context);
                return await repository.GetById(OrderID);
            }
        }

        public ItemsDTO<Order> GetOrderGridRows(Action<IGridColumnCollection<Order>> columns, QueryDictionary<StringValues> query)
        {
            using var context = new TBILLSGBContext(_options);
            var repository = new OrderRepository(context);
            var server = new GridCoreServer<Order>(repository.GetAll(), new QueryCollection(query), true, "orderGrid", columns, 25)
                .Sortable()
                .Filterable()
                .Searchable(true, false, false)
                .WithMultipleFilters()
                .ChangePageSize(true);
            return server.ItemsToDisplay;
        }

        public ItemsDTO<Order> GetOrderGridRows(QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderRepository(context);
                var server = new GridCoreServer<Order>(repository.GetAll(), query, true, "orderGrid", null)
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

        public  List<OrderReportType> GetOrderReportTypeByOrderID(long orderID)
        {
            List<OrderReportType> ord = new();
            using (var context = new TBILLSGBContext(_options))
            {
                ord =  context.OrderReportTypes.Where(a => a.OrderId == orderID).ToList();
                return ord;
            }
        }

        public List<OrderReportType> GetOrderReportTypeBySessionNum(long sessionNumber)
        {
            List<OrderReportType> ord = new();
            using (var context = new TBILLSGBContext(_options))
            {
                ord = context.OrderReportTypes.Where(a => a.OrderId == sessionNumber).ToList();
                return ord;
            }
        }

        public ItemsDTO<Order> GetOrderWithErrorGridRows(Action<IGridColumnCollection<Order>> columns, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderRepository(context);
                var server = new GridCoreServer<Order>(repository.GetAll(), query, true, "orderGrid", columns)
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

        public async Task Insert(Order item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ORDERV-01", e);
                }
            }
        }

        public async Task Update(Order item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Order order)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderRepository(context);
                await repository.Update(order);
                repository.Save();
            }
        }
    }
}
