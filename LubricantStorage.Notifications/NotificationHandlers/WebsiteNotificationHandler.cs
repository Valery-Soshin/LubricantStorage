using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace LubricantStorage.Notifications.NotificationHandlers
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

        public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            await _hubContext.Clients.Group(GroupName)
                .SendAsync(SubscriptionMethodName, message, cancellationToken);
        }
    }
}