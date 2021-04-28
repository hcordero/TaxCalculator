using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.ServiceLibrary.Providers;

namespace TaxCalculator.ServiceLibrary
{

    public class TaxCalculatorFactory: ITaxCalculatorFactory
    {
        private readonly IServiceProvider serviceProvider;
        public TaxCalculatorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ITaxCalculatorProvider GetTaxCalculatorProvider(string customerCalculatorType)
        {
            if (string.IsNullOrEmpty(customerCalculatorType))
                throw new Exception("The customer type is null or empty");

            if (customerCalculatorType.Trim().ToUpper() == "TAXJAR")
                return (ITaxCalculatorProvider)serviceProvider.GetService(typeof(ITaxJarService));

            throw new NotImplementedException("The requested provider is not implemented.");
        }
    }
}
