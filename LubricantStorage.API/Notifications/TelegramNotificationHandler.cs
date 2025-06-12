using LubricantStorage.Core.Notifications;
using Telegram.Bot;

namespace LubricantStorage.API.Notifications
{
    public class TelegramNotificationHandler : INotificationHandler
    {
        private readonly ITelegramSubscriptionRepository _subscriptionRepository;
        private readonly ITelegramBotClient _telegramBotClient;

        public TelegramNotificationHandler(
            ITelegramSubscriptionRepository subscriptionRepository,
            ITelegramBotClient telegramBotClient)
        {
            _subscriptionRepository = subscriptionRepository;
            _telegramBotClient = telegramBotClient;
        }

        public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            var subscriptions = await _subscriptionRepository.List(t => true);
            if (subscriptions != null)
            {
                foreach (var subscription in subscriptions)
                {
                    await _telegramBotClient.SendMessage(
                        subscription.ChatId,
                        message,
                        cancellationToken: cancellationToken);
                }
            }
        }
    }
}