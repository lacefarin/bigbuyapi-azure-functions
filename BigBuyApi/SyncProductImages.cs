using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Services.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncProductImages
    {
        private readonly ILogger<SyncProductImages> _logger;
        private readonly IImageService _imageService;

        public SyncProductImages(ILogger<SyncProductImages> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [Function(nameof(BigBuyApi.SyncProductImages))]
        [SqlOutput(SqlTableName.ProductImage, SqlConnectionKey.StringValue)]
        public async Task<List<Image>?> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return await _imageService.GetAllImagesWithPaginationForSql(SelectedTaxonomy.HealthAndPersonalCare);
        }
    }
}
