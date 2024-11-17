using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Stock
{
    public class BigBuyStockService: IStockService
    {
        private readonly BigBuyClient _client;
        public BigBuyStockService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.BigBuyStock>?> GetProductStock(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductStock, parameters);
            return await _client.GetBigBuyData<Model.BigBuyStock>(reqData);
        }

        public async Task<List<Model.BigBuyStock>?> GetVariationStock(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductVariationStock, parameters);
            return await _client.GetBigBuyData<Model.BigBuyStock>(reqData);
        }

        public async Task<List<Model.BigBuyStock>?> GetProductStockWithPagination(int parentTaxonomy)
        { 
            var paginationService = new PaginationService<Model.BigBuyStock>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetProductStock);
        }

        public async Task<List<Model.BigBuyStock>?> GetVariationStockWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<Model.BigBuyStock>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetVariationStock);
        }

        public async Task<(List<Model.Stock>?, List<StockHandlingDays>?)> GetProductStockWithHandlingDays(int parentTaxonomy)
        { 
            var bbStock = await GetProductStockWithPagination(parentTaxonomy);

            if (bbStock.IsNullOrEmpty()) { return (null, null); }

            var stocks = new List<Model.Stock>();
            var stockHandlingDays = new List<StockHandlingDays>();

            foreach (var bbs in bbStock)
            {
                if (bbs.Stocks != null)
                {
                    foreach (var shd in bbs.Stocks)
                    {
                        var stockHandlingDay = new StockHandlingDays()
                        {
                            ProductStockId = bbs.Id,
                            Quantity = shd.Quantity,
                            MinHandlingDays = shd.MinHandlingDays,
                            MaxHandlingDays = shd.MaxHandlingDays,
                            Warehouse = shd.Warehouse,
                        };

                        stockHandlingDays.Add(stockHandlingDay);
                    }
                }

                Model.Stock stock = bbs;
                stocks.Add(stock);
            }

            return (stocks, stockHandlingDays);
        }

        public async Task<(List<Model.Stock>?, List<VariationStockHandlingDays>?)> GetVariationStockWithHandlingDays(int parentTaxonomy)
        {
            var bbStock = await GetVariationStockWithPagination(parentTaxonomy);

            if (bbStock.IsNullOrEmpty()) { return (null, null); }

            var stocks = new List<Model.Stock>();
            var stockHandlingDays = new List<VariationStockHandlingDays>();

            foreach (var bbs in bbStock)
            {
                if (bbs.Stocks != null)
                {
                    foreach (var shd in bbs.Stocks)
                    {
                        var stockHandlingDay = new VariationStockHandlingDays()
                        {
                            VariationStockId = bbs.Id,
                            Quantity = shd.Quantity,
                            MinHandlingDays = shd.MinHandlingDays,
                            MaxHandlingDays = shd.MaxHandlingDays,
                            Warehouse = shd.Warehouse,
                        };

                        stockHandlingDays.Add(stockHandlingDay);
                    }
                }

                Model.Stock stock = bbs;
                stocks.Add(stock);
            }

            return (stocks, stockHandlingDays);
        }
    }
}
