using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MtgCollectionMgr.Areas.Identity.Data;
using MtgCollectionMgr.Models;

[assembly: HostingStartup(typeof(MtgCollectionMgr.Areas.Identity.IdentityHostingStartup))]
namespace MtgCollectionMgr.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MtgCollectionMgrUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MtgCollectionMgrUserContextConnection")));

                services.AddDefaultIdentity<MtgCollectionMgrUser>()
                    .AddEntityFrameworkStores<MtgCollectionMgrUserContext>();
            });
        }
    }
}