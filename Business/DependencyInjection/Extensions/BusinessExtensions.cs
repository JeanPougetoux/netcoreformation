using Business.Abstractions.Users;
using Business.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyInjection.Extensions
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
