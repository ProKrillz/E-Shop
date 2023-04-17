using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataLayer.Entities;

[NotMapped]
public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "Skal være et tal")]
    [Range(0, 5000.00)]
    [Column(TypeName = "decimal(18,2)")]
    [RegularExpression(@"^[0-9]+(.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
    public decimal Price { get; set; }

    public string Fk_SetId { get; set; }
    public Set? Set { get; set; }

    public int Fk_BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int Fk_ImageId { get; set; }
    public Image? Image { get; set; }

    public int Fk_CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<OrdreProduct>? Ordres { get; set; }
}
