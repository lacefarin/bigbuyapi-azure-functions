using BigBuyApi.Model;
using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
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

        public async Task<List<ProductPrice>?> GetProductPrices(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IncludePriceLargeQuantities, null },
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" },
            };

            var reqData = new RequestData(BigBuyPath.ProductPrices, parameters);

            return await _client.GetBigBuyData<ProductPrice>(reqData);
        }

        public async Task<List<ProductPrice>?> GetProductVariationPrices(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IncludePriceLargeQuantities, null },
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" },
            };

            var reqData = new RequestData(BigBuyPath.ProductVariationPrices, parameters);

            return await _client.GetBigBuyData<ProductPrice>(reqData);
        }

        public async Task<(List<Model.Domain.Price>?, List<PriceLargeQuantity>?)> GetAllProductPriceWithPagination(int parentTaxonomy)
        {
            var servicePrice = new PaginationService<ProductPrice>();

            var prices = await servicePrice.FetchUntilEmptyResult(parentTaxonomy, GetProductPrices);

            if (prices == null) { return (null, null); }

            List<Model.Domain.Price> pricesSql = new List<Model.Domain.Price>();

            var priceLargeQuantities = new List<PriceLargeQuantity>();

            foreach (var pr in prices)
            {
                if (pr.PriceLargeQuantities != null)
                {
                    foreach (var plq in pr.PriceLargeQuantities)
                    {
                        PriceLargeQuantity priceLargeQuantity = new Model.Domain.PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = pr.Id,
                        };
                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Domain.Price price = new Model.Domain.Price()
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

        public async Task<(List<Model.Domain.Price>?, List<PriceLargeQuantity>?)> GetAllProductVariationPriceWithPagination(int parentTaxonomy)
        {
            var servicePrice = new PaginationService<ProductPrice>();

            var prices = await servicePrice.FetchUntilEmptyResult(parentTaxonomy, GetProductVariationPrices);

            if (prices == null) { return (null, null); }

            List<Model.Domain.Price> pricesSql = new List<Model.Domain.Price>();

            var priceLargeQuantities = new List<PriceLargeQuantity>();

            foreach (var pr in prices)
            {
                if (pr.PriceLargeQuantities != null)
                {
                    foreach (var plq in pr.PriceLargeQuantities)
                    {
                        PriceLargeQuantity priceLargeQuantity = new Model.Domain.PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = pr.Id,
                        };
                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Domain.Price price = new Model.Domain.Price()
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