using MasterClass.Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models.Users
{
    public class AuthenticatedUser
    {
        public int Id { get; }

        private AuthenticatedUser(int id)
        {
            Id = id;
        }

        internal static AuthenticatedUser Create(User user)
            => user == null ? null : new AuthenticatedUser(user.Id);
    }
}
