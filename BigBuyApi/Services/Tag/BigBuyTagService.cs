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

namespace BigBuyApi.Services.Tag
{
    public class BigBuyTagService : ITagService
    {
        private readonly BigBuyClient _client;
        public BigBuyTagService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<BigBuyProductTag>?> GetTags(string isoCode, int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IsoCode, isoCode },
                { BigBuyParameters.Page, $"{page}"},
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}"}
            };

            var reqData = new RequestData(BigBuyPath.ProductTags, parameters);
            return await _client.GetBigBuyData<BigBuyProductTag>(reqData);
        }

        public async Task<List<BigBuyProductTag>?> GetTagsWithPagination(string isoCode, int parentTaxonomy)
        {
            var paginationService = new PaginationService<BigBuyProductTag>();
            return await paginationService.FetchUntilEmptyResult(isoCode, parentTaxonomy, GetTags);
        }

        public async Task<(List<Model.Domain.Tag>?, List<ProductTag>?)> GetTagsWithRelation(string isoCode, int parentTaxonomy)
        {
            var bbProductTags = await GetTagsWithPagination(isoCode, parentTaxonomy);

            if (bbProductTags == null) return (null, null);

            var tags = new HashSet<Model.Domain.Tag>();
            var productTags = new List<ProductTag>();

            foreach (var bbProductTag in bbProductTags)
            {
                ProductTag productTag = new ProductTag()
                {
                    Id = bbProductTag.Id,
                    Sku = bbProductTag.Sku,
                    TagId = bbProductTag.Tag.Id
                };

                tags.Add(bbProductTag.Tag);
                productTags.Add(productTag);
            }

            return (tags.ToList(), productTags);

        }
    }
}
