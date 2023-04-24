using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.I_R;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser service)
        {
            _userService = service;
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUserByGuid")]
        public async Task<ActionResult<User>> GetUserByGuid(string id)    
            => await _userService.GetUserByGuidAsync(Guid.Parse(id));

        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("{email}/{password}", Name = "Login")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            return _userService.Login(email, password);
        }
        
    }
}
