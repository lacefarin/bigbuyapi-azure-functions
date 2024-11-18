using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Taxonomy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BigBuyApi
{
    public class SyncProductsTaxonomies
    {
        private readonly ILogger<SyncProductsTaxonomies> _logger;
        private readonly ITaxonomyService _taxonomyService;
        private const int PageSize = 1000;
        // Number of tasks to run in parallel
        private const int TaskBatchSize = 5;
        private const int parentTaxonomy = 19669;

        public SyncProductsTaxonomies(ILogger<SyncProductsTaxonomies> logger, ITaxonomyService taxonomyService)
        {
            _logger = logger;
            _taxonomyService = taxonomyService;
        }

        [Function(nameof(BigBuyApi.SyncProductsTaxonomies))]
        [SqlOutput(SqlTableName.ProductTaxonomy, SqlConnectionKey.StringValue)]
        public async Task<List<ProductTaxonomy>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var productsTaxonomies = await _taxonomyService.GetAllProductTaxonomiesWithPagination(parentTaxonomy);
            return productsTaxonomies;
        }
    }
}
