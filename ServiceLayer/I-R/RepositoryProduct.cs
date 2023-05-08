﻿using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using ServiceLayer.Mapping;
using System.Security.Cryptography.X509Certificates;

namespace ServiceLayer.I_R;

public class RepositoryProduct : RepositroyBase<Product>, IProduct
{
    readonly EfCoreContext _coreContext;
    public RepositoryProduct(EfCoreContext context) : base(context)
        => _coreContext = context;

    public async Task<List<Category>> GetAllCategories()  
        => await _coreContext.Category.ToListAsync();
    
    public async Task<List<Brand>> GetAllBrandsAsync()
        => await _coreContext.Brand.ToListAsync();

    public async Task<List<SetDTO>> GetAllSetsAsync()
        => await _coreContext.Set.MappingSetToSetDTO().ToListAsync();

    public async Task<Product> GetProductByIdAsync(int id)
    {
        Product FoundProduct = await _coreContext.Product.Where(p => p.ProductId == id).Include(p => p.Image).FirstOrDefaultAsync();
        if (FoundProduct != null)
        {
            return FoundProduct;
        }
        return null; // error throw    
    }
    public async Task CreateCategoryAsync(string name)
        => await _coreContext.Category.AddAsync(new Category() { Name = name});

    public async Task DeleteById(int id)
    {
        Product product = await GetProductByIdAsync(id);
        if (product != null)
        {
            _coreContext.Product.Remove(product);
        }
    }
    public async Task<UpdateProductDTO> GetUpdateProductById(int id)
    {
        Product foundProduct = await _coreContext.Product.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        return foundProduct.MappingProductToUpdateProductDTO();
    }
}
