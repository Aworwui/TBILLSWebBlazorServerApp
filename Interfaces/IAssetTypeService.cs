using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IAssetTypeService : ICrudDataService<AssetType>
    {
        public ItemsDTO<AssetType> GetTaxationGridRows(Action<IGridColumnCollection<AssetType>> columns, QueryDictionary<StringValues> query);
        Task<AssetType> GetAssetType(int taxid);
        Task UpdateAndSave(AssetType assetType);
    }

}
