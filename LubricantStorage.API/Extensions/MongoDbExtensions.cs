using LubricantStorage.API.Models;
using MongoDB.Driver;

namespace LubricantStorage.API.Extensions
{
    public static class MongoDbExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Database:ConnectionString"];

            services.AddSingleton(sp => connectionString is null
                ? new MongoClient().GetDatabase(configuration["Database:DatabaseName"])
                : new MongoClient(connectionString).GetDatabase(configuration["Database:DatabaseName"]));

            services.AddSingleton(sp => sp.GetRequiredService<IMongoDatabase>()
                .GetCollection<Lubricant>(nameof(Lubricant)));

            return services;
        }
    }
}