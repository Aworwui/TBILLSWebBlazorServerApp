using System;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IPaymentVoucherDetailService : ICrudDataService<PaymentVoucherDetail>
    {
        public ItemsDTO<PaymentVoucherDetail> GetPaymentVoucherDetailGridRows(Action<IGridColumnCollection<PaymentVoucherDetail>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<PaymentVoucherDetail> GetPaymentVoucherDetail(long pvDetailID);
        Task UpdateAndSave(PaymentVoucherDetail pvDetail);

    }
}
