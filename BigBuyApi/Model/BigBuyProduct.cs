using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class BigBuyProduct: Product
    {
        public List<Model.BigBuyPriceLargeQuantities>? PriceLargeQuantities { get; set; }
    }
}
