using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.DTO
{
    public class BigBuyImage
    {
        public int Id { get; set; }
        public bool IsCover { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Logo { get; set; }
        public bool WhiteBackground { get; set; }
        public int Position { get; set; }
        public int EnergyEfficiency { get; set; }
        public int Icon { get; set; }
        public int MarketingPhoto { get; set; }
        public int PackagingPhoto { get; set; }
        public int Brand { get; set; }
        public bool GpsrLabel { get; set; }
        public bool GpsrWarning { get; set; }
    }
}
