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
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using IdentityServer4.Models;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using static Mentorship.CleaningService.WebApi.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            services.AddScoped<IRepository<Person>, PersonRepository>();
            services.AddScoped<ApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>(); 
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                });
            services.AddDbContext<CleaningServiceDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<ApplicationUserDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvcCore()
            .AddAuthorization(
                //options =>
                //    {
                //        options.AddPolicy("FacultyOnly", policy => policy.RequireClaim("FacultyNumber"));
                //    }
            )
            .AddJsonFormatters();
            //services.AddAuthentication(
            // IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //      .AddIdentityServerAuthentication(options =>
            //      {
            //          options.Authority = "http://localhost:5000"; // Auth Server  
            //          options.RequireHttpsMetadata = false; // only for development  
            //          options.ApiName = "fiver_auth_api"; // API Resource Id  
            //      });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // base-address of your identityserver
                options.Authority = "http://localhost:5000";

                // name of the API resource
                options.RequireHttpsMetadata = false; // only for development  
                options.Audience = "fiver_auth_api"; // API Resource Id  
            });
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "http://localhost:5000";
            //        options.RequireHttpsMetadata = false;

            //        options.ApiName = "api1";
            //    })
            //    .AddCookie()
            //    .AddOpenIdConnect();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleaningServiceDbContext>()
                .AddDefaultTokenProviders();

            //services.AddIdentityServer()
            //    .AddOperationalStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
            //    .AddConfigurationStore(options =>
            //        options.ConfigureDbContext = builder =>
            //            builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
            //    .AddAspNetIdentity<ApplicationUser>()
            //    .AddInMemoryClients(Clients.Get())
            //    .AddInMemoryIdentityResources(WebApi.Configuration.Resources.GetIdentityResources())
            //    .AddInMemoryApiResources(WebApi.Configuration.Resources.GetApiResources())
            //    .AddTestUsers(Users.Get())
            //    .AddDeveloperSigningCredential();
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

            //app.UseIdentityServer();
            //app.UseIdentity();
            //app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = "cookie"
            //});
            //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            //{
            //    ClientId = "testWebClient"
            //});
            //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            //{
            //    ClientId = "testWebClient",
            //    SignInScheme = "cookie",
            //    Authority = "http://localhost Jump :5000/"
            //});

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            //app.UseMvc();

            //// Adds IdentityServer
            //app.UseIdentityServer();
            //app.UseAuthentication();
        }
    }
}
