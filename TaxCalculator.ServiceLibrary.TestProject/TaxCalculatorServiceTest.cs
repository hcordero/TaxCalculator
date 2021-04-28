using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.DTO;
using System.Threading.Tasks;

namespace TaxCalculator.ServiceLibrary.TestProject
{
    public class TaxCalculatorServiceTest
    {
        private ITaxCalculatorService taxCalculatorService;

        [SetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            this.taxCalculatorService = provider.GetService<ITaxCalculatorService>();
        }

        [Test]
        public async Task TaxJarGetTaxRateForLocation()
        {
            /*
            * Assuming customer has been returned from the Customer Service based on it's Id.
            */
            Customer customer = new Customer();
            customer.type = "TAXJAR";

            Address address = new Address();

            address.zip = "33180";

            var results = await this.taxCalculatorService.GetTaxRateForLocation(customer, address);
            if (results != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
        public async Task TaxJarCalcualteSaleTaxForOrder()
        {
            /*
           * Assuming customer has been returned from the Customer Service based on it's Id.
           */
            Customer customer = new Customer();
            customer.type = "TAXJAR";

            SalesTaxOrder salesTaxOrder = new SalesTaxOrder
            {
                from_country = "US",
                from_zip = "92093",
                from_state = "CA",
                from_city = "La Jolla",
                from_street = "9500 Gilman Drive",
                to_country = "US",
                to_zip = "90002",
                to_state = "CA",
                to_city = "Los Angeles",
                to_street = "1335 E 103rd St",
                amount = 15,
                shipping = 1.5F,
                nexus_addresses = new Address[] {
                new Address{
                  id = "Main Location",
                  country = "US",
                  zip = "92093",
                  state = "CA",
                  city = "La Jolla",
                  street = "9500 Gilman Drive",
                }
              },
                line_items = new ProductLineItem[] {
                new ProductLineItem{
                  id = "1",
                  quantity = 1,
                  product_tax_code = "20010",
                  unit_price = 15,
                  discount = 0
                }
              }
            };

            var results = await this.taxCalculatorService.CalcualteSaleTaxForOrder(customer, salesTaxOrder);
            if (results != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
