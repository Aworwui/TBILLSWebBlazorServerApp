#pragma checksum "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Shared/MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d50cb2dfb088f686570ff788c76ed4dfba59264"
// <auto-generated/>
#pragma warning disable 1591
namespace TBILLSWebBlazorServerApp.Shared
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
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-vqpya8djs7");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-vqpya8djs7");
            __builder.OpenComponent<TBILLSWebBlazorServerApp.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\n\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-vqpya8djs7");
            __builder.AddMarkupContent(11, @"<div class=""top-row px-4"" b-vqpya8djs7><a href=""https://docs.microsoft.com/aspnet/"" target=""_blank"" b-vqpya8djs7>Login</a>
            <a href=""https://docs.microsoft.com/aspnet/"" target=""_blank"" b-vqpya8djs7>Contact Us</a>
            <a href=""https://docs.microsoft.com/aspnet/"" target=""_blank"" b-vqpya8djs7>About</a>
            <a href=""https://docs.microsoft.com/aspnet/"" target=""_blank"" b-vqpya8djs7>Help</a></div>
        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-vqpya8djs7");
#nullable restore
#line 15 "/Users/archibaldworwui/Projects/TBILLSWebBlazorServerApp/TBILLSWebBlazorServerApp/Shared/MainLayout.razor"
__builder.AddContent(15, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591