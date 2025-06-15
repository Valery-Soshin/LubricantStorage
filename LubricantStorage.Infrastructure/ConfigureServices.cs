using AspNetCore.Identity.Mongo.Model;
using AspNetCore.Identity.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LubricantStorage.Core.Lubricants;
using LubricantStorage.Core.Notifications;
using LubricantStorage.Infrastructure.Repositories;

namespace LubricantStorage.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbContext>();

            services.AddScoped<ILubricantRepository, LubricantRepository>();
            services.AddScoped<INotificationSubscriptionRepository, TelegramSubscriptionRepository>();
            services.AddScoped<INotificationTokenRepository, TelegramTokenRepository>();

            services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(
                identityOptions =>
                {
                    identityOptions.Password.RequireDigit = false;
                    identityOptions.Password.RequireLowercase = false;
                    identityOptions.Password.RequireNonAlphanumeric = false;
                    identityOptions.Password.RequireUppercase = false;
                    identityOptions.Password.RequiredLength = 6;
                },
                mongoIdentityOptions =>
                {
                    mongoIdentityOptions.ConnectionString = configuration["Database:ConnectionString"];
                });

            return services;
        }
    }
}