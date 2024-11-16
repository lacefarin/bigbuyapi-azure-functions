using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public BigBuyTag Tag { get; set; }
    }
}
