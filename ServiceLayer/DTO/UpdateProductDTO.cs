

namespace ServiceLayer.DTO
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }
        public string? SetId { get; set; }
        public int CatId { get; set; }
        public int BrandId { get; set; }
    }
}
