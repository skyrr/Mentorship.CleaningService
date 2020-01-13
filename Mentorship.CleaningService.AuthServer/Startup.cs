using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mentorship.CleaningService.AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<CleaningServiceDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleaningServiceDbContext>()
                .AddDefaultTokenProviders();

            //services.AddIdentityServer()
            //    .AddOperationalStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)))
            //    .AddConfigurationStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)))
            //    .AddAspNetIdentity<ApplicationUser>()
            //    .AddInMemoryClients(Config.GetClients())
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddTestUsers(Config.Get())
            //    .AddDeveloperSigningCredential();
            services.AddIdentityServer()
            .AddDeveloperSigningCredential(filename: "tempkey.rsa")
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryClients(Config.GetClients())
            .AddTestUsers(Config.GetUsers());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
