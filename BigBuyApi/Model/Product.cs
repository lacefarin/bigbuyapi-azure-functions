using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class Product
    {

        public int? Manufacturer { get; set; }
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Ean13 { get; set; }
        public float Weight { get; set; }

        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public string? DateUpd { get; set; }

        public int Category { get; set; }
        public string? DateUpdDescription { get; set; }
        public string? DateUpdImages { get; set; }
        public string? DateUpdStock { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public int Taxonomy { get; set; }
        public string? DateAdd { get; set; }
        public string Video { get; set; }
        public int Active { get; set; }
        public bool Attributes { get; set; }
        public bool Categories { get; set; }
        public bool Images { get; set; }
        public int TaxRate { get; set; }
        public int TaxId { get; set; }
        public float InShopsPrice { get; set; }
        public string Condition { get; set; }
        public string LogisticClass { get; set; }
        public bool Tags { get; set; }
        public string? DateUpdProperties { get; set; }
        public string? DateUpdCategories { get; set; }
        public string? Intrastat { get; set; }
        public string? PartNumber { get; set; }
        public int? Canon { get; set; }
    }
}
