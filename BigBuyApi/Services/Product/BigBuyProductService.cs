﻿using BigBuyApi.Model;
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

namespace BigBuyApi.Services.Product
{
    public class BigBuyProductService : IProductService
    {

        private readonly BigBuyClient _client;
        public BigBuyProductService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }
        public async Task<List<BigBuyProduct>?> GetProducts(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}"},
                { BigBuyParameters.PageSize, $"{pageSize}"},
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.Products, parameters);

            return await _client.GetBigBuyData<BigBuyProduct>(reqData);
        }

        public async Task<List<BigBuyProduct>> GetAllProductsWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<BigBuyProduct>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetProducts);
        }

        public async Task<(List<Model.Domain.Product>?, List<PriceLargeQuantity>?)> GetAllProductsWithPriceLargeQuantities(int parentTaxonomy)
        {
            var products = await GetAllProductsWithPagination(parentTaxonomy);

            if (products.IsNullOrEmpty()) { return (null, null);  }

            var productsSql = new List<Model.Domain.Product>();
            var priceLargeQuantities = new List<PriceLargeQuantity>();

            foreach (var p in products)
            {
                if (p.PriceLargeQuantities != null)
                {

                    foreach (var plq in p.PriceLargeQuantities)
                    {
                        var priceLargeQuantity = new PriceLargeQuantity()
                        {
                            Id = plq.Id,
                            Quantity = plq.Quantity,
                            Price = plq.Price,
                            ProductId = p.Id
                        };

                        priceLargeQuantities.Add(priceLargeQuantity);
                    }
                }

                Model.Domain.Product product = p;
                productsSql.Add(product);
            }

            return (productsSql, priceLargeQuantities);
        }
    }
}
