using BigBuyApi.Services.Attribute;
using BigBuyApi.Services.AttributeGroup;
using BigBuyApi.Services.Image;
using BigBuyApi.Services.Manufacturer;
using BigBuyApi.Services.Price;
using BigBuyApi.Services.Product;
using BigBuyApi.Services.Stock;
using BigBuyApi.Services.Tag;
using BigBuyApi.Services.Taxonomy;
using BigBuyApi.Services.Variation;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddHttpClient<ITaxonomyService, BigBuyTaxonomyService>();
        services.AddHttpClient<IProductService, BigBuyProductService>();
        services.AddHttpClient<IAttributeService, BigBuyAttributeService>();
        services.AddHttpClient<IAttributeGroupService, BigBuyAttributeGroupService>();
        services.AddHttpClient<IManufacturerService, BigBuyManufacturerService>();
        services.AddHttpClient<IImageService, BigBuyImageService>();
        services.AddHttpClient<IPriceService, BigBuyPriceService>();
        services.AddHttpClient<IVariationService, BigBuyVariationService>();
        services.AddHttpClient<IStockService, BigBuyStockService>();
        services.AddHttpClient<ITagService,  BigBuyTagService>();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();