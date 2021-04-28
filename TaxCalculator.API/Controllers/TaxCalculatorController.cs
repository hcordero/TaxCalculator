using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.DTO;
using TaxCalculator.ServiceLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        ITaxCalculatorService taxCalculatorService;
        public TaxCalculatorController(ITaxCalculatorService taxCalculatorService)
        {
            this.taxCalculatorService = taxCalculatorService;
        }

        // GET: api/<TaxCalculatorController>
        [HttpGet]
        public Task<Rate> GetTaxRateForLocation(long customerId, Address addressForRate)
        {
            /*
             * Assuming customer has been returned from the Customer Service based on it's Id.
             */
            Customer customer = new Customer();
            customer.type = "TAXJAR"; 
            

            return this.taxCalculatorService.GetTaxRateForLocation(customer, addressForRate);
        }

       
        // POST api/<TaxCalculatorController>
        [HttpPost]
        public async Task<Tax> CalcualteSaleTaxForOrder([FromBody] long customerId, [FromBody] SalesTaxOrder salesTaxOrder)
        {
            /*
             * Assuming customer has been returned from the Customer Service based on it's Id.
             */
            Customer customer = new Customer();
            customer.type = "TAXJAR";


            return await this.taxCalculatorService.CalcualteSaleTaxForOrder(customer, salesTaxOrder);
        }

    }
}
