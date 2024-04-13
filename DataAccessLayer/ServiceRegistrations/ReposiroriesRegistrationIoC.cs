using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.ServiceRegistrations
{
    public static class ReposiroriesRegistrationIoC
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        => services
            .AddScoped<IUserMongoRepository, UserMongoRepository>()
            .AddScoped<IProductMongoRepository, ProductMongoRepository>();

    }
}
