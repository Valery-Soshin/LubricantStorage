using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IEnumerable<INotificationHandler> _notificationHandlers;

        public NotificationsController(IEnumerable<INotificationHandler> notificationHandlers)
        {
            _notificationHandlers = notificationHandlers;
        }

        [HttpPost]
        public async Task SendMessageToAll(string message, CancellationToken cancellationToken)
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