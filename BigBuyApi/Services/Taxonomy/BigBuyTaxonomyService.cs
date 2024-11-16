﻿using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;


namespace BigBuyApi.Services.Taxonomy
{
    public class BigBuyTaxonomyService : ITaxonomyService
    {
        private readonly BigBuyClient _client;
        public BigBuyTaxonomyService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.Taxonomy>?> GetAllTaxonomies()
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IsoCode, IsoCode.English }
            };

            var reqData = new RequestData(BigBuyPath.Taxonomies, parameters);

            return await _client.GetBigBuyData<Model.Taxonomy>(reqData);
        }

        public async Task<List<Model.Taxonomy>?> GetFirstLevelTaxonomies()
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IsoCode, IsoCode.English },
                { BigBuyParameters.FirstLevel, null }
            };

            var reqData = new RequestData(BigBuyPath.Taxonomies, parameters);

            return await _client.GetBigBuyData<Model.Taxonomy>(reqData);
        }

        public List<Model.Taxonomy> GetAllRelatedTaxonomies(int parentId, List<Model.Taxonomy> taxonomies)
        { 
            var taxonomiesMap = MakeTaxonomiesMap(taxonomies);
            var relatedTaxonomies = CollectRelatedTaxonomies(parentId, taxonomiesMap);
            return relatedTaxonomies;
        }

        public async Task<List<Model.ProductTaxonomy>?> GetProductTaxonomies(int page, int pageSize, int parentTaxonomy)
        { 

            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };


            var reqData = new RequestData(BigBuyPath.ProductsTaxonomies, parameters);

            return await _client.GetBigBuyData<Model.ProductTaxonomy>(reqData);
        }

        public async Task<List<Model.ProductTaxonomy>?> GetAllProductTaxonomiesWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<Model.ProductTaxonomy>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetProductTaxonomies);
        }

        // Recursive method to collect all descendants
        private List<Model.Taxonomy> CollectRelatedTaxonomies(int parentId, Dictionary<int, List<Model.Taxonomy>> taxonomyMap)
        {
            var relatedTaxonomies = new List<Model.Taxonomy>();

            if (taxonomyMap.ContainsKey(parentId))
            {
                foreach (var child in taxonomyMap[parentId])
                {
                    relatedTaxonomies.Add(child);
                    relatedTaxonomies.AddRange(CollectRelatedTaxonomies(child.Id, taxonomyMap));
                }
            }

            return relatedTaxonomies;
        }

        // Method for pairing each taxonomy with parent
        private Dictionary<int, List<Model.Taxonomy>> MakeTaxonomiesMap(List<Model.Taxonomy>? taxonomies)
        {
            var map = new Dictionary<int, List<Model.Taxonomy>>();

            if (taxonomies == null)
                return map;

            foreach (var t in taxonomies)
            {
                var id = t.ParentTaxonomy;

                if (id == null) continue;

                if (!map.ContainsKey((int)id))
                    map[(int)id] = [];

                map[(int)id].Add(t);
            }

            return map;
        }
    }
}