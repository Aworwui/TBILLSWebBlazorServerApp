#pragma checksum "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94fedbd419b5b3d9f16c6d44c77a207d3a9514d5"
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
#line 2 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/listSecurities")]
    public partial class FetchSecurities : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 6 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
 if (_task.IsCompleted)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "col-md-12");
            __builder.OpenComponent<GridBlazor.Pages.GridComponent<Security>>(4);
            __builder.AddAttribute(5, "Grid", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GridBlazor.ICGrid>(
#nullable restore
#line 10 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
                                                                     _grid

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(6, (__value) => {
#nullable restore
#line 10 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
                                              _gridComponent = (GridBlazor.Pages.GridComponent<Security>)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 13 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "<p><em>Loading...</em></p>");
#nullable restore
#line 17 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchSecurities.razor"
     
    private CGrid<Security> _grid;
    private Task _task;
    private GridComponent<Security> _gridComponent;

    protected override async Task OnParametersSetAsync()
    {
        Action<IGridColumnCollection<Security>> columns = c =>
        {
            c.Add(o => o.SecurityNo).Titled("ID").SetPrimaryKey(true);
            c.Add(o => o.SecurityCode).Titled("Code");
            c.Add(o => o.SecurityDescription).Titled("Description");
            c.Add(o => o.AssetTypeNo, true).SetSelectField(true, o => o.AssetType.AssetTypeNo + " - " + o.AssetType.AssetType1,
           o => securityService.GetAllAssetType());
        };

        var query = new QueryDictionary<StringValues>();
        // query.Add("grid-page", "2");

        var client = new GridClient<Security>(q => securityService.GetSecurityGridRows(columns, q), query, false, "securityGrid", columns)
            .Sortable()
            .Filterable()
            .Searchable(true, false, false)
            .WithMultipleFilters()
            .SetExcelExport(true, false, "SecurityList")
            .ChangePageSize(true)
            .Crud(true, securityService);

        _grid = client.Grid;

        // Set new items to grid
        _task = client.UpdateGrid();
        await _task;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISecurityService securityService { get; set; }
    }
}
#pragma warning restore 1591
