using System.Threading.Tasks;
using MasterClass.Service.Abstractions.Users;
using MasterClass.Service.Models.Users;
using MasterClass.WebApi.Authorization.Policy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterClass.WebApi.Controllers
{
    [Route("api/user"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        
        [HttpGet, Authorize(Policy = Policies.REQUIRED_SUPERADMIN_ROLE)]
        public IActionResult GetContext() => Ok(new { Id = User.Identity.Name });

        [HttpPost, Route("authenticate"), AllowAnonymous]
        public IActionResult Authenticate([FromBody]AuthenticateParameters authParams)
        {
            var authUser = _userService.Authenticate(authParams);
            return authUser == null ? (IActionResult)Unauthorized() : Ok(authUser);
        }

        [HttpPost("signin"), AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody]AuthenticateParameters authParams)
        {
            var principal = _userService.SignIn(authParams, CookieAuthenticationDefaults.AuthenticationScheme);
            if (principal != null)
            {
                await HttpContext.SignInAsync(principal, new AuthenticationProperties { IsPersistent = true });
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}