using BigBuyApi.Model;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Variation
{
    public interface IVariationService
    {
        Task<List<Model.DTO.BigBuyProduct>?> GetProductVariations(int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyVariation>?> GetVariations(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.DTO.BigBuyProduct>?> GetAllProductVariationsWithPagination(int parentTaxonomy);
        Task<List<BigBuyVariation>?> GetAllVariationsWithPagination(int parentTaxonomy);
        Task<(List<Model.Domain.Product>?, List<PriceLargeQuantity>?)> GetAllProductVariationsWithPriceLargeQuantities(int parentTaxonomy);
        Task<List<VariationAttribute>?> GetAllProductVariationsWithAttributes(int parentTaxonomy);
    }
}
;