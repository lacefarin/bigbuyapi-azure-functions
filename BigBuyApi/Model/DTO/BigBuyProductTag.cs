using BigBuyApi.Model.Domain;

namespace BigBuyApi.Model.DTO
{
    public class BigBuyProductTag
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public Tag Tag { get; set; }
    }
}
