using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.API.InfrastructureLibrary.Settings;
using TaxCalculator.ServiceLibrary.Providers;
using TaxCalculator.ServiceLibrary.Settings;

namespace TaxCalculator.ServiceLibrary.TestProject
{
    internal static class DependencyInjector
    {
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<ITaxCalculatorFactory, TaxCalculatorFactory>();

            services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

            services.AddScoped<ITaxJarService, TaxJarService>()
               .AddScoped<ITaxCalculatorProvider, TaxJarService>(s => s.GetService<TaxJarService>());


            List<TaxCalculatorProvider> providers = new List<TaxCalculatorProvider>();
            providers.Add(new TaxCalculatorProvider()
            {
                ProviderAuthKey = "YOUR API KEY GOES HERE",
                ProviderName = "TaxJar",
                ProviderUrl = "https://api.taxjar.com/"
            });

            ApplicationSettings settings = new ApplicationSettings();
            settings.Providers = providers;

            services.AddScoped<IApplicationSettingsService>(s => new ApplicationSettingsService(settings));


            return services.BuildServiceProvider();

        }
    }
}
