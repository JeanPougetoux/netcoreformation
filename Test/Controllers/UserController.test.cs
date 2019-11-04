using MasterClass.Service.Abstractions.Models.Users;
using MasterClass.Service.Models.Users;
using MasterClass.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Controllers.Fixtures;
using Xunit;

namespace Test.Controllers
{
    public class UserControllerTest : IClassFixture<UserControllerFixtureBuilder>
    {
        private readonly UserControllerFixtureBuilder _fixtureBuilder;

        public UserControllerTest(UserControllerFixtureBuilder fixtureBuilder)
        {
            _fixtureBuilder = fixtureBuilder;
        }

        #region Authenticate
        [Fact]
        public void Authenticate_Valid()
        {
            //Given
            var authParams = Mock.Of<AuthenticateParameters>();
            var authUser = Mock.Of<IAuthenticatedUser>();

            var userController = (UserController) _fixtureBuilder
                .Initialize()
                .AddValidAuthentication(authParams, authUser)
                .Build().GetService(typeof(UserController));

            //When
            var actionResult = userController.Authenticate(authParams);

            //Then
            Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            var model = (actionResult as OkObjectResult)?.Value;
            Assert.IsAssignableFrom<IAuthenticatedUser>(model);
            Assert.NotNull(model);
            Assert.Equal(authUser, model);
        }

        [Fact]
        public void Authenticate_Invalid()
        {
            //Given
            var authParams = Mock.Of<AuthenticateParameters>();

            var userController = (UserController)_fixtureBuilder
                .Initialize()
                .AddInvalidAuthentication(authParams)
                .Build().GetService(typeof(UserController));

            //When
            var actionResult = userController.Authenticate(authParams);

            //Then
            Assert.IsAssignableFrom<UnauthorizedResult>(actionResult);
            Assert.NotNull(actionResult);
        }

        #endregion
    }
}
