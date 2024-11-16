using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Attribute
{
    public interface IAttributeService
    {
        Task<List<Model.Attribute>?> GetAttributes(int page, int pageSize, string isoCode);
        Task<List<Model.Attribute>?> GetAllProductsWithPagination(string isoCode);
    }
}
