#pragma checksum "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e92213c2d196d7e240930a534d90367f8af146a"
// <auto-generated/>
#pragma warning disable 1591
namespace TBILLSWebBlazorServerApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridBlazor.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridShared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridShared.Utility;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridCore.Server;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/clientTypelist")]
    public partial class FetchClientType : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>\n    Client Type Details\n</h2>");
#nullable restore
#line 8 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
 if (_task.IsCompleted)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-md-12");
            __builder.OpenComponent<GridBlazor.Pages.GridComponent<ClientType>>(5);
            __builder.AddAttribute(6, "Grid", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GridBlazor.ICGrid>(
#nullable restore
#line 12 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
                                                                       _grid

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(7, (__value) => {
#nullable restore
#line 12 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
                                                _gridComponent = (GridBlazor.Pages.GridComponent<ClientType>)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "<p><em>Loading...</em></p>");
#nullable restore
#line 19 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchClientType.razor"
       
    private CGrid<ClientType> _grid;
    private Task _task;
    private GridComponent<ClientType> _gridComponent;

    protected override async Task OnParametersSetAsync()
    {
        Action<IGridColumnCollection<ClientType>> columns = c =>
        {
            c.Add(o => o.ClientTypeNo).Titled("ID").SetPrimaryKey(true).SetReadOnlyOnCreate(true).SetReadOnlyOnUpdate(true);
            c.Add(o => o.ClientTypeCode).Titled("Code");
            c.Add(o => o.ClientType1).Titled("Description");
            c.Add(o => o.ClientTypePrefix).Titled("Type Prefix");
            c.Add(o => o.ParticipantId).Titled("Participant ID");
        };

        var query = new QueryDictionary<StringValues>();
        // query.Add("grid-page", "2");

        var client = new GridClient<ClientType>(q => clientTypeService.GetClientTypeGridRows(columns, q), query, false, "clientTypeGrid", columns)
            .Sortable()
            .Filterable()
            .Searchable(true, false, false)
            .WithMultipleFilters()
            .SetExcelExport(true, false, "clientTypeListExport")
            .ChangePageSize(true)
            .Crud(true,clientTypeService);

        _grid = client.Grid;

        // Set new items to grid
        _task = client.UpdateGrid();
        await _task;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClientTypeService clientTypeService { get; set; }
    }
}
#pragma warning restore 1591
