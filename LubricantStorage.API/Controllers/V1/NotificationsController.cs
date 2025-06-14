using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task SendMessageAsync(string message, CancellationToken cancellationToken)
        {
            await _notificationService.SendMessages(message, cancellationToken);
        }
    }
}