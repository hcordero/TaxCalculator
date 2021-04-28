using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.DTO
{
    public class Tax
    {
        public float order_total_amount { get; set; }
        public float shipping { get; set; }
        public float taxable_amount { get; set; }
        public float amount_to_collect { get; set; }
        public float rate { get; set; }
        public bool has_nexus { get; set; }

        public bool freight_taxable { get; set; }

        public string tax_source { get; set; }

        /*
         TODO
          Add other response properties:
           "jurisdictions": {
              "country": "US",
              "state": "CA",
              "county": "LOS ANGELES",
              "city": "LOS ANGELES"
            },
            "breakdown": {
              "taxable_amount": 15,
              "tax_collectable": 1.35,
              "combined_tax_rate": 0.09,
              "state_taxable_amount": 15,
              "state_tax_rate": 0.0625,
              "state_tax_collectable": 0.94,
              "county_taxable_amount": 15,
              "county_tax_rate": 0.0025,
              "county_tax_collectable": 0.04,
              "city_taxable_amount": 0,
              "city_tax_rate": 0,
              "city_tax_collectable": 0,
              "special_district_taxable_amount": 15,
              "special_tax_rate": 0.025,
              "special_district_tax_collectable": 0.38,
              "line_items": [
                {
                  "id": "1",
                  "taxable_amount": 15,
                  "tax_collectable": 1.35,
                  "combined_tax_rate": 0.09,
                  "state_taxable_amount": 15,
                  "state_sales_tax_rate": 0.0625,
                  "state_amount": 0.94,
                  "county_taxable_amount": 15,
                  "county_tax_rate": 0.0025,
                  "county_amount": 0.04,
                  "city_taxable_amount": 0,
                  "city_tax_rate": 0,
                  "city_amount": 0,
                  "special_district_taxable_amount": 15,
                  "special_tax_rate": 0.025,
                  "special_district_amount": 0.38
                }
              ]
            }
         */
    }

}
