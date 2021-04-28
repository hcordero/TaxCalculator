using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.ServiceLibrary.Providers;

namespace TaxCalculator.ServiceLibrary
{
    public interface ITaxCalculatorFactory
    {
        ITaxCalculatorProvider GetTaxCalculatorProvider(string customerCalculatorType);
    }
}
