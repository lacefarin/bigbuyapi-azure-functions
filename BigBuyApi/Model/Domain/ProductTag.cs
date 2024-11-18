using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.Domain
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int TagId { get; set; }
    }
}
