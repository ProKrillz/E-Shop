using DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebLayer.Pages.Products
{
    public class CartModel : PageModel
    {
    
        public List<Product> ShoppingCart { get; set; }
        public void OnGet()
        {
            //ShoppingCart = HttpContext.Session.Get<List<Product>>("ShoppingCart") ?? new List<Product>();
        }
    }
}
