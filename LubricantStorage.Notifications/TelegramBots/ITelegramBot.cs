using Telegram.Bot.Types;

namespace LubricantStorage.Notifications.TelegramBots
{
    public interface ITelegramBot
    {
        Task HandleUpdate(Update update, CancellationToken cancellationToken);
    }
}