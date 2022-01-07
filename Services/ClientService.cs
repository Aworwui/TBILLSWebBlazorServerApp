using System;
using System.Collections.Generic;
using System.Data;
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
    public class ClientService: IClientService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public ClientService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var id = await Get(keys);
                    var repository = new ClientRepository(context);
                    repository.Delete(id);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Client");
                }
            }
        }

        public async Task<Client> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                decimal id;
                decimal.TryParse(keys[0].ToString(), out id);
                var repository = new ClientRepository(context);
                return await repository.GetById(id);
            }
        }

        public async Task<Client> GetClient(decimal clientID)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientRepository(context);
                return await repository.GetById(clientID);
            }
        }

        public ItemsDTO<Client> GetClientGridRows(Action<IGridColumnCollection<Client>> columns, QueryDictionary<StringValues> query)
        {
            using var context = new TBILLSGBContext(_options);
            var repository = new ClientRepository(context);
            var server = new GridCoreServer<Client>(repository.GetAll(), new QueryCollection(query), true, "clientGrid", columns, 25)
                .Sortable()
                .Filterable()
                .Searchable(true, false, false)
                .WithMultipleFilters()
                .ChangePageSize(true);
            return server.ItemsToDisplay;
        }

        public ItemsDTO<Client> GetClientGridRows(QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientRepository(context);
                var server = new GridCoreServer<Client>(repository.GetAll(), query, true, "clientGrid", null)
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

        public ItemsDTO<Client> GetClientWithErrorGridRows(Action<IGridColumnCollection<Client>> columns, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientRepository(context);
                var server = new GridCoreServer<Client>(repository.GetAll(), query, true, "clientGrid", columns)
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

        public async Task Insert(Client item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("CLTERR-01", e);
                }
            }
        }

        public async Task Update(Client item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Client client)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientRepository(context);
                await repository.Update(client);
                repository.Save();
            }
        }
    }
}
