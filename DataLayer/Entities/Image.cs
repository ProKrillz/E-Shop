namespace DataLayer.Entities;
public class Image
{
    public int ImageId { get; set; }
    public string? Path { get; set; }

    public int Fk_ProductId { get; set; }
    public Product? Product { get; set; }
}
