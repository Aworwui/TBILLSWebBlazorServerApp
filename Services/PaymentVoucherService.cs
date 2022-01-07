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
    public class PaymentVoucherService: IPaymentVoucherService
    {
        private readonly DbContextOptions<TBILLSGBContext> _options;

        public PaymentVoucherService(DbContextOptions<TBILLSGBContext> options)
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
                    var repository = new PaymentVoucherRepository(context);
                    repository.Delete(pv);
                    repository.Save();
                }
                catch (Exception)
                {
                    throw new GridException("Error deleting the Payment Voucher");
                }
            }
        }

        public async Task<PaymentVoucher> Get(params object[] keys)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                long pvID;
                long.TryParse(keys[0].ToString(), out pvID);
                var repository = new PaymentVoucherRepository(context);
                return await repository.GetById(pvID);
            }
        }

        public async Task<PaymentVoucher> GetPaymentVoucher(long pvid)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherRepository(context);
                return await repository.GetById(pvid);
            }
        }

        public ItemsDTO<PaymentVoucher> GetPaymentVoucherGridRows(Action<IGridColumnCollection<PaymentVoucher>> columns, QueryDictionary<StringValues> query)
        {
            using var context = new TBILLSGBContext(_options);
            var repository = new PaymentVoucherRepository(context);
            var server = new GridCoreServer<PaymentVoucher>(repository.GetAll(), new QueryCollection(query), true, "pvGrid", columns, 25)
                .Sortable()
                .Filterable()
                .Searchable(true, false, false)
                .WithMultipleFilters()
                .ChangePageSize(true);
            return server.ItemsToDisplay;
        }

        public ItemsDTO<PaymentVoucher> GetPaymentVoucherGridRows(QueryDictionary<StringValues> query)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherRepository(context);
                var server = new GridCoreServer<PaymentVoucher>(repository.GetAll(), query, true, "pvGrid", null)
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

        public ItemsDTO<PaymentVoucher> GetPaymentVoucherWithErrorGridRows(Action<IGridColumnCollection<PaymentVoucher>> columns, QueryDictionary<StringValues> query)
        {
            var random = new Random();
            if (random.Next(2) == 0)
                throw new Exception("Random server error");

            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherRepository(context);
                var server = new GridCoreServer<PaymentVoucher>(repository.GetAll(), query, true, "pvGrid", columns)
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

        public async Task Insert(PaymentVoucher item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new PaymentVoucherRepository(context);
                    await repository.Insert(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException("PVSRV-01", e);
                }
            }
        }

        public async Task Update(PaymentVoucher item)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                try
                {
                    var repository = new PaymentVoucherRepository(context);
                    await repository.Update(item);
                    repository.Save();
                }
                catch (Exception e)
                {
                    throw new GridException(e);
                }
            }
        }

        public async Task UpdateAndSave(PaymentVoucher pv)
        {
            using (var context = new TBILLSGBContext(_options))
            {
                var repository = new PaymentVoucherRepository(context);
                await repository.Update(pv);
                repository.Save();
            }
        }
    }
}
