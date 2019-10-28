using Microsoft.AspNetCore.Mvc;
using Service.Abstractions.Users;
using Service.Models.Users;

namespace MasterClass.WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost, Route("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateParameters authParams)
        {
            var authUser = _userService.Authenticate(authParams);
            return authUser == null ? (IActionResult)Unauthorized() : Ok(authUser);
        }
    }
}