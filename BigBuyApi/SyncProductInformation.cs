using BigBuyApi.Services.ProductInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncProductInformation
    {
        private readonly ILogger<SyncProductInformation> _logger;
        private readonly IProductInformationService _productInformationService;

        public SyncProductInformation(ILogger<SyncProductInformation> logger, IProductInformationService productInformationService)
        {
            _logger = logger;
            _productInformationService = productInformationService;
        }

        [Function(nameof(BigBuyApi.SyncProductInformation))]
        [SqlOutput(Model.Constant.SqlTableName.ProductInformation, Model.Constant.SqlConnectionKey.StringValue)]
        public async Task<List<Model.Domain.ProductInformation>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return await _productInformationService.GetAllProductInformationWithPagination(Model.Constant.IsoCode.English, Model.Constant.SelectedTaxonomy.HealthAndPersonalCare);
        }
    }
}
