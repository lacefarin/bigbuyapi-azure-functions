using BigBuyApi.Model;
using BigBuyApi.Services.Stock;
using BigBuyApi.Services.Variation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncProductStock
    {
        private readonly ILogger<TestSyncVariationStock> _logger;
        private readonly IStockService _stockService;

        public SyncProductStock(ILogger<TestSyncVariationStock> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [Function(nameof(BigBuyApi.SyncProductStock))]
        public async Task<OutputType> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var result = await _stockService.GetProductStockWithHandlingDays(SelectedTaxonomy.HealthAndPersonalCare);
            return new OutputType()
            {
                Stocks = result.Item1,
                StockHandlingDays = result.Item2,
            };
        }

        public class OutputType
        {
            [SqlOutput(SqlTableName.ProductStock, SqlConnectionKey.StringValue)]
            public List<Model.Stock>? Stocks { get; set; }
            [SqlOutput(SqlTableName.ProductStockHandlingDay, SqlConnectionKey.StringValue)]
            public List<Model.StockHandlingDays>? StockHandlingDays { get; set; }
        }

    }
}
