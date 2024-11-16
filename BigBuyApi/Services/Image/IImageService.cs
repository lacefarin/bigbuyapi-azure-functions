using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Image
{
    public interface IImageService
    {
        Task<List<Model.ProductImage>?> GetImages(int page, int pageSize, int parentTaxonomy);
        Task<List<Model.ProductImage>?> GetAllImagesWithPagination(int parentTaxonomy);
        Task<List<Model.Image>?> GetAllImagesWithPaginationForSql(int parentTaxonomy);
    }
}
