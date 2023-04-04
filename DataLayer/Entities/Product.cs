using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataLayer.Entities;

[NotMapped]
public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int Fk_SetId { get; set; }
    public Set? Set { get; set; }

    public int Fk_BrandId { get; set; }
    public Brand? Brand { get; set; }

    public Image? Image { get; set; }

    public int Fk_CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<OrdreProduct>? Ordres { get; set; }
}
