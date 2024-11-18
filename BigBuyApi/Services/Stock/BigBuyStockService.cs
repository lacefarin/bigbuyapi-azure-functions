using BigBuyApi.Model;
using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
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

        public async Task<List<BigBuyStock>?> GetProductStock(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductStock, parameters);
            return await _client.GetBigBuyData<BigBuyStock>(reqData);
        }

        public async Task<List<BigBuyStock>?> GetVariationStock(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductVariationStock, parameters);
            return await _client.GetBigBuyData<BigBuyStock>(reqData);
        }

        public async Task<List<BigBuyStock>?> GetProductStockWithPagination(int parentTaxonomy)
        { 
            var paginationService = new PaginationService<BigBuyStock>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetProductStock);
        }

        public async Task<List<BigBuyStock>?> GetVariationStockWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<BigBuyStock>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetVariationStock);
        }

        public async Task<(List<Model.Domain.Stock>?, List<StockHandlingDays>?)> GetProductStockWithHandlingDays(int parentTaxonomy)
        { 
            var bbStock = await GetProductStockWithPagination(parentTaxonomy);

            if (bbStock.IsNullOrEmpty()) { return (null, null); }

            var stocks = new List<Model.Domain.Stock>();
            var stockHandlingDays = new List<StockHandlingDays>();

            foreach (var bbs in bbStock)
            {
                if (bbs.Stocks != null)
                {
                    foreach (var shd in bbs.Stocks)
                    {
                        var stockHandlingDay = new StockHandlingDays()
                        {
                            StockId = bbs.Id,
                            Quantity = shd.Quantity,
                            MinHandlingDays = shd.MinHandlingDays,
                            MaxHandlingDays = shd.MaxHandlingDays,
                            Warehouse = shd.Warehouse,
                        };

                        stockHandlingDays.Add(stockHandlingDay);
                    }
                }

                Model.Domain.Stock stock = bbs;
                stocks.Add(stock);
            }

            return (stocks, stockHandlingDays);
        }

        public async Task<(List<Model.Domain.Stock>?, List<StockHandlingDays>?)> GetVariationStockWithHandlingDays(int parentTaxonomy)
        {
            var bbStock = await GetVariationStockWithPagination(parentTaxonomy);

            if (bbStock.IsNullOrEmpty()) { return (null, null); }

            var stocks = new List<Model.Domain.Stock>();
            var stockHandlingDays = new List<StockHandlingDays>();

            foreach (var bbs in bbStock)
            {
                if (bbs.Stocks != null)
                {
                    foreach (var shd in bbs.Stocks)
                    {
                        var stockHandlingDay = new StockHandlingDays()
                        {
                            StockId = bbs.Id,
                            Quantity = shd.Quantity,
                            MinHandlingDays = shd.MinHandlingDays,
                            MaxHandlingDays = shd.MaxHandlingDays,
                            Warehouse = shd.Warehouse,
                        };

                        stockHandlingDays.Add(stockHandlingDay);
                    }
                }

                Model.Domain.Stock stock = bbs;
                stocks.Add(stock);
            }

            return (stocks, stockHandlingDays);
        }
    }
}
