using System;
using System.Collections.Generic;
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
    public class AllotmentService : IAllotmentService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public AllotmentService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var allotment = await Get(keys);
                    var repository = new AllotmentRepository(context);
                    repository.Delete(allotment);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Allotments");
                }
            }
        }

        public async Task<Allotment> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumber;
                long.TryParse(keys[0].ToString(), out sessionNumber);
                var repository = new AllotmentRepository(context);
                return await repository.GetById(sessionNumber);
            }
        }

        public ItemsDTO<Allotment> GetCsdClientTypesGridRows(Action<IGridColumnCollection<Allotment>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumber;
                long.TryParse(keys[0].ToString(), out sessionNumber);
                var repository = new AllotmentRepository(context);
                var server = new GridCoreServer<Allotment>(repository.GetAllotmentsByTradingSessionNumber(sessionNumber), new QueryCollection(query),true, "allotmentGrid", columns, 25)
                    .Sortable()
                    .Filterable()
                    .Searchable();
                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<Allotment> GetAllotmentGridRows(Action<IGridColumnCollection<Allotment>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AllotmentRepository(context);
                var server = new GridCoreServer<Allotment>(repository.GetAll(), new QueryCollection(query), true, "allotmentGrid",columns,25)
                        .Sortable()
                        .Filterable()
                        .WithMultipleFilters()
                        .Searchable(true, false, false);
                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<Allotment> GetOrdersWithErrorGridRows(Action<IGridColumnCollection<Allotment>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumber;
                long.TryParse(keys[0].ToString(), out sessionNumber);
                var repository = new AllotmentRepository(context);
                var server = new GridCoreServer<Allotment>(repository.GetAll(), query, true, "allotmentGrid", columns)
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

        public async Task<Allotment> GetAllotment(long allotmentid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AllotmentRepository(context);
                return await repository.GetById(allotmentid);
            }
        }


        public async Task Insert(Allotment item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AllotmentRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ALLSRV-01", e);
                }
            }
        }

        public async Task Update(Allotment item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AllotmentRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Allotment tradingSession)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AllotmentRepository(context);
                await repository.Update(tradingSession);
                repository.Save();
            }
        }
    }
}
