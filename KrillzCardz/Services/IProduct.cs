using KrillzCardz.Services.DTO;

namespace KrillzCardz.Services;

public interface IProduct
{
    Task<List<ProductModel>> GetProductWithPageing(int currentPage, int pageSize);
    Task<int> CountProducts();
    Task<ProductPase> SearchProducts(string text, int currentPage, int pageSize);
    Task CreateProduct(CreateProductModel product);
    Task UpdateProduct(ProductModel product);
    Task DeleteProduct(int id);
    Task<List<SetModel>> GetAllSets();
    Task<ProductModel> GetProductById(int id);
}
