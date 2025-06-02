using Telegram.Bot;

namespace LubricantStorage.API.Extensions
{
    public static class TelegramBotExtensions
    {
        public static void AddTelegramBotServices(this WebApplicationBuilder builder)
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

        public static void AddTelegramBotWebhooks(this WebApplication app)
        {
            var botClient = app.Services.GetRequiredService<ITelegramBotClient>();

            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                await botClient.SetWebhook(
                    url: "https://lubstorage-api-valerysoshin.amvera.io/api/v1/webhook",
                    cancellationToken: app.Lifetime.ApplicationStopping);
            });

            app.Lifetime.ApplicationStopping.Register(async () =>
            {
                await botClient.DeleteWebhook(cancellationToken: app.Lifetime.ApplicationStopping);
            });
        }
    }
}
