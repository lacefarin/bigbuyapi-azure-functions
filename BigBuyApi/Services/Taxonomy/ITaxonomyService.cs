namespace BigBuyApi.Services.Taxonomy
{
    public interface ITaxonomyService
    {
        Task<List<Model.Taxonomy>?> GetAllTaxonomies();
        Task<List<Model.Taxonomy>?> GetFirstLevelTaxonomies();
        List<Model.Taxonomy> GetAllRelatedTaxonomies(int parentId, List<Model.Taxonomy> taxonomies);
        Task<List<Model.ProductTaxonomy>?> GetProductTaxonomies(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.ProductTaxonomy>?> GetAllProductTaxonomiesWithPagination(int parentTaxonomy);
    }
}
