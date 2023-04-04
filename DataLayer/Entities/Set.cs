
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [NotMapped]
    public class Set
    {
        public string? SetId { get; set; }
        public string? SetName { get; set;}
        public DateTime SetRealse { get; set; }

        public List<Product>? Product { get; set; }
    }
}
