namespace DataLayer.Entities;
public class ZipCode
{
    public int ZipCodeId { get; set; }
    public string? City { get; set; }

    public List<User>? Users { get; set; }
}