namespace KrillzCardz.Services.DTO
{
    public class ProductModel
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string brand { get; set; }
        public string imagePath { get; set; }
        public string category { get; set; }
        public string set { get; set; }
        public DateTime release { get; set; }
    }
}
