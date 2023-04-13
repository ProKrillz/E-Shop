using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.I_R;

namespace WebLayer.Pages.Users
{
    public class AdminModel : PageModel
    {
        private readonly IProduct _productService;

        public AdminModel(IProduct pService)
        {
            _productService = pService;
        }
        [BindProperty]
        public Product Product { get; set; }
        public IQueryable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.FindAllPage(_productService.FindAll().Include(p => p.Image).Include(p => p.Brand).Include(p => p.Category), 1, 9);
        }
    }
}
