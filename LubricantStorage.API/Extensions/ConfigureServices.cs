using LubricantStorage.API.Notifications;
using LubricantStorage.Core.Notifications;

namespace LubricantStorage.API.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            services.AddScoped<NotificationService>();
            services.AddScoped<INotificationHandler, TelegramNotificationHandler>();
            services.AddScoped<INotificationHandler, WebsiteNotificationHandler>();

            return services;
        }
    }
}