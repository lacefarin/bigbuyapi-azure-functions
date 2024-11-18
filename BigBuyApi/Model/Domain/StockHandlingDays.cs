using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.DTO;

namespace BigBuyApi.Model.Domain
{
    public class StockHandlingDays : BigBuyStockHandlingDays
    {
        public int StockId { get; set; }
    }
}
