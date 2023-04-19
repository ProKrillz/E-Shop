using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.I_R;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using WebLayer.SessionHelper;

namespace WebLayer.Pages.Products;

public class AllProductsModel : PageModel
{
    public const string SessionKey = "Cart";
    private readonly IProduct _productService;
    public AllProductsModel(IProduct service)
    {
        _productService = service;
    }
    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 9;
    public IQueryable<Product> Products { get; set; }
    [BindProperty]
    public Product Product { get; set; }
    public void OnGet()
    {
        Products = _productService.FindAllPage(_productService.FindAll().Include(p => p.Image), CurrentPage, PageSize);
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
