using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTO;
using ServiceLayer.I_R;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebLayer.Pages.Products
{
    public class AllProductsModel : PageModel
    {
        private readonly IProduct _productService;
        public AllProductsModel(IProduct service)
        {
            _productService = service;
        }
        public IQueryable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.FindAllPage(_productService.FindAll().Include(p => p.Image), 1, 9);
        }
    }
}
