using KrillzCardz.Services.DTO;
using System.Collections.Immutable;
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
    public async Task<int> CountProducts()
    {
        string item = await _HttpClient.GetStringAsync("count");
        return Convert.ToInt32(item);
    }
    public async Task<ProductPase> SearchProducts(string text, int currentPage, int pageSize)
    {
        var response = await _HttpClient.GetAsync($"Product/search/{text}/{currentPage}/{pageSize}");
        ProductPase pase = new ProductPase();
        pase.productcount = Convert.ToInt32( await _HttpClient.GetStringAsync($"product/count/{text}"));
        pase.ProductModels = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
        return pase;
    }
    public async Task CreateProduct(CreateProductModel product)
    {
        // test efter modal
        await _HttpClient.PostAsJsonAsync<CreateProductModel>("api/product/createProduct", product);
    }
    public async Task UpdateProduct(ProductModel product)
    {
        // test efter modal om /{product} skal med
        await _HttpClient.PutAsJsonAsync($"updateProduct/{product}", product);
    }
    public async Task DeleteProduct(int id)
    {
        //test om virker efter modal
        await _HttpClient.DeleteAsync($"api/Product/delete/{id}");
    }
    public async Task<List<SetModel>> GetAllSets()
    {
        return await _HttpClient.GetFromJsonAsync<List<SetModel>>("sets");
    }
    public async Task<ProductModel> GetProductById(int id)
    {
        return await _HttpClient.GetFromJsonAsync<ProductModel>($"api/product/GetproductById/{id}");
    }
}
