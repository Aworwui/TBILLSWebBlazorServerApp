using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IClientCategoryService : ICrudDataService<ClientCategory>
    {
        IEnumerable<SelectItem> GetAllClientCategory();
        public ItemsDTO<ClientCategory> GetClientCategoryGridRows(Action<IGridColumnCollection<ClientCategory>> columns, QueryDictionary<StringValues> query);
        Task<ClientCategory> GetClientCategory(int id);
        Task UpdateAndSave(ClientCategory clientCategory);
        
    }
}
