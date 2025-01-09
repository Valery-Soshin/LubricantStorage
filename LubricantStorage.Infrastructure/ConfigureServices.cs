using LubricantStorage.Core;
using Microsoft.Extensions.DependencyInjection;

namespace LubricantStorage.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IRepository<Lubricant>, MongoDbRepositoryBase<Lubricant>>();
            services.AddScoped<IRepository<LubricantСharacteristics>, MongoDbRepositoryBase<LubricantСharacteristics>>();

            return services;
        }
    }
}