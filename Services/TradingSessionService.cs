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
    public class TradingSessionService: ITradingSessionService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public TradingSessionService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var ts = await Get(keys);
                    var repository = new TradingSessionRepository(context);
                    repository.Delete(ts);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Trading Session");
                }
            }
        }

        public async Task<TradingSession> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int sessionNumber;
                int.TryParse(keys[0].ToString(), out sessionNumber);
                var repository = new TradingSessionRepository(context);
                return await repository.GetById(sessionNumber);
            }
        }

        public ItemsDTO<TradingSession> GetTradingSessionGridRows(Action<IGridColumnCollection<TradingSession>> columns, QueryDictionary<StringValues> query)
        {
            using var context = new TBILLSGBContext(_options);
            var repository = new TradingSessionRepository(context);
            var server = new GridCoreServer<TradingSession>(repository.GetAll(), new QueryCollection(query), true, "tsGrid", columns, 25)
                .Sortable()
                .Filterable()
                .Searchable(true, false, false)
                .WithMultipleFilters()
                .ChangePageSize(true);

            return server.ItemsToDisplay;
        }

        public ItemsDTO<TradingSession> GetTradingSessionGridRows(QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionRepository(context);
                var server = new GridCoreServer<TradingSession>(repository.GetAll(), query, true, "tsGrid", null)
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

        public ItemsDTO<TradingSession> GetTradingSessionWithErrorGridRows(Action<IGridColumnCollection<TradingSession>> columns, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionRepository(context);
                var server = new GridCoreServer<TradingSession>(repository.GetAll(), query, true, "tsGrid", columns)
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

        public async Task<TradingSession> GetTradingSession(long sessionNrmber)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionRepository(context);
                return await repository.GetById(sessionNrmber);
            }
        }

        public async Task Insert(TradingSession item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TradingSessionRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("TSSRV-01", e);
                }
            }
        }

        public async Task Update(TradingSession item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TradingSessionRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(TradingSession tradingSession)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionRepository(context);
                await repository.Update(tradingSession);
                repository.Save();
            }
        }

        public IEnumerable<SelectItem> GetAllSessionNumbers()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TradingSessionRepository(context);
                return repository.GetAll().OrderByDescending(z => z.SessionNumber).Select(r => new SelectItem(r.SessionNumber.ToString(), r.SessionNumber.ToString()))
                    .ToList();

            }
        }
    }
}
