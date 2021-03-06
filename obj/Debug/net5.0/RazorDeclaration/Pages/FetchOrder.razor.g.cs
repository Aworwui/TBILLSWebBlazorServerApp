// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 3 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchOrder.razor"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchOrder.razor"
using TBILLSWebBlazorServerApp.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/listOrderGrid")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/listOrderGrid/{OrderID}/{Mode}")]
    public partial class FetchOrder : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchOrder.razor"
     
    private CGrid<Order> _grid;
    private Task _task;
    private GridComponent<Order> _gridComponent;
    private object[] _keys;
    private GridMode _mode;

    [Parameter]
    public string OrderID { get; set; }

    [Parameter]
    public string Mode { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        Func<object[], bool, bool, bool, bool, Task<IGrid>> subGrids = async (keys, create, read, update, delete) =>
        {
            var subGridQuery = new QueryDictionary<StringValues>();

            Action<IGridColumnCollection<OrderDetail>> subGridColumns = c => ColumnCollections.OrderDetailColumnsCrud(c, c => securityService.GetAllSecurities(),
                c => InstServive.GetAllInstructions(), c => orderTypeService.GetAllOrderTypes(), c => securityService.GetAllSecurities());

            var subGridClient = new GridClient<OrderDetail>(q => odService.GetOrderDetailsGridRows(subGridColumns, keys, q),
                subGridQuery, false, "orderDetailGrid" + keys[0].ToString(), subGridColumns)
                    .Sortable()
                    .Filterable()
                    .SetStriped(true)
                    .Crud(create, read, update, delete, odService)
                    .WithMultipleFilters()
                    .WithGridItemsCount()

                    .AddToOnAfterRender(OnAfterODetailRender)
                    .SetEditAfterInsert(true);

            await subGridClient.UpdateGrid();
            return subGridClient.Grid;
        };

        var query = new QueryDictionary<StringValues>();

        Action<IGridColumnCollection<Order>> columns = c => ColumnCollections.OrderColumnsWithNestedCrud(c, c => caService.GetAllClinetAccounts(),c=>tsService.GetAllSessionNumbers(),
            subGrids);

        var client = new GridClient<Order>(q => oService.GetOrderGridRows(columns, q),
            query, false, "orderGrid", columns)
            .Sortable()
            .Filterable()
            .SetStriped(true)
            .Crud(true, oService)
            .WithMultipleFilters()
            .WithGridItemsCount()
            .SetEditAfterInsert(true)
            .AddButtonCrudComponent<OrderReportComponent>("OrderReport", "Print Order", true, true, true, false)
            .AddButtonComponent<CreateTSBtnComponent>("AddNewSession", "Create New Session");
        _grid = client.Grid;

        if (!string.IsNullOrWhiteSpace(OrderID))
        {
            decimal orderID;
            bool result = decimal.TryParse(OrderID, out orderID);
            if (result)
            {
                if (Mode.ToLower() == "create")
                {
                    _keys = new object[] { orderID };
                    _mode = GridMode.Create;
                }
                else if (Mode.ToLower() == "read")
                {
                    _keys = new object[] { orderID };
                    _mode = GridMode.Read;
                }
                else if (Mode.ToLower() == "update")
                {
                    _keys = new object[] { orderID };
                    _mode = GridMode.Update;
                }
                else if (Mode.ToLower() == "delete")
                {
                    _keys = new object[] { orderID };
                    _mode = GridMode.Delete;
                }
            }
        }
        _task = client.UpdateGrid();
        await _task;
    }

    private async Task OnAfterODetailRender(GridComponent<OrderDetail> gridComponent, bool firstRender)
    {
        if (firstRender)
        {
            gridComponent.BeforeInsert += BeforeInsertoDetail;
            gridComponent.BeforeUpdate += BeforeUpdateoDetail;
            gridComponent.BeforeDelete += BeforeDeleteoDetail;

            gridComponent.AfterInsert += AfterInsertoDetail;
            gridComponent.AfterUpdate += AfterUpdateoDetail;
            gridComponent.AfterDelete += AfterDeleteoDetail;
            gridComponent.AfterBack += AfterBack;

            gridComponent.AfterCreateForm += AfterFormoDetail;
            gridComponent.AfterReadForm += AfterFormoDetail;
            gridComponent.AfterUpdateForm += AfterFormoDetail;
            gridComponent.AfterDeleteForm += AfterFormoDetail;

            await Task.CompletedTask;
        }
    }

    private async Task<bool> BeforeInsertoDetail(GridCreateComponent<OrderDetail> component, OrderDetail item)
    {
        var oDetailValidator = new oDetailValidator();
        var valid = await oDetailValidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = "Insert operation returned one or more errors";
            foreach (var error in valid.Errors)
            {
                component.ColumnErrors.AddParameter(error.PropertyName, error.ErrorMessage);
            }
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeInsert(GridCreateComponent<Order> component, Order item)
    {
        var ovalidator = new oValidator();
        var valid = await ovalidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = "Insert operation returned one or more errors";
            foreach (var error in valid.Errors)
            {
                component.ColumnErrors.AddParameter(error.PropertyName, error.ErrorMessage);
            }
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeUpdate(GridUpdateComponent<Order> component, Order item)
    {
        var ovalidator = new oValidator();
        var valid = await ovalidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = "Update operation returned one or more errors";
            foreach (var error in valid.Errors)
            {
                component.ColumnErrors.AddParameter(error.PropertyName, error.ErrorMessage);
            }
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeDelete(GridDeleteComponent<Order> component, Order item)
    {
        var ovalidator = new oValidator();
        var valid = await ovalidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = valid.ToString();
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeUpdateoDetail(GridUpdateComponent<OrderDetail> component, OrderDetail item)
    {
        var odValidator = new oDetailValidator();
        var valid = await odValidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = "Update operation returned one or more errors";
            foreach (var error in valid.Errors)
            {
                component.ColumnErrors.AddParameter(error.PropertyName, error.ErrorMessage);
            }
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeDeleteoDetail(GridDeleteComponent<OrderDetail> component, OrderDetail item)
    {
        var tsDetailValidator = new oDetailValidator();
        var valid = await tsDetailValidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = valid.ToString();
        }
        return valid.IsValid;
    }

    private async Task AfterInsertoDetail(GridCreateComponent<OrderDetail> component, OrderDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterUpdateoDetail(GridUpdateComponent<OrderDetail> component, OrderDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterDeleteoDetail(GridDeleteComponent<OrderDetail> component, OrderDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterBack(GridComponent<OrderDetail> component, OrderDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterFormoDetail(GridComponent<OrderDetail> gridComponent, OrderDetail item)
    {
        _gridComponent.HideCrudButtons();
        await Task.CompletedTask;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ITradingSessionService tsService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderTypeService orderTypeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IInstructionService InstServive { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISecurityService securityService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderService oService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderDetailService odService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClientAccountService caService { get; set; }
    }
}
#pragma warning restore 1591
