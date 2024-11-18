using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBuyApi.Model.DTO;

namespace BigBuyApi.Services.Image
{
    public interface IImageService
    {
        Task<List<ProductImage>?> GetImages(int page, int pageSize, int parentTaxonomy);
        Task<List<ProductImage>?> GetAllImagesWithPagination(int parentTaxonomy);
        Task<List<Model.Domain.Image>?> GetAllImagesWithPaginationForSql(int parentTaxonomy);
    }
}
