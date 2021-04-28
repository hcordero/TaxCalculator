using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DTO;
using TaxCalculator.ServiceLibrary.Providers;

namespace TaxCalculator.ServiceLibrary
{
    public interface ITaxCalculatorService 
    {
        Task<Rate> GetTaxRateForLocation(Customer customer, Address address);
        Task<Tax> CalcualteSaleTaxForOrder(Customer customer, SalesTaxOrder salesTaxOrder);
    }
}
