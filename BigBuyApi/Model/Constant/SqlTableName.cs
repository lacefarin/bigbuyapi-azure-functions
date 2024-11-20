using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.Constant
{
    public readonly struct SqlTableName
    {
        public const string Attribute = "dbo.Attribute";
        public const string AttributeGroup = "dbo.AttributeGroup";
        public const string Manufacturer = "Manufacturer";
        public const string ProductImage = "dbo.Image";
        public const string ProductInformation = "dbo.ProductInformation";
        public const string ProductPriceLargeQuantity = "PriceLargeQuantity";
        public const string Product = "dbo.Product";
        public const string ProductTag = "dbo.ProductTag";
        public const string Stock = "dbo.Stock";
        public const string ProductStockHandlingDay = "dbo.StockHandlingDay";
        public const string Taxonomy = "dbo.Taxonomy";
        public const string Tag = "dbo.Tag";
        public const string ProductTaxonomy = "dbo.Taxonomy";
        public const string VariationAttribute = "dbo.VariationAttribute";
    }
}
