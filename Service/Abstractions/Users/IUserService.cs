using Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Service.Abstractions.Users
{
    public interface IUserService
    {
        AuthenticatedUser Authenticate(AuthenticateParameters authParams);
        ClaimsPrincipal SignIn(AuthenticateParameters authParams, string scheme);

    }
}
