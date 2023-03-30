using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;
[NotMapped]
public class Delivery
{
    public int DeliveryId { get; set; }
    public string? DeliveryOption { get; set; }

    public List<Ordre> Ordres { get; set; }
}
