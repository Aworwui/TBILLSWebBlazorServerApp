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
    public class OrderTypeService : IOrderTypeService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public OrderTypeService(DbContextOptions<TBILLSGBContext> options)
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
                    var repository = new OrderTypeRepository(context);
                    repository.Delete(id);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Order Type");
                }
            }
        }

        public async Task<OrderType> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int id;
                int.TryParse(keys[0].ToString(), out id);
                var repository = new OrderTypeRepository(context);
                return await repository.GetById(id);
            }
        }

        public async Task<OrderType> GetOrderType(int id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderTypeRepository(context);
                return await repository.GetById(id);
            }
        }

        public ItemsDTO<OrderType> GetOrderTypeGridRows(Action<IGridColumnCollection<OrderType>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderTypeRepository(context);
                var server = new GridCoreServer<OrderType>(repository.GetAll(), new QueryCollection(query), true, "orderTypeGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(OrderType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderTypeRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ORDTXRV-01", e);
                }
            }
        }

        public async Task Update(OrderType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new OrderTypeRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(OrderType orderType)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new OrderTypeRepository(context);
                await repository.Update(orderType);
                repository.Save();
            }
        }

        public IEnumerable<SelectItem> GetAllOrderTypes()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                OrderTypeRepository repository = new OrderTypeRepository(context);
                return repository.GetAll()
                    .Select(r => new SelectItem(r.OrderTypeNo.ToString(), r.OrderTypeNo.ToString() + " - " + r.OrderType1))
                    .ToList();
            }
        }
    }
}
