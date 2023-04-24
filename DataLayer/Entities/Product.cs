using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataLayer.Entities;

[NotMapped]
public class Product
{
    public int ProductId { get; set; }
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    [Required, MaxLength(50)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Skal være et tal")]
    [Range(0, 100000.00)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Fk_SetId { get; set; }
    public Set? Set { get; set; }

    public int Fk_BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int? Fk_ImageId { get; set; }
    public Image? Image { get; set; }

    public int Fk_CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<OrdreProduct>? Ordres { get; set; }
}
