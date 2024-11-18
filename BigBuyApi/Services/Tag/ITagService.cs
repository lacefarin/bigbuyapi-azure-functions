using BigBuyApi.Model.Domain;
using BigBuyApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Tag
{
    public interface ITagService
    {
        Task<List<BigBuyProductTag>?> GetTags(string isoCode, int page, int pageSize, int parentTaxonomy);
        Task<List<BigBuyProductTag>?> GetTagsWithPagination(string isoCode, int parentTaxonomy);
        Task<(List<Model.Domain.Tag>?, List<ProductTag>?)> GetTagsWithRelation(string isoCode, int parentTaxonomy);
    }
}
