using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.AttributeGroup
{
    public class BigBuyAttributeGroupService: IAttributeGroupService
    {

        private readonly BigBuyClient _client;
        public BigBuyAttributeGroupService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.AttributeGroup>?> GetAttributeGroups(int page, int pageSize, string isoCode)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.IsoCode, isoCode}
            };

            var reqDat = new RequestData(BigBuyPath.AttributeGroups, parameters);

            return await _client.GetBigBuyData<Model.AttributeGroup>(reqDat);
        }

        public async Task<List<Model.AttributeGroup>?> GetAllAttributeGroupsWithPagination(string isoCode)
        { 
            var paginationService = new PaginationService<Model.AttributeGroup>();
            return await paginationService.FetchUntilEmptyResult(isoCode, GetAttributeGroups);
        }
    }
}
