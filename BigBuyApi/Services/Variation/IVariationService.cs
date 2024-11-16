using BigBuyApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Variation
{
    public interface IVariationService
    {
        Task<List<BigBuyProductVariation>?> GetProductVariations(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.BigBuyVariation>?> GetVariations(int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyProductVariation>?> GetAllProductVariationsWithPagination(int parentTaxonomy);
        Task<List<Model.BigBuyVariation>?> GetAllVariationsWithPagination(int parentTaxonomy);
        Task<(List<Model.ProductVariation>?, List<VariationPriceLargeQuantity>?)> GetAllProductVariationsWithPriceLargeQuantities(int parentTaxonomy);
        Task<List<VariationAttribute>?> GetAllProductVariationsWithAttributes(int parentTaxonomy);
    }
}
