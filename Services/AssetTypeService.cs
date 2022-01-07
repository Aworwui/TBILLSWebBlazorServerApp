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
    public class AssetTypeService : IAssetTypeService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public AssetTypeService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var assid = await Get(keys);
                    var repository = new AssetTypeRepository(context);
                    repository.Delete(assid);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Asset Type");
                }
            }
        }

        public async Task<AssetType> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int asstid;
                int.TryParse(keys[0].ToString(), out asstid);
                var repository = new AssetTypeRepository(context);
                return await repository.GetById(asstid);
            }
        }

        public async Task<AssetType> GetAssetType(int id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AssetTypeRepository(context);
                return await repository.GetById(id);
            }
        }

        public ItemsDTO<AssetType> GetTaxationGridRows(Action<IGridColumnCollection<AssetType>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AssetTypeRepository(context);
                var server = new GridCoreServer<AssetType>(repository.GetAll(), new QueryCollection(query), true, "assetTypeGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(AssetType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AssetTypeRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ASSXRV-01", e);
                }
            }
        }

        public async Task Update(AssetType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new AssetTypeRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(AssetType assetType)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new AssetTypeRepository(context);
                await repository.Update(assetType);
                repository.Save();
            }
        }
    }
}
