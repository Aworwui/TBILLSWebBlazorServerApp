using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GridCore.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;
using TBILLSWebBlazorServerApp.Interfaces;
using TBILLSWebBlazorServerApp.Repositories;

namespace TBILLSWebBlazorServerApp.Data
{
    public class ClientCategoryService: IClientCategoryService
    {
        private readonly IDapperService _dapperService;

        private readonly DbContextOptions<TBILLSGBContext> _options;

        public ClientCategoryService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var ca = await Get(keys);
                    var repository = new ClientCategoryRepository(context);
                    repository.Delete(ca);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Client Account Type");
                }
            }
        }

        public async Task<ClientCategory> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int ca_id;
                int.TryParse(keys[0].ToString(), out ca_id);
                var repository = new ClientCategoryRepository(context);
                return await repository.GetById(ca_id);
            }
        }

        public IEnumerable<SelectItem> GetAllClientCategory()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientCategoryRepository(context);
                return repository.GetAll().Select(r => new SelectItem(r.ClientCategoryNo.ToString(), r.ClientCategoryNo.ToString() + " - " + r.ClientCategory1.ToString()))
                    .ToList();

            }
        }

        public async Task<ClientCategory> GetClientCategory(int id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientCategoryRepository(context);
                return await repository.GetById(id);
            }
        }

        public ItemsDTO<ClientCategory> GetClientCategoryGridRows(Action<IGridColumnCollection<ClientCategory>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientCategoryRepository(context);
                var server = new GridCoreServer<ClientCategory>(repository.GetAll(), new QueryCollection(query), true, "clientCategoryGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(ClientCategory item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientCategoryRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("CCATXRV-01", e);
                }
            }
        }

        public async Task Update(ClientCategory item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientCategoryRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(ClientCategory clientCategory)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientCategoryRepository(context);
                await repository.Update(clientCategory);
                repository.Save();
            }
        }
    }
}
