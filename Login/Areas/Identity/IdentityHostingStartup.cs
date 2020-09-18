﻿using System;
using Login.Areas.Identity.Data;
using Login.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Login.Areas.Identity.IdentityHostingStartup))]
namespace Login.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LogindbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LogindbContextConnection")));

                services.AddDefaultIdentity<LoginUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<LogindbContext>();
            });
        }
    }
}