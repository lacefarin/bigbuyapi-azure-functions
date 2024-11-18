using BigBuyApi.Model.Constant;
using BigBuyApi.Services.Variation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncProductVariations
    {
        private readonly ILogger<SyncProductVariations> _logger;
        private readonly IVariationService _variationService;

        public SyncProductVariations(ILogger<SyncProductVariations> logger, IVariationService variationService)
        {
            _logger = logger;
            _variationService = variationService;
        }

        [Function(nameof(BigBuyApi.SyncProductVariations))]
        public async Task<OutputType> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var result = await _variationService.GetAllProductVariationsWithPriceLargeQuantities(SelectedTaxonomy.HealthAndPersonalCare);
            return new OutputType()
            {
                ProductVariations = result.Item1,
                ProductVariationPriceLargeQuantity = result.Item2,
            };
        }

        public class OutputType()
        {
            [SqlOutput(SqlTableName.Product, SqlConnectionKey.StringValue)]
            public List<Model.Domain.Product>? ProductVariations { get; set; }
            [SqlOutput(SqlTableName.ProductPriceLargeQuantity, SqlConnectionKey.StringValue)]
            public List<Model.Domain.PriceLargeQuantity>? ProductVariationPriceLargeQuantity { get; set; }
        }
    }
}
