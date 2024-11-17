using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    internal readonly struct BigBuyPath
    {
        internal const string Taxonomies = "/rest/catalog/taxonomies.json";
        internal const string ProductsTaxonomies = "/rest/catalog/productstaxonomies.json";
        internal const string Products = "/rest/catalog/products.json";
        internal const string Attributes = "rest/catalog/attributes.json";
        internal const string AttributeGroups = "/rest/catalog/attributegroups.json";
        internal const string Manufacturers = "/rest/catalog/manufacturers.json";
        internal const string ProductImages = "/rest/catalog/productsimages.json";
        internal const string ProductPrices = "/rest/catalog/productprices.json";
        internal const string ProductVariationPrices = "/rest/catalog/productvariationprices.json";
        internal const string ProductStock = "/rest/catalog/productsstockbyhandlingdays.json";
        internal const string ProductVariationStock = "/rest/catalog/productsvariationsstockbyhandlingdays.json";
        internal const string ProductTags = "/rest/catalog/productstags.json";
        internal const string ProductVariations = "/rest/catalog/productsvariations.json";
        internal const string Variations = "/rest/catalog/variations.json";

    }
}
