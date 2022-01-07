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
    public class PaymentVoucherDetailService : IPaymentVoucherDetailService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public PaymentVoucherDetailService(DbContextOptions<TBILLSGBContext> options)
        {
            _options = options;
        }

        public async Task Delete(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var pv = await Get(keys);
                    var repository = new PaymentVoucherDetailRepository(context);
                    repository.Delete(pv);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Payment Voucher Detail");
                }
            }
        }

        public async Task<PaymentVoucherDetail> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long pvID;
                long.TryParse(keys[0].ToString(), out pvID);
                var repository = new PaymentVoucherDetailRepository(context);
                return await repository.GetById(pvID);
            }
        }

        public async Task<PaymentVoucherDetail> GetPaymentVoucherDetail(long pvDetailID)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherDetailRepository(context);
                return await repository.GetById(pvDetailID);
            }
        }

        public ItemsDTO<PaymentVoucherDetail> GetPaymentVoucherDetailGridRows(Action<IGridColumnCollection<PaymentVoucherDetail>> columns, object[] keys, QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long pvID;
                long.TryParse(keys[0].ToString(), out pvID);
                var repository = new PaymentVoucherDetailRepository(context);
                var server = new GridCoreServer<PaymentVoucherDetail>(repository.GetpvDetailByPaymentVoucherID(pvID), new QueryCollection(query), true, "pvDetailGrid", columns, 25)
                    .Sortable()
                    .Filterable()
                    .Searchable();
                return server.ItemsToDisplay;
            }
        }

        public async Task Insert(PaymentVoucherDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new PaymentVoucherDetailRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("PVDSRV-01", e);
                }
            }
        }

        public async Task Update(PaymentVoucherDetail item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new PaymentVoucherDetailRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(PaymentVoucherDetail pvDetail)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherDetailRepository(context);
                await repository.Update(pvDetail);
                repository.Save();
            }
        }
    }
}
