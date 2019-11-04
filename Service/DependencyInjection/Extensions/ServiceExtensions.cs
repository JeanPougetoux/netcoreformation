using Business.Abstractions.Users;
using Business.Users;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstractions.Users;
using Service.Users;

namespace Service.DependencyInjection.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();

            return services;
        }
    }
}
