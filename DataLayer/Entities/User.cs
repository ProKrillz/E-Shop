namespace DataLayer.Entities;
public class User
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Address { get; set; }
    public bool Disable { get; set; }

    public int Fk_ZipCodeId { get; set; }
    public ZipCode? ZipCode { get; set; }

    public List<Ordre>? Ordres { get; set; }
}
