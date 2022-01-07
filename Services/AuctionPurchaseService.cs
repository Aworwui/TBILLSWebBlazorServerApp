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
    public class AuctionPurchaseService : IAuctionPurchaseService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public AuctionPurchaseService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var ap = await Get(keys);
                    var repository = new AuctionPurchaseRepository(context);
                    repository.Delete(ap);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Auction Purchase");
                }
            }
        }

        public async Task<AuctionPurchase> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long ap_id;
                long.TryParse(keys[0].ToString(), out ap_id);
                var repository = new AuctionPurchaseRepository(context);
                return await repository.GetById(ap_id);
            }
        }

        public async Task<AuctionPurchase> GetAuctionPurchase(long auctionPurchase_id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AuctionPurchaseRepository(context);
                return await repository.GetById(auctionPurchase_id);
            }
        }

        public ItemsDTO<AuctionPurchase> GetAuctionPurchaseGridRows(Action<IGridColumnCollection<AuctionPurchase>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long ap_id;
                long.TryParse(keys[0].ToString(), out ap_id);
                var repository = new AuctionPurchaseRepository(context);
                var server = new GridCoreServer<AuctionPurchase>(repository.GetAuctionPurchaseByTradingSessionNumber(ap_id), new QueryCollection(query), true, "ap_Grid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public ItemsDTO<AuctionPurchase> GetAuctionPurchaseGridRows(object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long ap_id;
                long.TryParse(keys[0].ToString(), out ap_id);
                var repository = new AuctionPurchaseRepository(context);
                var server = new GridCoreServer<AuctionPurchase>(repository.GetAuctionPurchaseByTradingSessionNumber(ap_id), query, true, "ap_Grid", null)
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

        public ItemsDTO<AuctionPurchase> GetAuctionPurchaseWithErrorGridRows(Action<IGridColumnCollection<AuctionPurchase>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                long ap_id;
                long.TryParse(keys[0].ToString(), out ap_id);
                var repository = new AuctionPurchaseRepository(context);
                var server = new GridCoreServer<AuctionPurchase>(repository.GetAuctionPurchaseByTradingSessionNumber(ap_id), query, true, "ap_Grid", columns)
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

        public async Task Insert(AuctionPurchase item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AuctionPurchaseRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("AUPSRV-01", e);
                }
            }
        }

        public async Task Update(AuctionPurchase item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AuctionPurchaseRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(AuctionPurchase auctionPurchase)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AuctionPurchaseRepository(context);
                await repository.Update(auctionPurchase);
                repository.Save();
            }
        }
    }
}
