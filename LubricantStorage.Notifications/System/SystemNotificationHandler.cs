using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace LubricantStorage.Notifications.Website
{
    public class SystemNotificationHandler : INotificationHandler
    {
        private readonly IHubContext<SystemNotificationHub> _hubContext;

        private const string GroupName = "Notifications";

        private const string SubscriptionMethodName = "ReceiveNotification";

        public SystemNotificationHandler(IHubContext<SystemNotificationHub> hubContext)
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