using DataLayer.Entities;
using ServiceLayer.DTO;

namespace ServiceLayer.I_R;

public interface IProduct
{
    /// <summary>
    /// Get all products as DTO
    /// </summary>
    /// <returns></returns>
    Task<List<ProductDTO>> GetAllProductAsync();
    /// <summary>
    /// Get Products with contains text
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    Task<List<ProductDTO>> SearchProductByProductTextAsync(string text);
    /// <summary>
    /// Get product by productId as DTO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ProductDTO> GetProductByIdAsync(int id);
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
}
