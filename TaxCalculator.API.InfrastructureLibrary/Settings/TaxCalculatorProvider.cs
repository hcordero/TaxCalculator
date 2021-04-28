using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.API.InfrastructureLibrary.Settings
{
    public class TaxCalculatorProvider
    {
        public string ProviderName { get; set; }
        public string ProviderAuthKey { get; set; }
        public string ProviderUrl { get; set; }
    }
}
