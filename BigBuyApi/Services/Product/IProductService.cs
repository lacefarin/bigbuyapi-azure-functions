using BigBuyApi.Model;
using BigBuyApi.Networking;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Product
{
    public interface IProductService
    {
        Task<List<Model.BigBuyProduct>?> GetProducts(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.BigBuyProduct>> GetAllProductsWithPagination(int parentTaxonomy);
        Task<(List<Model.Product>?, List<PriceLargeQuantity>?)> GetAllProductsWithPriceLargeQuantities(int parentTaxonomy);

    }
}
