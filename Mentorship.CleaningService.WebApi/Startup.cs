using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Mentorship.CleaningService.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonDbContext, CleaningServiceDbContext>();
            services.AddScoped<IWorkerDbContext, CleaningServiceDbContext>();
            services.AddScoped<IAddressDbContext, CleaningServiceDbContext>();
            services.AddScoped<IClientDbContext, CleaningServiceDbContext>();
            services.AddScoped<IRepository<Address>, AddressRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
