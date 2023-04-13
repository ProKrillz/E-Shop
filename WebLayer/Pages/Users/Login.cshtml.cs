using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.I_R;

namespace WebLayer.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly IUser _userService;
        public LoginModel(IUser userService)
            => _userService = userService;

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string? PasswordCompared { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPostLogin()
        {
            User FoundUser = _userService.Login(User.Email, User.Password);
            if (FoundUser != null)
            {
                HttpContext.Session.SetString("userId", FoundUser.UserId.ToString());
                if (FoundUser.Admin)
                {
                    HttpContext.Session.SetString("userAdmin", FoundUser.Admin.ToString());
                    return RedirectToPage("/Users/Admin");
                }
                return RedirectToPage("/Users/UserSite");
            }
            return Page();
        }
        public IActionResult OnPostCreate()
        {
            if (User.Password == PasswordCompared)
            {
                _userService.AddItemAsync(User);
                _userService.CommitAsync();
            }
            return Page();
        }
    }
}
