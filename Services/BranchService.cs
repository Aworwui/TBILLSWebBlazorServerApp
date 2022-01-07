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
    public class BranchService: IBranchService
    {
        private readonly IDapperService _dapperService;

        private readonly DbContextOptions<TBILLSGBContext> _options;

        public BranchService(DbContextOptions<TBILLSGBContext> options)
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
                    var repository = new BranchRepository(context);
                    repository.Delete(ca);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Branch");
                }
            }
        }

        public async Task<Branch> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int ca_id;
                int.TryParse(keys[0].ToString(), out ca_id);
                var repository = new BranchRepository(context);
                return await repository.GetById(ca_id);
            }
        }

        public IEnumerable<SelectItem> GetAllBranches()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new BranchRepository(context);
                return repository.GetAll().Select(r => new SelectItem(r.BranchId.ToString(), r.BranchId.ToString() + " - " + r.Branch1.ToString()))
                    .ToList();

            }
        }

        public async Task<Branch> GetBranch(int id)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new BranchRepository(context);
                return await repository.GetById(id);
            }
        }

        public ItemsDTO<Branch> GetClientAccountGridRows(Action<IGridColumnCollection<Branch>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new BranchRepository(context);
                var server = new GridCoreServer<Branch>(repository.GetAll(), new QueryCollection(query), true, "branchGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(Branch item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new BranchRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("BRHRV-01", e);
                }
            }
        }

        public async Task Update(Branch item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new BranchRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Branch branch)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new BranchRepository(context);
                await repository.Update(branch);
                repository.Save();
            }
        }
    }
}
