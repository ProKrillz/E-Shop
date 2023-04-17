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
    /// <summary>
    /// Create Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task CreateProductAsync(Product product);
    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task UpdateProductAsync(Product product);
    /// <summary>
    /// Delete product from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteProductByIdAsync(int id);
    Task CreateCategoryAsync(string name);
}
