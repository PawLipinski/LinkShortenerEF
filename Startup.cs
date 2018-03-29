﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShortenerEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebDevHomework.Interfaces;
using WebDevHomework.Repository;
using WebDevHomework.Services;

namespace WebDevHomework
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
            services.AddMvc();
            services.AddTransient<LinkRepository>();
            services.AddSingleton<Hasher>();
            services.AddTransient<ILinkReader, LinkReader>();
            services.AddTransient<ILinkWriter, LinkWriter>();
            services.AddTransient<IHashDecoder, Decoder>();
            services.AddTransient<IHashEncoder, Encoder>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info{ Title = "Warsaw Stops API", Version = "v1" }));
            services.AddDbContext<LinkDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("LinkDbConnection")));       


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

             app.UseSwagger();
             app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warsaw Stops API"));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Link}/{action=Index}/{id?}");
            });
        }
    }
}