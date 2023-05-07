namespace KrillzCardz.Services.DTO
{
    public class CreateProductModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imagePath { get; set; }
        public string setId { get; set; }
        public int catId { get; set; }
        public int brandId { get; set; }
    }
}
