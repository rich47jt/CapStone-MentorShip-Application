﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_CapStone_Mentorship_Service.Data;

[assembly: HostingStartup(typeof(Project_CapStone_Mentorship_Service.Areas.Identity.IdentityHostingStartup))]
namespace Project_CapStone_Mentorship_Service.Areas.Identity
{
   
    public class IdentityHostingStartup : IHostingStartup
    {
 

        public void Configure(IWebHostBuilder builder)
        {

            builder.ConfigureServices((context, services) => {
            });
        }
    }
}