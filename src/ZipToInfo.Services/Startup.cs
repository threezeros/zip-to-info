using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using ZipToInfo.Data;
using ZipToInfo.Data.Access;
using ZipToInfo.Models;
using ZipToInfo.Shared.Settings;

namespace ZipToInfo.Services
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
            services.AddCors();
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<IRestClient, RestClient>();

            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IOpenWeatherApiClient, OpenWeatherApiClient>();
            services.AddScoped<IGoogleMapsApiClient, GoogleMapsApiClient>();
            services.AddScoped<IDataService, DataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // note: the following is very risky, allowing any source to query this service. because this is a 
            // demo product with no "secret information," I enabled everything in order to simplify, but would 
            // definitely dial this down to expected domains only, on a per-environment basis...
            // see: http://dotnetcoretutorials.com/2017/01/03/enabling-cors-asp-net-core/
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
