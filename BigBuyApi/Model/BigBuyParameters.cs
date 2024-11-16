using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    internal readonly struct BigBuyParameters
    {
        internal const string IsoCode = "isoCode";
        internal const string FirstLevel = "firstLevel";
        internal const string Page = "page";
        internal const string PageSize = "pageSize";
        internal const string ParentTaxonomy = "parentTaxonomy";
        internal const string IncludePriceLargeQuantities = "includePriceLargeQuantities";
    }
}
