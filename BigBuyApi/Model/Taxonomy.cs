using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public class Taxonomy
    {
        /*
"id": 2,
"name": "Acampada y senderismo",
"url": "deportes-y-aire-libre-acampada-y-senderismo",
"parentTaxonomy": 19756,
"dateAdd": "2021-10-20 13:53:25",
"dateUpd": "2023-03-01 16:18:08",
"urlImages": "https://cdnbigbuy.com/images/8435310192985_R02.jpg",
"isoCode": "es"
*/
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? ParentTaxonomy { get; set; }
        public string? DateAdd { get; set; }
        public string? DateUpd { get; set; }
        public string? UrlImages { get; set; }
        public string? IsoCode { get; set; }
    }
}
