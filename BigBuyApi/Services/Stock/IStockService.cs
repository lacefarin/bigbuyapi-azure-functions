using BigBuyApi.Model;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Stock
{
    public interface IStockService
    {
        Task<List<BigBuyStock>?> GetProductStock(int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyStock>?> GetVariationStock(int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyStock>?> GetProductStockWithPagination(int parentTaxonomy);
        Task<(List<Model.Domain.Stock>?, List<StockHandlingDays>?)> GetProductStockWithHandlingDays(int parentTaxonomy);
        Task<(List<Model.Domain.Stock>?, List<StockHandlingDays>?)> GetVariationStockWithHandlingDays(int parentTaxonomy);
    }
}
