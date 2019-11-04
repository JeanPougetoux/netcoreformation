using MasterClass.Service.Abstractions.Models.Users;
using MasterClass.Service.Abstractions.Users;
using MasterClass.Service.Models.Users;
using MasterClass.Service.Users;
using Microsoft.Extensions.DependencyInjection;

namespace MasterClass.WebApi.StartupExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthenticatedUser, AuthenticatedUser>();
            return services;
        }
    } 
}