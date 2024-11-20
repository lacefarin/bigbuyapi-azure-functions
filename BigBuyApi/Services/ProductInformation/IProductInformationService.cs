using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.ProductInformation
{
    public interface IProductInformationService
    {
        Task<List<Model.Domain.ProductInformation>?> GetProductInformation(string isoCode, int page, int pageSize, int parentTaxonomy);
        Task<List<Model.Domain.ProductInformation>?> GetAllProductInformationWithPagination(string isoCode, int parentTaxonomy);

    }
}
