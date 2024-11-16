using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class ProductVariation
    { 
        public int Id { get; set; }
        public string Sku {  get; set; }
        public string Ean13 { get; set; }
        public float ExtraWeight { get; set; }
        public int Product {  get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public float InShopsPrice { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public string LogisticClass { get; set; }
        public string? PartNumber { get; set; }
        public int? Canon { get; set; }
    }
}
