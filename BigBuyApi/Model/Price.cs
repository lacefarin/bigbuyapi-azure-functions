using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class Price
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public float WholesalePrice { get; set; }
        public float RetailPrice { get; set; }
        public float InShopsPrice { get; set; }
    }
}
