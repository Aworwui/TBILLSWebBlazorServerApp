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
    public class TaxationService: ITaxationService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public TaxationService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var taxid = await Get(keys);
                    var repository = new TaxationRepository(context);
                    repository.Delete(taxid);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Taxation");
                }
            }
        }

        public async Task<Taxation> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int taxid;
                int.TryParse(keys[0].ToString(), out taxid);
                var repository = new TaxationRepository(context);
                return await repository.GetById(taxid);
            }
        }

        public async Task<Taxation> GetTaxation(int taxid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TaxationRepository(context);
                return await repository.GetById(taxid);
            }
        }

        public ItemsDTO<Taxation> GetTaxationGridRows(Action<IGridColumnCollection<Taxation>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TaxationRepository(context);
                var server = new GridCoreServer<Taxation>(repository.GetAll(), new QueryCollection(query), true, "taxationGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(Taxation item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TaxationRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("TXXRV-01", e);
                }
            }
        }

        public async Task Update(Taxation item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new TaxationRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Taxation taxation)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new TaxationRepository(context);
                await repository.Update(taxation);
                repository.Save();
            }
        }
    }
}
