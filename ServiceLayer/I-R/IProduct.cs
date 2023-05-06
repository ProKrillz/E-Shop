using DataLayer.Entities;
using ServiceLayer.DTO;

namespace ServiceLayer.I_R;

public interface IProduct : IBase<Product>
{
    Task<List<Category>> GetAllCategories();
    Task<List<Brand>> GetAllBrandsAsync();
    Task<List<SetDTO>> GetAllSetsAsync();
    /// <summary>
    /// Get product by productId as DTO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product> GetProductByIdAsync(int id);

    Task CreateCategoryAsync(string name);
}
