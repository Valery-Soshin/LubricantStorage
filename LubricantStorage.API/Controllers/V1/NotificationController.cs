using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/notifications")]
    [AllowAnonymous]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task SendMessage(string message, CancellationToken cancellationToken)
        {
            await _notificationService.SendMessageAsync(User.Identity.Name, message, "someGroup", cancellationToken);
        }
    }
}