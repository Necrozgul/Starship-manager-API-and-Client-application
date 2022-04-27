using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Endpoint.Services;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<XYZDbContext>();

            services.AddTransient<IStarshipRepository, StarshipRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IWeaponRepository, WeaponRepository>();

            services.AddTransient<IStarshipLogic, StarshipLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IWeaponLogic, WeaponLogic>();

            services.AddSignalR();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
