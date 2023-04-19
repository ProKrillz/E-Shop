using DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLayer.SessionHelper;
using ServiceLayer.I_R;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLayer.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly IProduct _productService;
        private readonly IOrdre _ordreService;
        private readonly IUser _userService;
        public CartModel(IProduct service, IOrdre ordreService, IUser userService)
        {
            _productService = service;
            _ordreService = ordreService;
            _userService = userService;
        }
        public List<CartProducts> CartProducts { get; set; } = new();
        public decimal TotalPrice { get; set; }
        [BindProperty]
        public Product Product { get; set; }
   
        public SelectList? Payments { get; set; } =new SelectList(new List<string>(), "PaymentId", "PaymentOption");
  
        public SelectList? Deliverys { get; set; } = new SelectList(new List<string>(), "PaymentId", "PaymentOption");
        [BindProperty]
        public Ordre Ordre { get; set; }
        public User User { get; set; } = new();

        public async Task OnGet()
        {
            if (HttpContext.Session.Get<List<SessionDataCart>>("Cart") != null)
            {
                List<SessionDataCart> shoppingCart = new();
                shoppingCart = HttpContext.Session.Get<List<SessionDataCart>>("Cart");
                foreach (SessionDataCart data in shoppingCart) 
                {
                    CartProducts.Add( new CartProducts { 
                        Product = await _productService.FindByIdAsync(data.ProductId),
                        Amount = data.Amount
                    });
                }
                TotalPrice = CartProducts.Sum(p => p.Product.Price * p.Amount);
            }
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
            {
                Payments = new SelectList(_ordreService.GetAllPayments(), "PaymentId", "PaymentOption");
                Deliverys = new SelectList(_ordreService.GetDeliveries(), "DeliveryId", "DeliveryOption");
                User = await _userService.GetUserByGuidAsync(Guid.Parse(HttpContext.Session.GetString("userId")));
            }
        }
        public IActionResult OnPostDelete()
        {
            List<SessionDataCart> sessionDatas = HttpContext.Session.Get<List<SessionDataCart>>("Cart");
            int index = Exists(sessionDatas, Product.ProductId);
            sessionDatas.RemoveAt(index);
            HttpContext.Session.Set<List<SessionDataCart>>("Cart", sessionDatas);
            return RedirectToPage("/Products/Cart");
        }
        private int Exists(List<SessionDataCart> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public async Task<IActionResult> OnPostCreate()
        {
            List<OrdreProduct> op = new();
            List<SessionDataCart> shoppingCart = new();
            shoppingCart = HttpContext.Session.Get<List<SessionDataCart>>("Cart");
            foreach (SessionDataCart data in shoppingCart)
            {
                op.Add(new OrdreProduct
                {
                    Fk_ProductId = data.ProductId,
                    Amount = data.Amount
                });
            }
            Ordre.Products = op;
            Ordre.Fk_UserId = Guid.Parse(HttpContext.Session.GetString("userId"));
            await _ordreService.AddItemAsync(Ordre);
            await _ordreService.CommitAsync();
            return RedirectToPage("/Index");
        }
    }
}
