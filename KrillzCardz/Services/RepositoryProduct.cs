using KrillzCardz.Services.DTO;
using System.Net.Http.Json;

namespace KrillzCardz.Services;

public class RepositoryProduct : IProduct
{
    private readonly HttpClient _HttpClient;
    public RepositoryProduct(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }
    public async Task<List<ProductModel>> GetProductWithPageing(int currentPage, int pageSize)
    { 
        return await _HttpClient.GetFromJsonAsync<List<ProductModel>>($"api/Product/{currentPage}/{pageSize}") ?? new();
    }
}
