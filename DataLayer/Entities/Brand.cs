namespace DataLayer.Entities;
public class Brand
{
    public int BrandId { get; set; }
    public string? Name { get; set; }

    public List<Product>? Products { get; set; }
}
