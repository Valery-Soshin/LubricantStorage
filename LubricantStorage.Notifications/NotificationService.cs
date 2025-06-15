using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationHandler> _notificationHandlers;

        public NotificationService(IEnumerable<INotificationHandler> notificationHandlers)
        {
            _notificationHandlers = notificationHandlers;
        }

        public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение не может быть пустым.");
            }

            if (_notificationHandlers != null)
            {
                foreach (var notificationHandler in _notificationHandlers)
                {
                    await notificationHandler.SendMessageToAll(message, cancellationToken);
                }
            }
        }
    }
}