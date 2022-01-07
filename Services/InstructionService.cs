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
    public class InstructionService: IInstructionService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public InstructionService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var instructionid = await Get(keys);
                    var repository = new InstructionRepository(context);
                    repository.Delete(instructionid);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Taxation");
                }
            }
        }

        public async Task<Instruction> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                int instructionid;
                int.TryParse(keys[0].ToString(), out instructionid);
                var repository = new InstructionRepository(context);
                return await repository.GetById(instructionid);
            }
        }

        public async Task<Instruction> GetInstruction(int taxid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new InstructionRepository(context);
                return await repository.GetById(taxid);
            }
        }

        public ItemsDTO<Instruction> GetInstructionGridRows(Action<IGridColumnCollection<Instruction>> columns, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new InstructionRepository(context);
                var server = new GridCoreServer<Instruction>(repository.GetAll(), new QueryCollection(query), true, "instructionGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .Searchable(true, false, false)
                    .WithMultipleFilters()
                    .ChangePageSize(true);

                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(Instruction item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new InstructionRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("ISTXRV-01", e);
                }
            }
        }

        public async Task Update(Instruction item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new InstructionRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(Instruction instruction)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new InstructionRepository(context);
                await repository.Update(instruction);
                repository.Save();
            }
        }

        public IEnumerable<SelectItem> GetAllInstructions()
        {
            using (var context = new TBILLSGBContext(_options))
            {
                InstructionRepository repository = new InstructionRepository(context);
                return repository.GetAll()
                    .Select(r => new SelectItem(r.InstructionNo.ToString(), r.InstructionNo.ToString() + " - " + r.Instruction1))
                    .ToList();
            }
        }
    }
}
