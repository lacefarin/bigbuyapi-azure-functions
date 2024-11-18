using BigBuyApi.Model;
using BigBuyApi.Model.Constant;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Manufacturer
{
    public class BigBuyManufacturerService: IManufacturerService
    {
        private readonly BigBuyClient _client;

        public BigBuyManufacturerService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.DTO.Manufacturer>?> GetManufacturers(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}"},
                { BigBuyParameters.PageSize, $"{pageSize}"},
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}"}
            };

            var reqData = new RequestData(BigBuyPath.Manufacturers, parameters);

            return await _client.GetBigBuyData<Model.DTO.Manufacturer>(reqData);
        }

        public async Task<List<Model.DTO.Manufacturer>> GetAllManufacturersWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<Model.DTO.Manufacturer>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetManufacturers);
        }
    }
}
