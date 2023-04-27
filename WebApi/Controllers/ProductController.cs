using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Mapping;
using ServiceLayer.I_R;
using WebApi.Modales;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("{id:int}", Name = "GetProductById")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            Product? product = _productService.FindAll(p => p.ProductId == id)
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Set)
                .FirstOrDefault();
            return product.MappingProductToProductDTO();
        }
        
        /// <summary>
        /// Find all products / maby remove?
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
        [HttpGet("{currentPage:int}/{pageSize:int}", Name = "GetProductsPageing")]
        public IQueryable<ProductDTO> GetProductsPageing(int currentPage, int pageSize)     
            => _productService.FindAllPage(_productService.FindAll().Include(p => p.Image)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Set)
                , currentPage, pageSize).MappingProductToProductDTO();
        
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
        public async Task<ActionResult> CreateProduct(ProductCreateDTO productModel)
        {
            await _productService.AddItemAsync(productModel.MappingProductDTOToProduct());
            await _productService.CommitAsync();
            return Ok();
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
        public async Task<IActionResult> DeleteProduct(ProductCreateDTO productModel)
        {
            _productService.Delete(productModel.MappingProductDTOToProduct());
            await _productService.CommitAsync();
            return Ok();
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
        public async Task<IActionResult> UpdateProductPut(ProductCreateDTO productModel)
        {
            await _productService.UpdateItemAsync(productModel.MappingProductDTOToProduct());
            await _productService.CommitAsync();
            return Ok();
        }
        /// <summary>
        /// Search all product with contains
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("searchText")]
        public IQueryable<ProductDTO> SearchProduct(string searchText)
        {
            return _productService.FindAll().Where(p => p.Name.Contains(searchText))
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Set)
                .MappingProductToProductDTO();
        }
    }
}
