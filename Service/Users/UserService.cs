using Business.Abstractions.Users;
using Service.Abstractions.Users;
using Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness _userBusiness;

        public UserService(IUserBusiness userBusiness) => _userBusiness = userBusiness;

        public AuthenticatedUser Authenticate(AuthenticateParameters authParams)
        {
            return AuthenticatedUser.Create(_userBusiness.AuthenticateUser(authParams.Login, authParams.Password));
        }
    }
}
