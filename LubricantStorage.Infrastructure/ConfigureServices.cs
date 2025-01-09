using LubricantStorage.Core;
using Microsoft.Extensions.DependencyInjection;

namespace LubricantStorage.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();

            services.AddScoped<ILubricantRepository, LubricantRepository>();

            return services;
        }
    }
}