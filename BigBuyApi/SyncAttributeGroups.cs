using BigBuyApi.Model;
using BigBuyApi.Services.AttributeGroup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncAttributeGroups
    {
        private readonly ILogger<SyncAttributeGroups> _logger;

        private readonly IAttributeGroupService _service; 

        public SyncAttributeGroups(ILogger<SyncAttributeGroups> logger, IAttributeGroupService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function(nameof(BigBuyApi.SyncAttributeGroups))]
        [SqlOutput(SqlTableName.AttributeGroup, SqlConnectionKey.StringValue)]
        public async Task<List<Model.AttributeGroup>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return await _service.GetAllAttributeGroupsWithPagination(Model.IsoCode.English);
        }
    }
}
