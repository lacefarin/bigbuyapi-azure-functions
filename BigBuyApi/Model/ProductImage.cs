using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class ProductImage
    {
        public int Id { get; set; }
        public List<BigBuyImage> Images { get; set; }
    }
}
