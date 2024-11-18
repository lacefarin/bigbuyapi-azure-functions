using BigBuyApi.Model.Constant;
using BigBuyApi.Model.DTO;
using BigBuyApi.Services.Manufacturer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncManufacturers
    {
        private readonly ILogger<SyncManufacturers> _logger;
        private readonly IManufacturerService _manufacturerService;

        public SyncManufacturers(ILogger<SyncManufacturers> logger, IManufacturerService manufacturerService)
        {
            _logger = logger;
            _manufacturerService = manufacturerService;
        }

        [Function(nameof(BigBuyApi.SyncManufacturers))]
        [SqlOutput(Model.Constant.SqlTableName.Manufacturer, SqlConnectionKey.StringValue)]
        public async Task<List<Manufacturer>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return await _manufacturerService.GetAllManufacturersWithPagination(SelectedTaxonomy.HealthAndPersonalCare);
        }
    }
}
