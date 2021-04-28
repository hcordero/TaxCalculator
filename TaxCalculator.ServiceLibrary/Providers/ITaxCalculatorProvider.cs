using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DTO;

namespace TaxCalculator.ServiceLibrary.Providers
{
    public interface ITaxCalculatorProvider
    {
        Task<Rate> GetTaxRateForLocation(Address address);
        Task<Tax> CalcualteSaleTaxForOrder(SalesTaxOrder salesTaxOrder);
    }
}
