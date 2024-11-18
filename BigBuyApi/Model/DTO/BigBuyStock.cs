using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.Domain;

namespace BigBuyApi.Model.DTO
{
    public class BigBuyStock : Stock
    {
        public List<BigBuyStockHandlingDays> Stocks { get; set; }
    }
}
