using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.DTO
{
    public class ProductLineItem
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public float unit_price { get; set; }
        public float discount { get; set; }
    }
}
