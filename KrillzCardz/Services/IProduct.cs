using KrillzCardz.Services.DTO;

namespace KrillzCardz.Services;

public interface IProduct
{
    Task<List<ProductModel>> GetProductWithPageing(int currentPage, int pageSize);
    Task<int> CountProducts();
    Task<ProductPase> SearchProducts(string text, int currentPage, int pageSize);
    Task CreateProduct(CreateProductModel product);
    Task UpdateProduct(UpdateProductModel product);
    Task DeleteProduct(int id);
    Task<List<SetModel>> GetAllSets();
    Task<ProductModel> GetProductById(int id);
    Task<UpdateProductModel> GetUpdateProductById(int id);
}
