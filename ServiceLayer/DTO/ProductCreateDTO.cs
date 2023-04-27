using System;
using System.Collections.Generic;
namespace ServiceLayer.DTO;
public class ProductCreateDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? SetId { get; set; }
    public int CatId { get; set; }
    public int BrandId { get; set; }
}
