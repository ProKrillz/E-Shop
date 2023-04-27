using DataLayer.Entities;
using ServiceLayer.DTO;

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
            Category = p.Category.Name,
            Set = p.Set.SetName,
            Release = p.Set.SetRealse
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
            Category = p.Category.Name,
            Set = p.Set.SetName,
            Release = p.Set.SetRealse
        };
    }
    public static Product MappingProductDTOToProduct(this ProductCreateDTO dto)
    {
        return new Product()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Fk_SetId = dto.SetId,
            Fk_BrandId = dto.BrandId,
            Fk_CategoryId = dto.CatId,
        };
    }
    public static UserDTO MappingUserToUserDTO(this User user)
    {
        return new UserDTO()
        {
            UserId = user.UserId,
            Firstname = user.FirstName,
            Lastname = user.Lastname,
            Email = user.Email,
            Password = user.Password,
            IsAdmin = user.Admin,
            Address = user.Address,
            City = user.ZipCode.City,
            ZipCode = user.Fk_ZipCodeId
        };
    }
    public static User MappingUserDTOToUser(this UserDTO user)
    {
        return new User() 
        { 
            UserId=user.UserId,
            FirstName = user.Firstname, 
            Lastname = user.Lastname,
            Email = user.Email,
            Password = user.Password,
            Address = user.Address,
            Fk_ZipCodeId = user.ZipCode
        };
    }
}
