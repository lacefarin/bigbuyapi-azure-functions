using BigBuyApi.Model;
using BigBuyApi.Model.Constant;
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

        public async Task<List<Model.DTO.Attribute>?> GetAttributes(int page, int pageSize, string isoCode)
        { 
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.IsoCode,  isoCode }
            };

            var reqData = new RequestData(BigBuyPath.Attributes, parameters);

            return await _client.GetBigBuyData<Model.DTO.Attribute>(reqData);
        }

        public async Task<List<Model.DTO.Attribute>?> GetAllProductsWithPagination(string isoCode)
        { 
            var paginationService = new PaginationService<Model.DTO.Attribute>();
            return await paginationService.FetchUntilEmptyResult(isoCode, GetAttributes);
        }
    }
}
