using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DTO;
using TaxCalculator.ServiceLibrary.Providers;

namespace TaxCalculator.ServiceLibrary
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private ITaxCalculatorFactory taxCalculatorFactory;


        public TaxCalculatorService(ITaxCalculatorFactory taxCalculatorFactory)
        {
            this.taxCalculatorFactory = taxCalculatorFactory;
        }

        public Task<Tax> CalcualteSaleTaxForOrder(Customer customer, SalesTaxOrder salesTaxOrder)
        {
            ITaxCalculatorProvider calculatorProvider = this.taxCalculatorFactory.GetTaxCalculatorProvider(customer.type);
            return calculatorProvider.CalcualteSaleTaxForOrder(salesTaxOrder);
        }

        public Task<Rate> GetTaxRateForLocation(Customer customer, Address address)
        {
            ITaxCalculatorProvider calculatorProvider = this.taxCalculatorFactory.GetTaxCalculatorProvider(customer.type);
            return calculatorProvider.GetTaxRateForLocation(address);
        }
    }
}
