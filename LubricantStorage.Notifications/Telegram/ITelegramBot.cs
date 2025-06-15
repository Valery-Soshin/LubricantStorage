using Telegram.Bot.Types;

namespace LubricantStorage.Notifications.Telegram
{
    public interface ITelegramBot
    {
        Task HandleUpdate(Update update, CancellationToken cancellationToken);
    }
}