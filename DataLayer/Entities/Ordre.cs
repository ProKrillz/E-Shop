using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[NotMapped]
public class Ordre
{
    public int OrdreId { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; }

    public ICollection<OrdreProduct>? Products { get; set; }

    public int Fk_PayementId { get; set; }
    public Payment? Payment { get; set; }

    public int Fk_DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }

    public Guid Fk_UserId { get; set; }
    public User? User { get; set; }

    
}
