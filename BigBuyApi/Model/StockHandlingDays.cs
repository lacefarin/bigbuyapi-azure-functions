﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class StockHandlingDays: BigBuyStockHandlingDays
    {
        public int ProductStockId { get; set; }
    }
}
