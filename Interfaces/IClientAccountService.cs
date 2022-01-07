using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IClientAccountService : ICrudDataService<ClientAccount>
    {
        public ItemsDTO<ClientAccount> GetClientAccountGridRows(Action<IGridColumnCollection<ClientAccount>> columns, object[] keys, QueryDictionary<StringValues> query);
        Task<ClientAccount> GetClientAccount(int taxid);
        Task UpdateAndSave(ClientAccount clientAccount);
        public IEnumerable<SelectItem> GetAllClinetAccounts();
    }
}
