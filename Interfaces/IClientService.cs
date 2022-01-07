using System;
using System.Threading.Tasks;
using TBILLSWebBlazorServerApp.Entities;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface IClientService : ICrudDataService<Client>
    {
        public ItemsDTO<Client> GetClientGridRows(Action<IGridColumnCollection<Client>> columns, QueryDictionary<StringValues> query);
        Task<Client> GetClient(decimal clientID);
        Task UpdateAndSave(Client client);
        ItemsDTO<Client> GetClientGridRows(QueryDictionary<StringValues> query);
        ItemsDTO<Client> GetClientWithErrorGridRows(Action<IGridColumnCollection<Client>> columns, QueryDictionary<StringValues> query);
    }
}
