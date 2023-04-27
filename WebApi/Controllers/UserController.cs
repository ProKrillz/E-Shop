using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.I_R;
using ServiceLayer.Mapping;
using ServiceLayer.DTO;
using WebApi.Modales;

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
        [HttpGet("{id:guid}", Name = "GetUserByGuid")]
        public async Task<ActionResult<UserDTO>> GetUserByGuid(Guid id)
        {
            User foundUser = await _userService.GetUserByGuidAsync(id);
            if (foundUser != null)
                return foundUser.MappingUserToUserDTO();

            return NotFound();
        }
        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("{email}/{password}", Name = "Login")]
        public ActionResult<User> Login(string email, string password)
            => _userService.Login(email, password);
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User
        ///     {
        ///         "firstname": "test",
        ///         "lastname": "test",
        ///         "email": "email@email.dk",
        ///         "password": "linkin",
        ///         "address": "test",
        ///         "zipcode": 6200  
        ///     }
        /// </remarks>
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> CreateUser(UserDTO userModel)
        {
            await _userService.AddItemAsync(userModel.MappingUserDTOToUser());
            await _userService.CommitAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            return Ok();
        }
    }
}
