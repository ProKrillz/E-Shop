using KrillzCardz.Services.DTO;

namespace KrillzCardz.Services
{
    public interface IProduct
    {
        Task<List<ProductModel>> GetProductWithPageing(int currentPage, int pageSize);
    }
}
