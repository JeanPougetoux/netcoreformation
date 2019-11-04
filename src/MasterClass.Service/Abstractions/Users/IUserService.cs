using MasterClass.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterClass.Service.Abstractions.Users
{
    public interface IUserService
    {
        AuthenticatedUser Authenticate(AuthenticateParameters authParams);
    }
}
