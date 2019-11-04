using MasterClass.WebApi.Authorization;
using MasterClass.WebApi.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Service.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.DependencyInjection.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddMasterClassAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.REQUIRED_SUPERADMIN_ROLE, policy =>
                    policy.RequireRole("Admin")
                        .RequireClaim(MasterClassClaims.RIGHTS_CLAIMNAME, "SuperAdmin"));
                options.AddPolicy(Policies.REQUIRED_ADMIN_ROLE, policy => policy.RequireRole("Admin"));
                options.AddPolicy(Policies.REQUIRED_ALCOHOL_MAJORITY, policy =>
                        policy.Requirements.Add(new MinimumAgeRequirement(18)));
            });

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();

            return services;
        }
    }
}
