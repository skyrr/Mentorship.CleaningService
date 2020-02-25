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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Mentorship.CleaningService.BusinessLogic;

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
            services.AddScoped<IClientsDemandDbContext, CleaningServiceDbContext>();
            services.AddScoped<IRepository<Address>, AddressRepository>();
            services.AddScoped<IRepository<ClientAddress>, ClientAddressRepository>();
            services.AddScoped<IRepository<Models.Client>, ClientRepository>();
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IRepository<Contract>, ContractRepository>();
            services.AddScoped<IRepository<ContractStatus>, ContractStatusRepository>();
            services.AddScoped<IRepository<Demand>, DemandRepository>();
            services.AddScoped<IRepository<DemandStatus>, DemandStatusRepository>();
            services.AddScoped<IRepository<Offer>, OfferRepository>();
            services.AddScoped<IRepository<OfferStatus>, OfferStatusRepository>();
            services.AddScoped<IRepository<Person>, PersonRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IRepository<ServicePlan>, ServicePlanRepository>();
            services.AddScoped<IRepository<Worker>, WorkerRepository>();
            services.AddScoped<IRepository<WorkerRole>, WorkerRoleRepository>();
            services.AddScoped<IRepository<Address>, AddressRepository>();
            services.AddScoped<IRepository<Person>, PersonRepository>();
            services.AddScoped<IRepository<ClientsDemand>, ClientsDemandRepository>();
            services.AddScoped<ApplicationUserRepository>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<CleaningServiceDbContext>();
            services.AddScoped<UserManager<IdentityUser>>(); 
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IClientsDemandService, ClientsDemandService>();
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                });
            services.AddDbContext<CleaningServiceDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddDbContext<IdentityDbContext>(options =>
            //    options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"],
            //    optionsBuilders => optionsBuilders.MigrationsAssembly("Mentorship.CleaningService.DataAccess")));

            //services.AddMvcCore()
            //.AddAuthorization(
            //options =>
            //    {
            //        options.AddPolicy("FacultyOnly", policy => policy.RequireClaim("FacultyNumber"));
            //    }
            //)
            //.AddJsonFormatters();
            //----------------------------------------
            //services.AddAuthentication(
            // IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //      .AddIdentityServerAuthentication(options =>
            //      {
            //          options.Authority = "https://localhost:44350"; // Auth Server  
            //          options.RequireHttpsMetadata = false; // only for development  
            //          options.ApiName = "fiver_auth_api"; // API Resource Id  
            //      });
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // cookie middle setup above
                options.Authority = "https://localhost:44350"; // Auth Server
                options.RequireHttpsMetadata = false; // only for development 
                options.ClientId = "fiver_auth_client"; // client setup in Auth Server
                options.ClientSecret = "secret";
                options.ResponseType = "code id_token"; // means Hybrid flow (id + access token)
                options.Scope.Add("fiver_auth_api");
                options.Scope.Add("offline_access");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
            });
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "https://localhost:44350"; // Auth Server
                            options.RequireHttpsMetadata = false;
                options.ApiName = "fiver_auth_api"; // API Resource Id
                        });


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

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
        }
    }
}
