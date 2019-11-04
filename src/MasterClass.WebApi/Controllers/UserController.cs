﻿using MasterClass.WebApi.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstractions.Users;
using Service.Models.Users;
using System.Threading.Tasks;

namespace MasterClass.WebApi.Controllers
{
    [Route("api/user"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost, Route("authenticate"), AllowAnonymous]
        public IActionResult Authenticate([FromBody]AuthenticateParameters authParams)
        {
            var authUser = _userService.Authenticate(authParams);
            return authUser == null ? (IActionResult)Unauthorized() : Ok(authUser);
        }

        [HttpGet, Authorize(Roles = Policies.REQUIRED_ADMIN_ROLE)]
        public IActionResult GetContext() => Ok(new { Id = User.Identity.Name });

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