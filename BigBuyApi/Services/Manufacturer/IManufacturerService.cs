using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Manufacturer
{
    public interface IManufacturerService
    {
        Task<List<Model.Manufacturer>?> GetManufacturers(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.Manufacturer>> GetAllManufacturersWithPagination(int parentTaxonomy);
    }
}
