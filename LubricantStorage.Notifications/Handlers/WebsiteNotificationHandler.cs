using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace LubricantStorage.Notifications.Handlers
{
    public class WebsiteNotificationHandler : INotificationHandler
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        private const string GroupName = "Notifications";

        private const string SubscriptionMethodName = "ReceiveNotification";

        public WebsiteNotificationHandler(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToAll(string message, CancellationToken cancellationToken = default)
        {
            await _hubContext.Clients.Group(GroupName)
                .SendAsync(SubscriptionMethodName, message, cancellationToken);
        }

        public Task SendMessageToUser(string userId, string message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}