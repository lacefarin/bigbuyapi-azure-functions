using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.Domain;

namespace BigBuyApi.Model.DTO
{
    public class ProductPrice : Price
    {
        public List<BigBuyPriceLargeQuantities>? PriceLargeQuantities { get; set; }
    }
}
