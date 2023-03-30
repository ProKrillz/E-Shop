
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;
[NotMapped]
public class Payment
{
    public int PaymentId { get; set; }
    public string? PaymentOption { get; set; }

    public List<Ordre>? Ordes { get; set; }
}
