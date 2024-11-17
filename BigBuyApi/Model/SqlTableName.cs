using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model
{
    public readonly struct SqlTableName
    {
        public const string Taxonomy = "dbo.Taxonomy";
        public const string ProductTaxonomy = "dbo.ProductTaxonomy";
        public const string Attribute = "dbo.Attribute";
        public const string AttributeGroup = "dbo.AttributeGroup";
        public const string Manufacturer = "dbo.Manufacturer";
        public const string ProductImage = "dbo.ProductImage";
        public const string Product = "dbo.Product";
        public const string ProductVariation = "dbo.ProductVariation";
        public const string ProductPriceLargeQuantity = "ProductPriceLargeQuantity";
        public const string Variation = "dbo.Variation";
        public const string VariationAttribute = "dbo.VariationAttribute";
        public const string ProductVariationPriceLargeQuantity = "dbo.ProductVariationPriceLargeQuantity";
        public const string ProductStock = "dbo.ProductStock";
        public const string ProductStockHandlingDay = "dbo.ProductStockHandlingDay";
        public const string ProductVariationStock = "dbo.ProductVariationStock";
        public const string ProductVariationStockHandlingDay = "dbo.ProductVariationStockHandlingDay";
    }
}
