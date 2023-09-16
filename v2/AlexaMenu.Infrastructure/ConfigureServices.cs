using Microsoft.Extensions.DependencyInjection;
using AlexaMenu.Domain.Base.Adapters;
using AlexaMenu.Domain.Interfaces;
using AlexaMenu.Infrastructure.Database;
using AlexaMenu.Infrastructure.Repository;
using MongoDB.Driver;

namespace AlexaMenu.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMongoDBServices(this IServiceCollection services)
        {
            services.AddScoped<DatabaseConnection>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IDatabaseAdapter<MongoClient>, DatabaseConnection>();

            return services;
        }
    }
}
