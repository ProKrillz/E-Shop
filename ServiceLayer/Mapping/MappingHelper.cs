using DataLayer.Entities;
using ServiceLayer.DTO;
using System.Security.Cryptography.X509Certificates;

namespace ServiceLayer.Mapping;

public static class MappingHelper
{
    public static IQueryable<ProductDTO> MappingProductToProductDTO(this IQueryable<Product> quere)
    {
        return quere.Select(p => new ProductDTO()
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImagePath = p.Image.Path,
            Brand = p.Brand.Name,
            Categorys = p.Categorys      
        });     
    }
    public static ProductDTO MappingProductToProductDTO(this Product p)
    {
        return new ProductDTO()
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImagePath = p.Image.Path,
            Brand = p.Brand.Name,
            Categorys = p.Categorys
        };
    }
}
