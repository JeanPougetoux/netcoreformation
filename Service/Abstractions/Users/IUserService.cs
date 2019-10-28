using Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstractions.Users
{
    public interface IUserService
    {
        AuthenticatedUser Authenticate(AuthenticateParameters authParams);
    }
}
