using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Manufacturer
{
    public interface IManufacturerService
    {
        Task<List<Model.DTO.Manufacturer>?> GetManufacturers(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.DTO.Manufacturer>> GetAllManufacturersWithPagination(int parentTaxonomy);
    }
}
