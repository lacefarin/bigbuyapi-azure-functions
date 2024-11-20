using BigBuyApi.Model.Constant;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.ProductInformation
{
    public class BigBuyProductInformationService: IProductInformationService
    {
        private BigBuyClient _client;
        public BigBuyProductInformationService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.Domain.ProductInformation>?> GetProductInformation(string isoCode, int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.IsoCode, isoCode },
                { BigBuyParameters.Page, $"{page}"},
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductInformation, parameters);

            return await _client.GetBigBuyData<Model.Domain.ProductInformation>(reqData);
        }

        public async Task<List<Model.Domain.ProductInformation>?> GetAllProductInformationWithPagination(string isoCode, int parentTaxonomy)
        { 
            var service = new PaginationService<Model.Domain.ProductInformation>();
            return await service.FetchUntilEmptyResult(isoCode, parentTaxonomy, GetProductInformation);

        }
    }
}
