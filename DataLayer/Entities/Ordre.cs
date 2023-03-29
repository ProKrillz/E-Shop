namespace DataLayer.Entities;
public class Ordre
{
    public int OrdreId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public List<Product>? Products { get; set; }

    public Guid Fk_UserId { get; set; }
    public User? User { get; set; }
}
