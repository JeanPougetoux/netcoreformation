using MasterClass.Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterClass.Repository.Abstractions.Users
{
    public interface IUserRepository
    {
        User GetUser(string login);
    }
}
