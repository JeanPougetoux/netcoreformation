﻿using Business.Abstractions.Users;
using CoreLibrary.Options;
using CoreLibrary.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Abstractions.Users;
using Service.Identity;
using Service.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly JwtOptions _jwtOptions;
        private readonly ISystemClock _clock;

        public UserService(IUserBusiness userBusiness, IOptions<JwtOptions> jwtOptions, ISystemClock clock)
        {
            _userBusiness = userBusiness;
            _jwtOptions = jwtOptions.Value;
            _clock = clock;
        }

        public AuthenticatedUser Authenticate(AuthenticateParameters authParams)
        {
            var user = _userBusiness.AuthenticateUser(authParams.Login, authParams.Password);
            if (user != null)
            {
                var issuedAt = _clock.UtcNow;
                var jwtToken = _jwtOptions.Enabled
                    ? new JwtSecurityToken(
                        issuer: _jwtOptions.Issuer,
                        claims: user.GetJwtClaims(issuedAt),
                        expires: issuedAt.LocalDateTime.Add(_jwtOptions.Duration),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_jwtOptions.Key.ToBytes()), SecurityAlgorithms.HmacSha256))
                    : null;

                return AuthenticatedUser.Create(user, jwtToken == null ? null : new JwtSecurityTokenHandler().WriteToken(jwtToken));
            }
            return null;
        }

        public ClaimsPrincipal SignIn(AuthenticateParameters authParams, string scheme)
        {
            var user = _userBusiness.AuthenticateUser(authParams.Login, authParams.Password);
            return user == null ? null : user.GetClaimsPrincipal(scheme);
        }
    }
}