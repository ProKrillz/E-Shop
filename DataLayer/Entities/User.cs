using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[NotMapped]
public class User
{
    public Guid UserId { get; set; }
    [Required, MaxLength(25)]
    public string? FirstName { get; set; }
    [Required, MaxLength(25)]
    public string? Lastname { get; set; }
    [Required, MaxLength(50)]
    public string? Email { get; set; }
    [Required, MaxLength(50)]
    public string? Password { get; set; }
    [Required, MaxLength(100)]
    public string? Address { get; set; }
    public bool Disable { get; set; }
    public bool Admin { get; set; }

    public int Fk_ZipCodeId { get; set; }
    public ZipCode? ZipCode { get; set; }

    public List<Ordre>? Ordres { get; set; }
}
