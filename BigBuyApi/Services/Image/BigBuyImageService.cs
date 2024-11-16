using BigBuyApi.Model;
using BigBuyApi.Networking;
using BigBuyApi.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Image
{
    public class BigBuyImageService : IImageService
    {
        private readonly BigBuyClient _client;
        public BigBuyImageService(HttpClient client)
        {
            _client = new BigBuyClient(client);
        }

        public async Task<List<Model.ProductImage>?> GetImages(int page, int pageSize, int parentTaxonomy)
        {
            var parameters = new Dictionary<string, string?>()
            {
                { BigBuyParameters.Page, $"{page}" },
                { BigBuyParameters.PageSize, $"{pageSize}" },
                { BigBuyParameters.ParentTaxonomy, $"{parentTaxonomy}" }
            };

            var reqData = new RequestData(BigBuyPath.ProductImages, parameters);

            return await _client.GetBigBuyData<Model.ProductImage>(reqData);
        }

        public async Task<List<Model.ProductImage>?> GetAllImagesWithPagination(int parentTaxonomy)
        {
            var paginationService = new PaginationService<Model.ProductImage>();
            return await paginationService.FetchUntilEmptyResult(parentTaxonomy, GetImages);
        }

        public async Task<List<Model.Image>?> GetAllImagesWithPaginationForSql(int parentTaxonomy)
        {
            var productImages = await GetAllImagesWithPagination(parentTaxonomy);

            if (productImages == null) { return null; }

            var sqlImages = new List<Model.Image>();

            foreach (ProductImage pi in productImages)
            {
                foreach (BigBuyImage bbi in pi.Images)
                {
                    var image = new Model.Image()
                    {
                        Id = bbi.Id,
                        IsCover = bbi.IsCover,
                        Name = bbi.Name,
                        Url = bbi.Url,
                        Logo = bbi.Logo,
                        WhiteBackground = bbi.WhiteBackground,
                        Position = bbi.Position,
                        EnergyEfficiency = bbi.EnergyEfficiency,
                        Icon = bbi.Icon,
                        MarketingPhoto = bbi.MarketingPhoto,
                        PackagingPhoto = bbi.PackagingPhoto,
                        Brand = bbi.Brand,
                        GpsrLabel = bbi.GpsrLabel,
                        GpsrWarning = bbi.GpsrWarning,
                        ProductId = pi.Id,
                    };

                    sqlImages.Add(image);
                }
            }

            return sqlImages;
        }
    }
}
