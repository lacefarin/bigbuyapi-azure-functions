using BigBuyApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Stock
{
    public interface IStockService
    {
        Task<List<Model.BigBuyStock>?> GetProductStock(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.BigBuyStock>?> GetVariationStock(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.BigBuyStock>?> GetProductStockWithPagination(int parentTaxonomy);
        Task<(List<Model.Stock>?, List<StockHandlingDays>?)> GetProductStockWithHandlingDays(int parentTaxonomy);
        Task<(List<Model.Stock>?, List<VariationStockHandlingDays>?)> GetVariationStockWithHandlingDays(int parentTaxonomy);
    }
}
