using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.DTO
{
    public class Address
    {
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }

        public string id { get; set; }
    }
}
