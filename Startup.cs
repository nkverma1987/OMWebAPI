﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderManagement.Database;
using OrderManagement.Models;

namespace OrderManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region adding dbcontext service

            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrderManagement")));

            #endregion

            #region Service to add repositories

            services.AddTransient<IOrderRepository, SQLOrderRepository>();

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                         options =>
                         {
                             options.Run(
                             async context =>
                             {
                                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                 context.Response.ContentType = "text/html";
                                 var ex = context.Features.Get<IExceptionHandlerFeature>();
                                 if (ex != null)
                                 {
                                     var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                                     await context.Response.WriteAsync(err).ConfigureAwait(false);
                                 }
                             });
                         }
                        );
            }

            app.UseMvc();
        }
    }
}
