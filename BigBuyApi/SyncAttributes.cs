using BigBuyApi.Model.Constant;
using BigBuyApi.Services.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncAttributes
    {
        private readonly ILogger<SyncAttributes> _logger;
        private readonly IAttributeService _attributeService;

        public SyncAttributes(ILogger<SyncAttributes> logger, IAttributeService attributeService)
        {
            _logger = logger;
            _attributeService = attributeService;
        }

        [Function(nameof(BigBuyApi.SyncAttributes))]
        [SqlOutput(SqlTableName.Attribute, SqlConnectionKey.StringValue)]
        public async Task<List<Model.DTO.Attribute>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return await _attributeService.GetAllProductsWithPagination(IsoCode.English);
        }
    }
}
