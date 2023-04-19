using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using ServiceLayer.I_R;
using WebLayer.SessionHelper;

namespace WebLayer.Pages
{
    public class IndexModel : PageModel
    {
        public const string SessionKey = "Cart";
        private readonly ILogger<IndexModel> _logger;
        private readonly IProduct _productService;

        public IndexModel(ILogger<IndexModel> logger, IProduct productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IQueryable<Product> Products { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
            Products = _productService.FindAll().Include(p => p.Image).Include(p => p.Set).OrderByDescending(p => p.Set.SetRealse).Take(3);
        }
        public void OnPostAddToCart()
        {
            //BrandId = amount
            if (HttpContext.Session.Get<List<SessionDataCart>>(SessionKey) == null)
            {
                List<SessionDataCart> nyCartSession = new List<SessionDataCart> { new SessionDataCart { ProductId = Product.ProductId, Amount = Product.Fk_BrandId } };
                HttpContext.Session.Set(SessionKey, nyCartSession);
                HttpContext.Session.Set<int>("CartAmount", Product.Fk_BrandId);
                HttpContext.Session.SetString("CartAmountString", Product.Fk_BrandId.ToString());
            }
            else
            {
                List<SessionDataCart> cartSession = HttpContext.Session.Get<List<SessionDataCart>>(SessionKey);
                int amount = HttpContext.Session.Get<int>("CartAmount");
                if (cartSession.Any(a => a.ProductId == Product.ProductId))
                {
                    SessionDataCart foundProduct = cartSession.Where(a => a.ProductId == Product.ProductId).FirstOrDefault();
                    foundProduct.Amount++;

                }
                else
                {
                    cartSession.Add(
                    new SessionDataCart { ProductId = Product.ProductId, Amount = Product.Fk_BrandId });

                }
                HttpContext.Session.Set(SessionKey, cartSession);
                HttpContext.Session.Set<int>("CartAmount", amount + Product.Fk_BrandId);
                HttpContext.Session.SetString("CartAmountString", (amount + Product.Fk_BrandId).ToString());
            }
            OnGet();
        }
    }
}