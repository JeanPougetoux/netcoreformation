using MasterClass.Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions.Users
{
    public interface IUserBusiness
    {
        User AuthenticateUser(string login, string password);
    }
}
