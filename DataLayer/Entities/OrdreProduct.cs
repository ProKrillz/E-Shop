using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [NotMapped]
    public class OrdreProduct
    {
        public int Fk_OrdreId { get; set; }
        public Ordre? Ordre { get; set; }
        public int Fk_ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
    }
}
