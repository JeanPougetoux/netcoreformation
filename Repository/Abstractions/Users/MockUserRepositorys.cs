using MasterClass.Repository.Models.Users;
using Microsoft.Extensions.Options;
using Repository.Mocks.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Abstractions.Users
{
    public class MockUserRepository : IUserRepository
    {
        private readonly MockUsers _mock;

        public MockUserRepository(IOptions<MockUsers> mock) => _mock = mock.Value;

        public User GetUser(string login) => _mock.Users.SingleOrDefault(user => user.Login == login);
    }
}
