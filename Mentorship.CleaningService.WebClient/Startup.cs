using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Mentorship.CleaningService.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mentorship.CleaningService.WebClient
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
            services.AddDbContext<CleaningServiceDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvc();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    OpenIdConnectDefaults.AuthenticationScheme;
            })
           .AddCookie()
           .AddOpenIdConnect(options =>
           {
               options.SignInScheme =
                  CookieAuthenticationDefaults.AuthenticationScheme;
               options.Authority = "http://localhost:5000"; // Auth Server  
               options.RequireHttpsMetadata = false; // only for development   
               options.ClientId = "CleaningServiceMVC"; // client setup in Auth Server  
               options.ClientSecret = "secret";
               options.ResponseType = "code id_token"; // means Hybrid flow  
               options.Scope.Add("fiver_auth_api");
               options.Scope.Add("offline_access");
               options.GetClaimsFromUserInfoEndpoint = true;
               options.SaveTokens = true;
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseCookieAuthentication(new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = "Cookies"
            //});

            //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            //{
            //    AuthenticationScheme = "oidc",
            //    SignInScheme = "Cookies",

            //    Authority = "http://localhost:5000",
            //    RequireHttpsMetadata = false,

            //    ClientId = "RouxAcademyMVC",
            //    SaveTokens = true
            //});
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
