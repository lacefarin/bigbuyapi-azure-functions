using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;

namespace BigBuyApi.Services.Price
{
    public interface IPriceService
    {
        Task<List<ProductPrice>?> GetProductPrices(int page, int pageSize, int parentTaxonomy);
        Task<List<ProductPrice>?> GetProductVariationPrices(int page, int pageSize, int parentTaxonomy);
        Task<(List<Model.Domain.Price>?, List<PriceLargeQuantity>?)> GetAllProductPriceWithPagination(int parentTaxonomy);
        Task<(List<Model.Domain.Price>?, List<PriceLargeQuantity>?)> GetAllProductVariationPriceWithPagination(int parentTaxonomy);
    }
}
