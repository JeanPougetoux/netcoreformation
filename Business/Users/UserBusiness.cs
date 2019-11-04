using Business.Abstractions.Users;
using MasterClass.Repository.Models.Users;
using Repository.Abstractions.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Users
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository) => _userRepository = userRepository;

        public User AuthenticateUser(string login, string password)
        {
            var user = _userRepository.GetUser(login);
            return user != null && user.Password == password ? user : null;
        }
    }
}
