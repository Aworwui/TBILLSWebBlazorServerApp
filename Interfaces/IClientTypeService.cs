
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IClientTypeService : ICrudDataService<ClientType>
    {
        public ItemsDTO<ClientType> GetClientTypeGridRows(Action<IGridColumnCollection<ClientType>> columns, QueryDictionary<StringValues> query);
        Task<ClientType> GetClientType(int id);
        Task UpdateAndSave(ClientType clientType);
        IEnumerable<SelectItem> GetAllClientTypes();
    }
}
