using BigBuyApi.Model;
using BigBuyApi.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BigBuyApi
{
    public class SyncProducts
    {
        private readonly ILogger<SyncProducts> _logger;
        private readonly IProductService _productService;

        public SyncProducts(ILogger<SyncProducts> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Function(nameof(BigBuyApi.SyncProducts))]
        public async Task<OutputType> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            var result = await _productService.GetAllProductsWithPriceLargeQuantities(Model.SelectedTaxonomy.HealthAndPersonalCare);
            return new OutputType()
            {
                Products = result.Item1,
                PriceLargeQuantities = result.Item2,
            };
        }

        public class OutputType
        {
            [SqlOutput(SqlTableName.Product, SqlConnectionKey.StringValue)]
            public List<Model.Product>? Products { get; set; }

            [SqlOutput(SqlTableName.ProductPriceLargeQuantity, SqlConnectionKey.StringValue)]
            public List<Model.PriceLargeQuantity>? PriceLargeQuantities { get; set; }

            //public HttpResponseData HttpResponse { get; set; }
        }
    }
}
