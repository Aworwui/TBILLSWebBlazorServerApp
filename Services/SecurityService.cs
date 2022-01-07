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
    public class SecurityService : ISecurityService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public SecurityService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var securityid = await Get(keys);
                    var repository = new SecurityRepository(context);
                    repository.Delete(securityid);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Securities");
                }
            }
        }

        public async Task<Security> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int securityid;
                int.TryParse(keys[0].ToString(), out securityid);
                var repository = new SecurityRepository(context);
                return await repository.GetById(securityid);
            }
        }

        public async Task<Security> GetSecurity(int taxid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new SecurityRepository(context);
                return await repository.GetById(taxid);
            }
        }

        public IEnumerable<SelectItem> GetAllAssetType()
        {
            using (var context =  new TBILLSGBContext(_options))
            {
                AssetTypeRepository repository = new AssetTypeRepository(context);
                return  repository.GetAll()
                    .Select(r => new SelectItem(r.AssetTypeNo.ToString(), r.AssetTypeNo.ToString() + " - " + r.AssetType1))
                    .ToList();
            }
        }

        public ItemsDTO<Security> GetSecurityGridRows(Action<IGridColumnCollection<Security>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new SecurityRepository(context);
                var server = new GridCoreServer<Security>(repository.GetAll(), new QueryCollection(query), true, "securityGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(Security item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new SecurityRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ISSXRV-01", e);
                }
            }
        }

        public async Task Update(Security item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new SecurityRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Security security)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new SecurityRepository(context);
                await repository.Update(security);
                repository.Save();
            }
        }

        public  IEnumerable<SelectItem> GetAllSecurities()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new SecurityRepository(context);
                return repository.GetAll().Select(r => new SelectItem(r.SecurityNo.ToString(), r.SecurityNo.ToString() + " - " + r.SecurityDescription.ToString()))
                    .ToList();
                
            }
        }
    }
}
