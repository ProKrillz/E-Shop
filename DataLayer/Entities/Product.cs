namespace DataLayer.Entities;
public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int Fk_BrandId { get; set; }
    public Brand? Brand { get; set; }

    public Image? Image { get; set; }

    public List<Category>? Categorys { get; set; }

    public List<Ordre>? Ordres { get; set; }
}
