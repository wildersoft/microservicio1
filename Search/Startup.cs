﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Search.Interfaces;

namespace Search
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ICustomersService, CustomersService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<ISalesService, SalesService>();

            services.AddHttpClient("customerService", item =>
                {
                    item.BaseAddress = new Uri(Configuration["Services:Customers"]);
                }
            );

            services.AddHttpClient("productService", item =>
                {
                    item.BaseAddress = new Uri(Configuration["Services:Products"]);
                }
            );

            services.AddHttpClient("saleService", item =>
            {
                item.BaseAddress = new Uri(Configuration["Services:Sales"]);
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
