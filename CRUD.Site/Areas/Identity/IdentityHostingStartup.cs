using System;
using CRUD.Site.Areas.Identity.Data;
using CRUD.Site.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CRUD.Site.Areas.Identity.IdentityHostingStartup))]
namespace CRUD.Site.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CRUDSiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CRUDSiteContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CRUDSiteContext>();
            });
        }
    }
}