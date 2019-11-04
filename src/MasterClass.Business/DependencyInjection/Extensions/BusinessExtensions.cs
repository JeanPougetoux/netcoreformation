using MasterClass.Business.Abstractions.Users;
using MasterClass.Business.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterClass.Business.DependencyInjection.Extensions
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IUserBusiness, UserBusiness>();

            return services;
        }
    }
}
