using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Attribute
{
    public class BigBuyAttributeService: IAttributeService
    {
        private readonly BigBuyClient _client;

        public BigBuyAttributeService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.Attribute>?> GetAttributes(int page, int pageSize, string isoCode)
        { 
            var paramaters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.IsoCode,  isoCode }
            };

            var reqData = new RequestData(BigBuyPath.Attributes, paramaters);

            return await _client.GetBigBuyData<Model.Attribute>(reqData);
        }

        public async Task<List<Model.Attribute>?> GetAllProductsWithPagination(string isoCode)
        { 
            var paginationService = new PaginationService<Model.Attribute>();
            return await paginationService.FetchUntilEmptyResult(isoCode, GetAttributes);
        }
    }
}
