#pragma checksum "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1aff2374dbd1a43b58ee58834a80cebb7004299d"
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
using BlazorStrap;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridBlazor.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridShared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridShared.Utility;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using GridCore.Server;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using TBILLSWebBlazorServerApp.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/listPaymentVoucherGrid")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/listPaymentVoucherGrid/{PvNo}/{Mode}")]
    public partial class FetchPaymentVoucher : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>\n    Payment Voucher Details\n</h2>");
#nullable restore
#line 11 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
 if (_task.IsCompleted)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-md-12");
            __builder.OpenComponent<GridBlazor.Pages.GridComponent<PaymentVoucher>>(5);
            __builder.AddAttribute(6, "Grid", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GridBlazor.ICGrid>(
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
                                                                           _grid

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "Mode", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GridShared.GridMode>(
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
                                                                                        _mode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "Keys", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object[]>(
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
                                                                                                     _keys

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(9, (__value) => {
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
                                                    _gridComponent = (GridBlazor.Pages.GridComponent<PaymentVoucher>)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 18 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "<p><em>Loading...</em></p>");
#nullable restore
#line 22 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Pages/FetchPaymentVoucher.razor"
     
    private CGrid<PaymentVoucher> _grid;
    private Task _task;
    private GridComponent<PaymentVoucher> _gridComponent;
    private object[] _keys;
    private GridMode _mode;

    [Parameter]
    public string PvNo { get; set; }

    [Parameter]
    public string Mode { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        Func<object[], bool, bool, bool, bool, Task<IGrid>> subGrids = async (keys, create, read, update, delete) =>
        {
            var subGridQuery = new QueryDictionary<StringValues>();

            Action<IGridColumnCollection<PaymentVoucherDetail>> subGridColumns = c => ColumnCollections.pvDetailColumnsCrud(c);

            var subGridClient = new GridClient<PaymentVoucherDetail>(q => pvdService.GetPaymentVoucherDetailGridRows(subGridColumns, keys, q),
                subGridQuery, false, "pvDetailGrid" + keys[0].ToString(), subGridColumns)
                    .Sortable()
                    .Filterable()
                    .SetStriped(true)
                    .Crud(create, read, update, delete, pvdService)
                    .WithMultipleFilters()
                    .WithGridItemsCount()
                  
                    .AddToOnAfterRender(OnAfterpvDetailRender)
                    .SetEditAfterInsert(true);

            await subGridClient.UpdateGrid();
            return subGridClient.Grid;
        };

        var query = new QueryDictionary<StringValues>();

        Action<IGridColumnCollection<PaymentVoucher>> columns = c => ColumnCollections.pvColumnsWithNestedCrud(c, c => caService.GetAllClinetAccounts(), subGrids);

        var client = new GridClient<PaymentVoucher>(q => pvService.GetPaymentVoucherGridRows(columns, q),
            query, false, "pvGrid", columns)
            .Sortable()
            .Filterable()
            .SetStriped(true)
            .Crud(true, pvService)
            .WithMultipleFilters()
            .WithGridItemsCount()
            .SetEditAfterInsert(true);

        _grid = client.Grid;

        if (!string.IsNullOrWhiteSpace(PvNo))
        {
            int Pv_ID;
            bool result = int.TryParse(PvNo, out Pv_ID);
            if (result)
            {
                if (Mode.ToLower() == "create")
                {
                    _keys = new object[] { Pv_ID };
                    _mode = GridMode.Create;
                }
                else if (Mode.ToLower() == "read")
                {
                    _keys = new object[] { Pv_ID };
                    _mode = GridMode.Read;
                }
                else if (Mode.ToLower() == "update")
                {
                    _keys = new object[] { Pv_ID };
                    _mode = GridMode.Update;
                }
                else if (Mode.ToLower() == "delete")
                {
                    _keys = new object[] {Pv_ID};
                    _mode = GridMode.Delete;
                }
            }
        }
        _task = client.UpdateGrid();
        await _task;
    }

    private async Task OnAfterpvDetailRender(GridComponent<PaymentVoucherDetail> gridComponent, bool firstRender)
    {
        if (firstRender)
        {
            gridComponent.BeforeInsert += BeforeInsertTSDetail;
            gridComponent.BeforeUpdate += BeforeUpdateTSDetail;
            gridComponent.BeforeDelete += BeforeDeleteTSDetail;

            gridComponent.AfterInsert += AfterInsertTSDetail;
            gridComponent.AfterUpdate += AfterUpdateTSDetail;
            gridComponent.AfterDelete += AfterDeleteTSDetail;
            gridComponent.AfterBack += AfterBack;

            gridComponent.AfterCreateForm += AfterFormTSDetail;
            gridComponent.AfterReadForm += AfterFormTSDetail;
            gridComponent.AfterUpdateForm += AfterFormTSDetail;
            gridComponent.AfterDeleteForm += AfterFormTSDetail;

            await Task.CompletedTask;
        }
    }

    private async Task<bool> BeforeInsertTSDetail(GridCreateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsDetailValidator = new pvDetailValidator();
        var valid = await tsDetailValidator.ValidateAsync(item);
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

    private async Task<bool> BeforeInsert(GridCreateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsValidator = new pvDetailValidator();
        var valid = await tsValidator.ValidateAsync(item);
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

    private async Task<bool> BeforeUpdate(GridUpdateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsValidator = new pvDetailValidator();
        var valid = await tsValidator.ValidateAsync(item);
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

    private async Task<bool> BeforeDelete(GridDeleteComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsValidator = new pvDetailValidator();
        var valid = await tsValidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = valid.ToString();
        }
        return valid.IsValid;
    }

    private async Task<bool> BeforeUpdateTSDetail(GridUpdateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsDetailValidator = new pvDetailValidator();
        var valid = await tsDetailValidator.ValidateAsync(item);
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

    private async Task<bool> BeforeDeleteTSDetail(GridDeleteComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        var tsDetailValidator = new pvDetailValidator();
        var valid = await tsDetailValidator.ValidateAsync(item);
        if (!valid.IsValid)
        {
            component.Error = valid.ToString();
        }
        return valid.IsValid;
    }

    private async Task AfterInsertTSDetail(GridCreateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterUpdateTSDetail(GridUpdateComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterDeleteTSDetail(GridDeleteComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterBack(GridComponent<PaymentVoucherDetail> component, PaymentVoucherDetail item)
    {
        _gridComponent.ShowCrudButtons();
        await Task.CompletedTask;
    }

    private async Task AfterFormTSDetail(GridComponent<PaymentVoucherDetail> gridComponent, PaymentVoucherDetail item)
    {
        _gridComponent.HideCrudButtons();
        await Task.CompletedTask;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPaymentVoucherDetailService pvdService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPaymentVoucherService pvService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClientAccountService caService { get; set; }
    }
}
#pragma warning restore 1591
