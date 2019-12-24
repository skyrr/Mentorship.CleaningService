using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.DataAccess.Interfaces;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Mentorship.CleaningService.WebApi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Mentorship.CleaningService.Models.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using IdentityServer4.Models;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using static Mentorship.CleaningService.WebApi.Configuration;

namespace Mentorship.CleaningService.WebApi
{
    public class Startup
    {
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAddressDbContext, CleaningServiceDbContext>();
            services.AddScoped<IClientAddressDbContext, CleaningServiceDbContext>();
            services.AddScoped<IClientDbContext, CleaningServiceDbContext>();
            services.AddScoped<ICompanyDbContext, CleaningServiceDbContext>();
            services.AddScoped<IContractDbContext, CleaningServiceDbContext>();
            services.AddScoped<IContractStatusDbContext, CleaningServiceDbContext>();
            services.AddScoped<IDemandDbContext, CleaningServiceDbContext>();
            services.AddScoped<IDemandStatusDbContext, CleaningServiceDbContext>();
            services.AddScoped<IOfferDbContext, CleaningServiceDbContext>();
            services.AddScoped<IOfferStatusDbContext, CleaningServiceDbContext>();
            services.AddScoped<IPersonDbContext, CleaningServiceDbContext>();
            services.AddScoped<IRoleDbContext, CleaningServiceDbContext>();
            services.AddScoped<IServicePlanDbContext, CleaningServiceDbContext>();
            services.AddScoped<IWorkerDbContext, CleaningServiceDbContext>();
            services.AddScoped<IWorkerRoleDbContext, CleaningServiceDbContext>();
            services.AddScoped<IRepository<Address>, AddressRepository>(); 
            services.AddScoped<IRepositoryFactory, RepositoryFactory>(); 
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                });
            services.AddDbContext<CleaningServiceDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = "Data Source=.;Initial Catalog=CleaningDb;Integrated Security=True;Pooling=False;uid=delivery; Password=123456Qaz.;";

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleaningServiceDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddAspNetIdentity<ApplicationUser>()
                .AddInMemoryClients(WebApi.Configuration.Clients.Get())
                .AddInMemoryIdentityResources(WebApi.Configuration.Resources.GetIdentityResources())
                .AddInMemoryApiResources(WebApi.Configuration.Resources.GetApiResources())
                .AddTestUsers(Users.Get())
                .AddDeveloperSigningCredential();

            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients())
            //    .AddAspNetIdentity<ApplicationUser>();

            //services.AddIdentityServer()
            //    //Configures EF implementation of IPersistedGrantStore with IdentityServer.    
            //    .AddDeveloperSigningCredential()
            //    .AddOperationalStore(builder =>
            //    builder.UseSqlServer(Configuration.GetConnectionString("TokenService"),
            //    options =>
            //    options.MigrationsAssembly(migrationAssembly)))
            //    //Configures EF implementation of IPersistedGrantStore with IdentityServer.   
            //    .AddConfigurationStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]))
            //    .AddAspNetIdentity<ApplicationUser>()
            //    .AddDeveloperSigningCredential();

            //services.AddIdentityServer()
            //    //Configures EF implementation of IPersistedGrantStore with IdentityServer.    
            //    .AddOperationalStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]))
            //    //Configures EF implementation of IPersistedGrantStore with IdentityServer.   
            //    .AddConfigurationStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]))
            //    .AddAspNetIdentity<ApplicationUser>()
            //    .AddDeveloperSigningCredential();

            // builder => builder.UseSqlServer(Configuration.GetConnectionString("TokenService"),
            // options =>
            // options.MigrationsAssembly(migrationAssembly)))


            /*
             services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<YourUserStoreDbContextHere>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

                services.AddIdentity<YourUserClassHere, YourRoleClassHereIfAny>()
                    .AddEntityFrameworkStores<YourUserStoreDbContextHere>()
                    .AddDefaultTokenProviders();

                services.AddIdentityServer()
                    // Other config here
                    .AddAspNetIdentity<YourUserClassHere>();
             */
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
                app.UseMvc();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            app.UseIdentity();

            // Adds IdentityServer
            // app.UseIdentityServer();
        }
    }
}
