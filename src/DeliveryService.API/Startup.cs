﻿using DeliveryService.API.Commands;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.API
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
            services.AddScoped<AbstractQueriesService<Point>, PointQueriesService>(ctor => new PointQueriesService(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<AbstractQueriesService<Route>, RouteQueriesService>(ctor => new RouteQueriesService(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICommandService<Point>, PointCommandService>();
            services.AddScoped<ICommandService<Route>, RouteCommandService>();

            services.AddDbContext<DeliveryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DeliveryContext>();
                context.Database.Migrate();
            }

            app.UseMvc();
        }
    }
}
