using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using ServiceLayer.Mapping;
using System.Collections.Generic;

namespace ServiceLayer.I_R;

public class RepositoryProduct : RepositroyBase<Product>, IProduct
{
    readonly EfCoreContext _coreContext;
    public RepositoryProduct(EfCoreContext context) : base(context)
        => _coreContext = context;

    public async Task<List<Category>> GetAllCategories()
    {
        return await _coreContext.Category.ToListAsync();
    }
    public async Task<List<Brand>> GetAllBrandsAsync()
    {
        return await _coreContext.Brand.ToListAsync();
    }
    public async Task<List<Set>> GetAllSetsAsync()
    {
        return await _coreContext.Set.ToListAsync();
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        Product FoundProduct = await _coreContext.Product.Where(p => p.ProductId == id).Include(p => p.Image).FirstOrDefaultAsync();
        if (FoundProduct != null)
        {
            return FoundProduct;
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
        => await _coreContext.Product.Where(p => p.ProductId == id).ExecuteDeleteAsync();
    
    public async Task CreateCategoryAsync(string name)
        => await _coreContext.Category.AddAsync(new Category() { Name = name});
}
