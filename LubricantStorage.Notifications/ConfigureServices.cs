using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using LubricantStorage.Core.Notifications;
using LubricantStorage.Notifications.Handlers;
using LubricantStorage.Notifications.Telegram;
using Telegram.Bot;

namespace LubricantStorage.Notifications
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            services.AddScoped<ITelegramBot, TelegramBot>();
            services.AddScoped<INotificaitonTokenGenerator, NotificationTokenGenerator>();

            services.AddScoped<INotificationHandler, TelegramNotificationHandler>();
            services.AddScoped<INotificationHandler, WebsiteNotificationHandler>();
            services.AddScoped<INotificationHandler, EmailNotificationHandler>();
            services.AddScoped<EmailNotificationHandler>();

            return services;
        }
    
        public static void AddTelegramBotServices(this IHostApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    var token = configuration["TelegramBotToken"];

                    var options = new TelegramBotClientOptions(token);

                    return new TelegramBotClient(options, httpClient);
                });
        }

        public static void AddTelegramBotWebhooks(this IHost host)
        {
            var botClient = host.Services.GetRequiredService<ITelegramBotClient>();
            var lifeTimeService = host.Services.GetRequiredService<IHostApplicationLifetime>(); ;

            lifeTimeService.ApplicationStarted.Register(async () =>
            {
                await botClient.SetWebhook(
                    url: "https://lubstorage-api-valerysoshin.amvera.io/api/v1/telegram-bot",
                    cancellationToken: lifeTimeService.ApplicationStopping);
            });

            lifeTimeService.ApplicationStopping.Register(async () =>
            {
                await botClient.DeleteWebhook(cancellationToken: lifeTimeService.ApplicationStopping);
            });
        }

        public static void MapNotificationHub(this IEndpointRouteBuilder host)
        {
            host.MapHub<NotificationHub>("/notification");
        }
    }
}