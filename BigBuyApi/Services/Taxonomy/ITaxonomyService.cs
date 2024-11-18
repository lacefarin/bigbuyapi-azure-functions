using BigBuyApi.Model.Domain;

namespace BigBuyApi.Services.Taxonomy
{
    public interface ITaxonomyService
    {
        Task<List<Model.Domain.Taxonomy>?> GetAllTaxonomies();
        Task<List<Model.Domain.Taxonomy>?> GetFirstLevelTaxonomies();
        List<Model.Domain.Taxonomy> GetAllRelatedTaxonomies(int parentId, List<Model.Domain.Taxonomy> taxonomies);
        Task<List<ProductTaxonomy>?> GetProductTaxonomies(int page, int pageSize, int parentTaxonomy);
        Task<List<ProductTaxonomy>?> GetAllProductTaxonomiesWithPagination(int parentTaxonomy);
    }
}
