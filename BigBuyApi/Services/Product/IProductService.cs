using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
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
        Task<List<BigBuyProduct>?> GetProducts(int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyProduct>> GetAllProductsWithPagination(int parentTaxonomy);
        Task<(List<Model.Domain.Product>?, List<PriceLargeQuantity>?)> GetAllProductsWithPriceLargeQuantities(int parentTaxonomy);

    }
}
