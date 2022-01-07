using Dapper.FluentMap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TBILLSWebBlazorServerApp.Entities;
using TBILLSWebBlazorServerApp.Data;
using Microsoft.EntityFrameworkCore;
using TBILLSWebBlazorServerApp.Interfaces;
using TBILLSWebBlazorServerApp.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.HttpOverrides;
using BlazorStrap;

namespace TBILLSWebBlazorServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ClientMap());
                config.AddMap(new BranchMap());
                config.AddMap(new ClientCategoryMap());
                config.AddMap(new ClientTypeMap());
                config.AddMap(new CsdClientTypeMap());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredModal();
            services.AddBootstrapCss();

            services.AddDbContext<TBILLSWebDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("TBILLSWebAppConnString")));
            services.AddDbContext<TBILLSGBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TBILLSWebAppConnString")));
            //Client service

            services.AddScoped<IClientService, ClientService>();
            //Client Category service
            services.AddScoped<IClientCategoryService, ClientCategoryService>();
            //Client Type service
            services.AddScoped<IClientTypeService, ClientTypeService>();
            //Client CSD Type service
            services.AddScoped<ICsdClientTypeService, CsdClientTypeService>();
            services.AddScoped<ITradingSessionService, TradingSessionService>();
            services.AddScoped<ITaxationService, TaxationService>();
            services.AddScoped<IInstructionService, InstructionService>();
            services.AddScoped<IAssetTypeService, AssetTypeService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAllotmentService, AllotmentService>();
            services.AddScoped<ITradingSessionDetailService, TradingSessionDetailService>();
            services.AddScoped<IClientAccountService, ClientAccountService>();
            services.AddScoped<IAuctionPurchaseService, AuctionPurchaseService>();
            services.AddScoped<IPaymentVoucherDetailService, PaymentVoucherDetailService>();
            services.AddScoped<IPaymentVoucherService, PaymentVoucherService>();
            services.AddScoped<IOrderTypeService, OrderTypeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientTypeService, ClientTypeService>();
            services.AddScoped<IClientCategoryService, ClientCategoryService>();

            //Register dapper in scope
            services.AddScoped<IDapperService, DapperService>();
            //services.AddSingleton<CsdClientTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
