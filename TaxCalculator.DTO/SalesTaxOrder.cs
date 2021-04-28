using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.DTO
{
    public class SalesTaxOrder
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }

        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public string customer_id { get; set; }
        public string exemption_type { get; set; }
        public Address[] nexus_addresses { get; set; }

        public ProductLineItem[] line_items { get; set; }

    }
}
