using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Mapping;
using ServiceLayer.I_R;
using WebApi.Modales;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
        [HttpGet(), Route("GetproductById/{id:int}")]
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
        public List<ProductDTO> GetProductsPageing(int currentPage, int pageSize)     
            => _productService.FindAllPage(_productService.FindAll()
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Set)
                , currentPage, pageSize).MappingProductToProductDTO().ToList();
        
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
        [HttpPost(), Route("createProduct")]
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
        [HttpDelete(), Route("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteById(id);
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
        [HttpPut(), Route("updateProduct/{productModel}")]
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
        [HttpGet, Route("/Product/search/{searchText}/{currentPage:int}/{pageSize:int}")]
        public IQueryable<ProductDTO> SearchProduct(string searchText, int currentPage, int pageSize)
        {
             var items = _productService.FindAllPage(_productService.FindAll().Where(p => p.Name.Contains(searchText))
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Set), currentPage, pageSize).MappingProductToProductDTO();

            HttpContext.Response.Headers.Add("x-product-count", items.Count().ToString()); //husk kebab

            return items;
        }
        [HttpGet, Route("/count")]
        public int CountProduct()
        {
            return _productService.FindAll().Count();
        }
        [HttpGet, Route("/product/count/{text}")]
        public int CountProductSearch(string text)
        {
            return _productService.FindAll().Where(x => x.Name.Contains(text)).Count();
        }
        [HttpGet, Route("/sets")]
        public async Task<List<SetDTO>> GetAllSets()
        {
            return await _productService.GetAllSetsAsync();
        }
     
    }
}
