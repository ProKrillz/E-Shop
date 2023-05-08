namespace KrillzCardz.Services.DTO
{
    public class UpdateProductModel
    {
        public int productId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public int? imageId { get; set; }
        public string? setId { get; set; }
        public int catId { get; set; }
        public int brandId { get; set; }
    }
}
