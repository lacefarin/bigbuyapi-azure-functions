using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class StockHandlingDays
    {
        public int Quantity { get; set; }
        public int MinHandlingDays { get; set; }
        public int MaxHandlingDays { get; set; }
        public int Warehouse {  get; set; }
    }
}
