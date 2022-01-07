using System;
using System.Collections.Generic;
using System.Data;
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

namespace TBILLSWebBlazorServerApp.Data
{
    public class ClientTypeService: IClientTypeService
    {

        private readonly DbContextOptions<TBILLSGBContext> _options;

        public ClientTypeService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public IEnumerable<SelectItem> GetAllClientTypes()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientTypeRepository(context);
                return repository.GetAll()
                    .Select(r => new SelectItem(r.ClientTypeNo.ToString(), r.ClientTypeNo.ToString() + " - " + r.ClientType1)).ToList();
            }
        }

        public async Task<ClientType> GetClientType(int id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientTypeRepository(context);
                return await repository.GetById(id);
            }
        }

        public ItemsDTO<ClientType> GetClientTypeGridRows(Action<IGridColumnCollection<ClientType>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientTypeRepository(context);
                var server = new GridCoreServer<ClientType>(repository.GetAll(), new QueryCollection(query), true, "clientTypeGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task UpdateAndSave(ClientType clientType)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientTypeRepository(context);
                await repository.Update(clientType);
                repository.Save();
            }
        }

        public async Task Insert(ClientType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientTypeRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ASSXRV-01", e);
                }
            }
        }

        public async Task Update(ClientType item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientTypeRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task<ClientType> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int ca_id;
                int.TryParse(keys[0].ToString(), out ca_id);
                var repository = new ClientTypeRepository(context);
                return await repository.GetById(ca_id);
            }
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var ca = await Get(keys);
                    var repository = new ClientTypeRepository(context);
                    repository.Delete(ca);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Client Account Type");
                }
            }
        }
    }
}
