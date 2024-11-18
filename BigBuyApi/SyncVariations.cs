using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Variation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncVariations
    {
        private readonly ILogger<SyncVariations> _logger;
        private readonly IVariationService _variationService;

        public SyncVariations(ILogger<SyncVariations> logger, IVariationService variationService)
        {
            _logger = logger;
            _variationService = variationService;
        }

        [Function(nameof(BigBuyApi.SyncVariations))]
        [SqlOutput(SqlTableName.VariationAttribute, SqlConnectionKey.StringValue)]
        public async Task<List<VariationAttribute>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var variationAttributes = await _variationService.GetAllProductVariationsWithAttributes(SelectedTaxonomy.HealthAndPersonalCare);
            return variationAttributes;
        }
    }
}
