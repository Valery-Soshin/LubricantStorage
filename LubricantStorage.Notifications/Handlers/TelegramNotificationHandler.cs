using LubricantStorage.Core.Notifications;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace LubricantStorage.Notifications.Handlers
{
    public class TelegramNotificationHandler : INotificationHandler
    {
        private readonly INotificationSubscriptionRepository _subscriptionRepository;
        private readonly ITelegramBotClient _telegramBotClient;

        public TelegramNotificationHandler(
            INotificationSubscriptionRepository subscriptionRepository,
            ITelegramBotClient telegramBotClient )
        {
            _subscriptionRepository = subscriptionRepository;
            _telegramBotClient = telegramBotClient;
        }

        public async Task SendMessageToAll(string message, CancellationToken cancellationToken = default)
        {
            var subscriptions = await _subscriptionRepository.List(t => t.IsConfirmed, cancellationToken);
            if (subscriptions != null)
            {
                foreach (var subscription in subscriptions)
                {
                    try
                    {
                        await _telegramBotClient.SendMessage(
                            subscription.ExternalSystemKey,
                            message,
                            cancellationToken: cancellationToken);
                    }
                    catch (ApiRequestException ex) when (ex.ErrorCode == 403) // пользователь заблокировал бота
                    {
                        await _subscriptionRepository.Remove(
                            s => s.Id == subscription.Id,
                            cancellationToken);
                    }
                }
            }
        }

        public Task SendMessageToUser(string userId, string message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}