using LubricantStorage.Core.Repositories;
using Microsoft.AspNetCore.SignalR;
using Telegram.Bot;

namespace LubricantStorage.API
{
    public class NotificationService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ITelegramSubscriptionRepository _subscriptionRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(
            ITelegramBotClient botClient,
            ITelegramSubscriptionRepository subscriptionRepository,
            IHubContext<NotificationHub> hubContext)
        {
            _botClient = botClient;
            _subscriptionRepository = subscriptionRepository;
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string userId, string message, string groupName, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(userId);
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            ArgumentException.ThrowIfNullOrWhiteSpace(groupName);
            
            await _hubContext.Clients
                .Group(groupName)
                .SendAsync("ReceiveNotification", message, cancellationToken);

            var subscription = await _subscriptionRepository.Get(s => s.UserId == userId);
            if (subscription != null)
            {
                await _botClient.SendMessage(subscription.ChatId, message, cancellationToken: cancellationToken);
            }
       }
    }
}