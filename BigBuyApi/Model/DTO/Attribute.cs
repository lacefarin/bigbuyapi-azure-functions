using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.DTO
{
    public class Attribute
    {
        public int Id { get; set; }
        public int AttributeGroup { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}
