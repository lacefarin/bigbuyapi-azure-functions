using BigBuyApi.Model;
using BigBuyApi.Model.Constant;
using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Variation
{
    public class BigBuyVariationService: IVariationService
    {
        private readonly BigBuyClient _client;
        public BigBuyVariationService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.DTO.BigBuyProduct>?> GetProductVariations(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductVariations, parameters);
            return await _client.GetBigBuyData<Model.DTO.BigBuyProduct>(reqData);
        }

        public async Task<List<BigBuyVariation>?> GetVariations(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.Variations, parameters);
            return await _client.GetBigBuyData<BigBuyVariation>(reqData);
        }

        public async Task<List<Model.DTO.BigBuyProduct>?> GetAllProductVariationsWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<Model.DTO.BigBuyProduct>();
            var bbProductVariations = await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetProductVariations);
            return bbProductVariations;
        }

        public async Task<List<BigBuyVariation>?> GetAllVariationsWithPagination(int parentTaxonomy)
        { 
            var paginationService = new PaginationService<BigBuyVariation>();
            var bbVariations = await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetVariations);
            return bbVariations;
        }

        public async Task<(List<Model.Domain.Product>?, List<PriceLargeQuantity>?)> GetAllProductVariationsWithPriceLargeQuantities(int parentTaxonomy)
        {
            var productsVariations = await GetAllProductVariationsWithPagination(parentTaxonomy);

            if (productsVariations.IsNullOrEmpty()) { return (null, null); }

            var productsVariationSql = new List<Model.Domain.Product>();
            var priceLargeQuantities = new List<PriceLargeQuantity>();

            foreach (var pv in productsVariations)
            {
                if (pv.PriceLargeQuantities != null)
                {
                    foreach (var plq in pv.PriceLargeQuantities)
                    {
                        var priceLargeQuantity = new PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = pv.Id
                        };

                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Domain.Product productVariation = pv;
                productsVariationSql.Add(productVariation);
            }

            return (productsVariationSql, priceLargeQuantities);
        }

        public async Task<List<VariationAttribute>?> GetAllProductVariationsWithAttributes(int parentTaxonomy)
        {
            var bbVariations = await GetAllVariationsWithPagination(parentTaxonomy);

            if (bbVariations.IsNullOrEmpty()) { return null; }

            var variationAttributeRelation = new List<VariationAttribute>();

            foreach (var v in bbVariations)
            {
                if (v.Attributes.IsNullOrEmpty()) { continue; }

                foreach (var a in v.Attributes)
                {
                    var va = new VariationAttribute()
                    {
                        VariationId = v.Id,
                        AttributeId = a.Id,
                    };
                    variationAttributeRelation.Add(va);
                }
            }

            return variationAttributeRelation;
        }
    }
}
