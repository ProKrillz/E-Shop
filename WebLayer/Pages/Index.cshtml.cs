using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using ServiceLayer.I_R;

namespace WebLayer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProduct _productService;

        public IndexModel(ILogger<IndexModel> logger, IProduct productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IQueryable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productService.FindAll().Include(p => p.Image).Take(5);
        }
    }
}