namespace KrillzCardz.Services.DTO;

public class OrdreModel
{
    public int ordoreId { get; set; }
    public Guid userId { get; set; }
    public DateTime created { get; set; }
    public string payment { get; set; }
    public string delevery { get; set; }
    public List<ProductModel> products { get; set; }
}
