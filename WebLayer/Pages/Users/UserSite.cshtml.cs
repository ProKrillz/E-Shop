using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.I_R;

namespace WebLayer.Pages.Users
{
    public class UserSiteModel : PageModel
    {
        private readonly IUser _userService;
        public UserSiteModel(IUser userService)
        {
            _userService = userService;
        }
        public User User { get; set; }
        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty( HttpContext.Session.GetString("userId")))
            {
                User = await _userService.GetUserByGuidAsync(Guid.Parse(HttpContext.Session.GetString("userId")));
            }
        }
    }
}
