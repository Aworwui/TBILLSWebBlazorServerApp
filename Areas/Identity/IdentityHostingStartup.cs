using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBILLSWebBlazorServerApp.Entities;

[assembly: HostingStartup(typeof(TBILLSWebBlazorServerApp.Areas.Identity.IdentityHostingStartup))]
namespace TBILLSWebBlazorServerApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TBILLSGBDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TBILLSGBDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TBILLSGBDbContext>();
            });
        }
    }
}