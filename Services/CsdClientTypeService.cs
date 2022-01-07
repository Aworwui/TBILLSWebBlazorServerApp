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
    public class CsdClientTypeService : ICsdClientTypeService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public CsdClientTypeService(DbContextOptions <TBILLSGBContext> options)
        {
            _options = options;
        }

        public ItemsDTO<CsdClientType> GetCsdClientTypesGridRows(Action<IGridColumnCollection<CsdClientType>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new CsdClientTypeRepository(context);
                var server = new GridCoreServer<CsdClientType>(repository.GetAll(), new QueryCollection(query), true, "csdClientTypeGrid", columns,10)
                    .Sortable()
                    .Filterable()
                    .Searchable();
               return server.ItemsToDisplay;
              
            }
        }

        public ItemsDTO<CsdClientType> GetCsdClientTypesGridRows(QueryDictionary<StringValues> query)

        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new CsdClientTypeRepository(context);
                var server = new GridCoreServer<CsdClientType>(repository.GetAll(), new QueryCollection(query), false, "CsdClientTypeGrid", null).AutoGenerateColumns()
                    .Sortable()
                    .Filterable()
                    .Searchable();

                return server.ItemsToDisplay;
            }
        }

        public async Task<CsdClientType> GetCsdClientType(int csdClientTypeNo)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new CsdClientTypeRepository(context);
                return await repository.GetById(csdClientTypeNo);
            }
        }

        public async Task UpdateAndSave(CsdClientType csdClientType)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new CsdClientTypeRepository(context);
                await repository.Update(csdClientType);
                repository.Save();
            }
        }

        public async Task<CsdClientType> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int csdClientTypeNo;
                int.TryParse(keys[0].ToString(), out csdClientTypeNo);
                var repository = new CsdClientTypeRepository(context);
                return await repository.GetById(csdClientTypeNo);
            }
        }

        public async Task Insert(CsdClientType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new CsdClientTypeRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ORDSRV-01", e);
                }
            }
        }

        public async Task Update(CsdClientType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new CsdClientTypeRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var csdClientType = await Get(keys);
                    var repository = new CsdClientTypeRepository(context);
                    repository.Delete(csdClientType);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Csd Client Type");
                }
            }
        }
    }
}
