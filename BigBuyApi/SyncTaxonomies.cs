using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Taxonomy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BigBuyApi
{
    public class SyncTaxonomies
    {
        private readonly ILogger<SyncTaxonomies> _logger;
        private readonly ITaxonomyService _taxonomyService;

        public SyncTaxonomies(ILogger<SyncTaxonomies> logger, ITaxonomyService taxonomyService)
        {
            _logger = logger;
            _taxonomyService = taxonomyService;
        }

        [Function(nameof(BigBuyApi.SyncTaxonomies))]
        [SqlOutput("dbo.Taxonomy", "SqlConnectionString")]
        public async Task<List<Taxonomy>> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req
        )
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var taxonomies = await _taxonomyService.GetAllTaxonomies();

            if (taxonomies == null) {
                return [];
            }

            // Get all related taxonomies for parentId 19736 and 6451
            var relatedTaxonomies = _taxonomyService.GetAllRelatedTaxonomies(19736, taxonomies);

            return relatedTaxonomies;
        }
    }

}
