using DataLayer.Entities;

namespace ServiceLayer.I_R;

public interface IProduct : IBase<Product>
{
    Task<List<Category>> GetAllCategories();
    Task<List<Brand>> GetAllBrandsAsync();
    Task<List<Set>> GetAllSetsAsync();
    /// <summary>
    /// Get product by productId as DTO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product> GetProductByIdAsync(int id);

    Task CreateCategoryAsync(string name);
}
