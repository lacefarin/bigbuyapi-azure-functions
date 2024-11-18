using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Stock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class TestSyncVariationStock
    {
        private readonly ILogger<TestSyncVariationStock> _logger;
        private readonly IStockService _stockService;

        public TestSyncVariationStock(ILogger<TestSyncVariationStock> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [Function(nameof(BigBuyApi.TestSyncVariationStock))]
        public async Task<OutputType> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var result = await _stockService.GetVariationStockWithHandlingDays(SelectedTaxonomy.HealthAndPersonalCare);
            return new OutputType()
            {
                Stocks = result.Item1,
                StockHandlingDays = result.Item2,
            };
        }

        public class OutputType
        {
            [SqlOutput(SqlTableName.Stock, SqlConnectionKey.StringValue)]
            public List<Stock>? Stocks { get; set; }

            [SqlOutput(SqlTableName.ProductStockHandlingDay, SqlConnectionKey.StringValue)]
            public List<Model.Domain.StockHandlingDays>? StockHandlingDays { get; set; }
        }
    }
}
