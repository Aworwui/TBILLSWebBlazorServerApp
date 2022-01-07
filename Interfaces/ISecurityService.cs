using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface ISecurityService : ICrudDataService<Security>
    {
       public ItemsDTO<Security> GetSecurityGridRows(Action<IGridColumnCollection<Security>> columns, QueryDictionary<StringValues> query);
        Task<Security> GetSecurity(int taxid);
        Task UpdateAndSave(Security security);
        public IEnumerable<SelectItem> GetAllAssetType();
        IEnumerable<SelectItem> GetAllSecurities();

    }
}
