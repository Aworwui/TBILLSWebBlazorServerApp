using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Entities;


namespace TBILLSWebBlazorServerApp.Repositories
{
    public class AssetTypeRepository : SqlRepository<AssetType>, IAssetTypeRepository
    {
        public AssetTypeRepository(TBILLSGBContext context)
            : base(context)
        { }

        public void Delete(AssetType assetType)
        {
            EfDbSet.Remove(assetType);
        }

        public async override Task<AssetType> GetById(object id)
        {
            return await GetAll().FirstOrDefaultAsync(o => o.AssetTypeNo == (int)id);
        }

        public async Task Insert(AssetType assetType)
        {
            await EfDbSet.AddAsync(assetType);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task Update(AssetType assetType)
        {
            var entry = Context.Entry(assetType);
            if (entry.State == EntityState.Detached)
            {
                var attachedOrder = await GetById(assetType.AssetTypeNo);
                if (attachedOrder != null)
                {
                    Context.Entry(attachedOrder).CurrentValues.SetValues(assetType);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public override IQueryable<AssetType> GetAll()
        {
            return EfDbSet;
        }
    }

    public interface IAssetTypeRepository
        {
            Task Insert(AssetType assetType);
            Task Update(AssetType assetType);
            void Delete(AssetType assetType);
            void Save();
        }
}