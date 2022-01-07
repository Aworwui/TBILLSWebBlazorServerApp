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
using TBILLSWebBlazorServerApp.reports;
using TBILLSWebBlazorServerApp.Repositories;

namespace TBILLSWebBlazorServerApp.Services
{
    public class ClientAccountService: IClientAccountService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public ClientAccountService(DbContextOptions<TBILLSGBContext> options)
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
                    var repository = new ClientAccountRepository(context);
                    repository.Delete(ca);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Client Account");
                }
            }
        }

        public async Task<ClientAccount> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long ca_id;
                long.TryParse(keys[0].ToString(), out ca_id);
                var repository = new ClientAccountRepository(context);
                return await repository.GetById(ca_id);
            }
        }

        public IEnumerable<SelectItem> GetAllClinetAccounts()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                ClientAccountRepository repository = new ClientAccountRepository(context);
                return repository.GetAll()
                    .Select(r => new SelectItem(r.AcctNo.ToString(), r.AccountNumber.ToString() + " - " + r.AccountName)).ToList();
            }
        }

        public async Task<ClientAccount> GetClientAccount(int ca_id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientAccountRepository(context);
                return await repository.GetById(ca_id);
            }
        }

        public ItemsDTO<ClientAccount> GetClientAccountGridRows(Action<IGridColumnCollection<ClientAccount>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientAccountRepository(context);
                var server = new GridCoreServer<ClientAccount>(repository.GetAll(), new QueryCollection(query), true, "caGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(ClientAccount item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientAccountRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("CAATXRV-01", e);
                }
            }
        }

        public async Task Update(ClientAccount item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new ClientAccountRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(ClientAccount ca)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new ClientAccountRepository(context);
                await repository.Update(ca);
                repository.Save();
            }
        }
    }
}
