using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.API.InfrastructureLibrary.Settings;
using TaxCalculator.ServiceLibrary;
using TaxCalculator.ServiceLibrary.Providers;
using TaxCalculator.ServiceLibrary.Settings;

namespace TaxCalculator.API
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
            services.AddControllers();

            services.AddScoped<ITaxCalculatorFactory, TaxCalculatorFactory>();

            services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

            services.AddScoped<ITaxJarService, TaxJarService>()
               .AddScoped<ITaxCalculatorProvider, TaxJarService>(s => s.GetService<TaxJarService>());

            List<TaxCalculatorProvider> providers = Configuration.GetSection("Providers").Get<List<TaxCalculatorProvider>>();
            ApplicationSettings settings = new ApplicationSettings();
            settings.Providers = providers;

            services.AddScoped<IApplicationSettingsService>(s => new ApplicationSettingsService(settings));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
