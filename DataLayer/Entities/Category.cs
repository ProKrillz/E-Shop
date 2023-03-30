using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[NotMapped]
public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    public List<Product>? Products { get; set; }
}
