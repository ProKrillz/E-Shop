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
            return Page();
        }
        public IActionResult OnPostCreate()
        {
            User newuser = User;
            return Page();
        }
    }
}
