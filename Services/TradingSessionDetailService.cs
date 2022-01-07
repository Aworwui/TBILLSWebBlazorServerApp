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
    public class TradingSessionDetailService : ITradingSessionDetailService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public TradingSessionDetailService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var tsd = await Get(keys);
                    var repository = new TradingSessionDetailRepository(context);
                    repository.Delete(tsd);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Trading Session Detail");
                }
            }
        }

        public async Task<TradingSessionDetail> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumberDetID;
                long.TryParse(keys[0].ToString(), out sessionNumberDetID);
                var repository = new TradingSessionDetailRepository(context);
                return await repository.GetById(sessionNumberDetID);
            }
        }

        public ItemsDTO<TradingSessionDetail> GetTradingSessionDetailGridRows(Action<IGridColumnCollection<TradingSessionDetail>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumberDetID;
                long.TryParse(keys[0].ToString(), out sessionNumberDetID);
                var repository = new TradingSessionDetailRepository(context);
                var server = new GridCoreServer<TradingSessionDetail>(repository.GetDetailByTradingSession(sessionNumberDetID), new QueryCollection(query), true, "tsdGrid", columns, 25)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task<TradingSessionDetail> GetTradingSessionDetail(long sessionNrmber)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionDetailRepository(context);
                return await repository.GetById(sessionNrmber);
            }
        }

        public async Task Insert(TradingSessionDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TradingSessionDetailRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("TSDSRV-01", e);
                }
            }
        }

        public async Task Update(TradingSessionDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TradingSessionDetailRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(TradingSessionDetail tradingSession)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionDetailRepository(context);
                await repository.Update(tradingSession);
                repository.Save();
            }
        }

        public ItemsDTO<TradingSessionDetail> GetTSDWithErrorGridRows(Action<IGridColumnCollection<TradingSessionDetail>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long sessionNumberDetID;
                long.TryParse(keys[0].ToString(), out sessionNumberDetID);
                var repository = new TradingSessionDetailRepository(context);
                var server = new GridCoreServer<TradingSessionDetail>(repository.GetDetailByTradingSession(sessionNumberDetID), new QueryCollection(query), true, "tsdGrid", columns, 25)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<TradingSessionDetail> GetTradingSessionDetailGridRows(object[] keys,QueryDictionary<StringValues> query)
        {
            long sessionNumberDetID;
            long.TryParse(keys[0].ToString(), out sessionNumberDetID);
            using var context = new TBILLSGBContext(_options);
            var repository = new TradingSessionDetailRepository(context);
            var server = new GridCoreServer<TradingSessionDetail>(repository.GetDetailByTradingSession(sessionNumberDetID), query, true, "tsdGrid", null)
                    .AutoGenerateColumns()
                    .Sortable()
                    .WithPaging(25)
                    .Filterable()
                    .WithMultipleFilters()
                    .Groupable(true)
                    .Searchable(true, false, false);

            // return items to displays
            return server.ItemsToDisplay;
        }
    }
}
