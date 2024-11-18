using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class TestSyncTags
    {
        private readonly ILogger<TestSyncTags> _logger;
        private readonly ITagService _tagService;

        public TestSyncTags(ILogger<TestSyncTags> logger, ITagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        [Function(nameof(BigBuyApi.TestSyncTags))]
        public async Task<OutputType?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var result = await _tagService.GetTagsWithRelation(IsoCode.English, SelectedTaxonomy.HealthAndPersonalCare);

           return new OutputType()
           {
               tags = result.Item1,
               productTags = result.Item2,
           };
        }

        public class OutputType
        {
            [SqlOutput(SqlTableName.Tag, SqlConnectionKey.StringValue)]
            public List<Tag>? tags { get; set; }

            [SqlOutput(SqlTableName.ProductTag, SqlConnectionKey.StringValue)]
            public List<ProductTag>? productTags { get; set; }
        }
    }
}
