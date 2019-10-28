using Microsoft.Extensions.DependencyInjection;
using Repository.Abstractions.Users;

namespace Repository.DependencyInjection.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, MockUserRepository>();

            return services;
        }
    }
}
