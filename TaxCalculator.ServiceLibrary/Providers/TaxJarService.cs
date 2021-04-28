using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.API.InfrastructureLibrary.Settings;
using TaxCalculator.DTO;
using TaxCalculator.ServiceLibrary.Settings;

namespace TaxCalculator.ServiceLibrary.Providers
{
    public class TaxJarService : ITaxCalculatorProvider, ITaxJarService
    {
        IApplicationSettingsService applicationSettingsService;
        TaxCalculatorProvider taxCalculatorProvider;

        public TaxJarService(IApplicationSettingsService applicationSettingsService)
        {
            this.applicationSettingsService = applicationSettingsService;
            this.taxCalculatorProvider = applicationSettingsService.ApplicationSettings.Providers.FirstOrDefault(x => x.ProviderName.Trim().ToUpper() == "TAXJAR");
        }

        public async Task<Tax> CalcualteSaleTaxForOrder(SalesTaxOrder salesTaxOrder)
        {
            string serialziedObject = JsonConvert.SerializeObject(salesTaxOrder);
            var response = await taxCalculatorProvider.ProviderUrl
                .AppendPathSegment("v2/taxes/")
                .WithOAuthBearerToken(this.taxCalculatorProvider.ProviderAuthKey)
                .PostJsonAsync(salesTaxOrder)
                .ReceiveJson<TaxResponse>();
            return response?.tax;
        }

        public async Task<Rate> GetTaxRateForLocation(Address address)
        {
            var response = await taxCalculatorProvider.ProviderUrl
                .AppendPathSegment("v2/rates/")
                .SetQueryParams(address)
                .WithOAuthBearerToken(this.taxCalculatorProvider.ProviderAuthKey)
                .GetJsonAsync<RateResponse>();
            return response?.rate;
        }

    }
}
 