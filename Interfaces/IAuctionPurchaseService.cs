using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IAuctionPurchaseService : ICrudDataService<AuctionPurchase>
    {
        public ItemsDTO<AuctionPurchase> GetAuctionPurchaseGridRows(Action<IGridColumnCollection<AuctionPurchase>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<AuctionPurchase> GetAuctionPurchase(Int64 ap_id);
        Task UpdateAndSave(AuctionPurchase auctionPurchase);
        ItemsDTO<AuctionPurchase> GetAuctionPurchaseGridRows(object[] keys, QueryDictionary<StringValues> query);
        ItemsDTO<AuctionPurchase> GetAuctionPurchaseWithErrorGridRows(Action<IGridColumnCollection<AuctionPurchase>> columns, object[] keys, QueryDictionary<StringValues> query);
    }
}
