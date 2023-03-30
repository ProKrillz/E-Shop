using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using ServiceLayer.Mapping;
using System.Collections.Generic;

namespace ServiceLayer.I_R;

public class RepositoryProduct : IProduct
{
    readonly EfCoreContext _coreContext;
    public RepositoryProduct(EfCoreContext context)
        => _coreContext = context;

    public async Task<List<ProductDTO>> GetAllProductAsync() 
        => await _coreContext.Product.MappingProductToProductDTO().ToListAsync();
    
    public async Task<List<ProductDTO>> SearchProductByProductTextAsync(string text)
    {
        return await _coreContext.Product.Where(p => EF.Functions.Like(p.Name, text)).MappingProductToProductDTO().ToListAsync();
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        Product FoundProduct = await _coreContext.Product.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        if (FoundProduct != null)
        {
            return FoundProduct.MappingProductToProductDTO();
        }
        return null; // error throw    
    }
    public async Task CreateProductAsync(Product product)
    {
        _coreContext.Product.Add(product);
        await _coreContext.SaveChangesAsync();
    }
    public async Task UpdateProductAsync(Product product)
    {
        _coreContext.Product.Update(product);
        await _coreContext.SaveChangesAsync();
    }
    public async Task DeleteProductByIdAsync(int id)
    {
        await _coreContext.Product.Where(p => p.ProductId == id).ExecuteDeleteAsync();
    }
}
