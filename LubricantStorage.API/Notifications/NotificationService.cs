using LubricantStorage.Core.Notifications;

namespace LubricantStorage.API.Notifications
{
    public class NotificationService
    {
        private readonly IEnumerable<INotificationHandler> _notificationHandlers;

        public NotificationService(IEnumerable<INotificationHandler> notificationHandlers)
        {
            _notificationHandlers = notificationHandlers;
        }

        public async Task SendMessagesAsync(string message, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение для уведомлений не может быть пустым или null.");
            }

            if (_notificationHandlers != null)
            {
                foreach (var notificationHandler in _notificationHandlers)
                {
                    await notificationHandler.SendMessageAsync(message, cancellationToken);
                }
            }
        }
    }
}