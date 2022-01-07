using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IPaymentVoucherService: ICrudDataService<PaymentVoucher>
    {
        public ItemsDTO<PaymentVoucher> GetPaymentVoucherGridRows(Action<IGridColumnCollection<PaymentVoucher>> columns, QueryDictionary<StringValues> query);
        Task<PaymentVoucher> GetPaymentVoucher(Int64 pvid);
        Task UpdateAndSave(PaymentVoucher pv);
        ItemsDTO<PaymentVoucher> GetPaymentVoucherGridRows(QueryDictionary<StringValues> query);
        ItemsDTO<PaymentVoucher> GetPaymentVoucherWithErrorGridRows(Action<IGridColumnCollection<PaymentVoucher>> columns, QueryDictionary<StringValues> query);
    }
}
