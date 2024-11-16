using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Price
{
    public interface IPriceService
    {
        Task<List<Model.ProductPrice>?> GetProductPrices(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.ProductPrice>?> GetProductVariationPrices(int page, int pageSize, int parentTaxonomy);
        Task<(List<Model.Price>?, List<Model.PriceLargeQuantity>?)> GetAllProductPriceWithPagination(int parentTaxonomy);
        Task<(List<Model.Price>?, List<Model.PriceLargeQuantity>?)> GetAllProductVariationPriceWithPagination(int parentTaxonomy);
    }
}
