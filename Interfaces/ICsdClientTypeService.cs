using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridShared;
using GridShared.Utility;
using Microsoft.Extensions.Primitives;
using TBILLSWebBlazorServerApp.Entities;

namespace TBILLSWebBlazorServerApp.Interfaces
{
    public interface ICsdClientTypeService : ICrudDataService<CsdClientType>
    {
        public ItemsDTO<CsdClientType> GetCsdClientTypesGridRows(QueryDictionary<StringValues> query);
        public ItemsDTO<CsdClientType> GetCsdClientTypesGridRows(Action<IGridColumnCollection<CsdClientType>> columns, QueryDictionary<StringValues> query);
        Task<CsdClientType> GetCsdClientType(int csdClientTypeNo);
        Task UpdateAndSave(CsdClientType csdClientType);
    }
}
