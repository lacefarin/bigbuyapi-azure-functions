﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public int Sku {  get; set; }
        public List<StockHandlingDays> Stocks { get; set; }
    }
}
