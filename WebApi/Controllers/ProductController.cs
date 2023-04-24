using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.I_R;
using WebApi.Modales;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;
        public ProductController(IProduct service)
        {
            _productService = service;
        }
        /// <summary>
        /// Find Products by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
            => await _productService.FindByIdAsync(id);
        
        /// <summary>
        /// Find all products
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public IQueryable<Product> GetProducts()
            => _productService.FindAll();
        
        /// <summary>
        /// For pageing
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("{currentPage}/{pageSize}", Name = "GetProductsPageing")]
        public IQueryable<Product> GetProductsPageing(int currentPage, int pageSize)     
            => _productService.FindAllPage(_productService.FindAll(), currentPage, pageSize);
        
        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "name": "test",
        ///         "description": "test",
        ///         "price": 10,
        ///         "setId": "POTE",
        ///         "catId": 1,
        ///         "brandId": 1  
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProduct(ProductModel productModel)
        {
            Product product = new Product()
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Fk_SetId = productModel.SetId,
                Fk_BrandId = productModel.BrandId,
                Fk_CategoryId = productModel.CatId,
            };
            await _productService.AddItemAsync(product);
            await _productService.CommitAsync();
            return CreatedAtRoute("GetProductById", new { id = product.ProductId}, product);
        }
        /// <summary>
        /// Remove product from database
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ///<remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "id" : 100 
        ///         "name": "test",
        ///         "description": "test",
        ///         "price": 10,
        ///         "setId": "POTE",
        ///         "catId": 1,
        ///         "brandId": 1  
        ///     }
        /// </remarks>
        [HttpDelete(Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(ProductModel productModel)
        {
            Product product = new Product()
            {
                ProductId = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Fk_SetId = productModel.SetId,
                Fk_BrandId = productModel.BrandId,
                Fk_CategoryId = productModel.CatId,
            };
            _productService.Delete(product);
            await _productService.CommitAsync();
            return CreatedAtRoute("GetProductById", new { id = product.ProductId }, product);
        }
        /// <summary>
        /// Update Product with Put
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ///<remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///         "id" : 100        
        ///         "name": "test",
        ///         "description": "test",
        ///         "price": 10,
        ///         "setId": "POTE",
        ///         "catId": 1,
        ///         "brandId": 1  
        ///     }
        /// </remarks>
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductPut(ProductModel productModel)
        {
            Product product = new Product()
            {
                ProductId = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Fk_SetId = productModel.SetId,
                Fk_BrandId = productModel.BrandId,
                Fk_CategoryId = productModel.CatId,
            };
            await _productService.UpdateItemAsync(product);
            await _productService.CommitAsync();
            return CreatedAtRoute("GetProductById", new { id = product.ProductId }, product);
        }

    }
}
