using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.DTO;

namespace BigBuyApi.Model.Domain
{
    public class PriceLargeQuantity : BigBuyPriceLargeQuantities
    {
        public int ProductId { get; set; }
    }
}
