using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Price
{
    public class BigBuyPriceService: IPriceService
    {
        private readonly BigBuyClient _client;
        public BigBuyPriceService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.ProductPrice>?> GetProductPrices(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IncludePriceLargeQuantities, null },
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" },
            };

            var reqData = new RequestData(BigBuyPath.ProductPrices, parameters);

            return await _client.GetBigBuyData<Model.ProductPrice>(reqData);
        }

        public async Task<List<Model.ProductPrice>?> GetProductVariationPrices(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IncludePriceLargeQuantities, null },
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" },
            };

            var reqData = new RequestData(BigBuyPath.ProductVariationPrices, parameters);

            return await _client.GetBigBuyData<Model.ProductPrice>(reqData);
        }

        public async Task<(List<Model.Price>?, List<Model.PriceLargeQuantity>?)> GetAllProductPriceWithPagination(int parentTaxonomy)
        {
            var servicePrice = new PaginationService<Model.ProductPrice>();

            var prices = await servicePrice.FetchUntilEmptyResult(parentTaxonomy, GetProductPrices);

            if (prices == null) { return (null, null); }

            List<Model.Price> pricesSql = new List<Model.Price>();

            var priceLargeQuantities = new List<Model.PriceLargeQuantity>();

            foreach (var pr in prices)
            {
                if (pr.PriceLargeQuantities != null)
                {
                    foreach (var plq in pr.PriceLargeQuantities)
                    {
                        Model.PriceLargeQuantity priceLargeQuantity = new Model.PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = pr.Id,
                        };
                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Price price = new Model.Price()
                {
                    Id = pr.Id,
                    Sku = pr.Sku,
                    WholesalePrice = pr.WholesalePrice,
                    RetailPrice = pr.RetailPrice,
                    InShopsPrice = pr.InShopsPrice,
                };

                pricesSql.Add(price);
            }

            return (pricesSql, priceLargeQuantities);
        }

        public async Task<(List<Model.Price>?, List<Model.PriceLargeQuantity>?)> GetAllProductVariationPriceWithPagination(int parentTaxonomy)
        {
            var servicePrice = new PaginationService<Model.ProductPrice>();

            var prices = await servicePrice.FetchUntilEmptyResult(parentTaxonomy, GetProductVariationPrices);

            if (prices == null) { return (null, null); }

            List<Model.Price> pricesSql = new List<Model.Price>();

            var priceLargeQuantities = new List<Model.PriceLargeQuantity>();

            foreach (var pr in prices)
            {
                if (pr.PriceLargeQuantities != null)
                {
                    foreach (var plq in pr.PriceLargeQuantities)
                    {
                        Model.PriceLargeQuantity priceLargeQuantity = new Model.PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = pr.Id,
                        };
                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Price price = new Model.Price()
                {
                    Id = pr.Id,
                    Sku = pr.Sku,
                    WholesalePrice = pr.WholesalePrice,
                    RetailPrice = pr.RetailPrice,
                    InShopsPrice = pr.InShopsPrice,
                };

                pricesSql.Add(price);
            }

            return (pricesSql, priceLargeQuantities);
        }
    }
}