using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.API.InfrastructureLibrary.Settings
{
    public class ApplicationSettings
    {
        public List<TaxCalculatorProvider> Providers { get; set; }
    }
}
