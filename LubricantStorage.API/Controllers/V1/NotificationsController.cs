using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationSubscriptionRepository _subscriptionRepository;

        public NotificationsController(
            INotificationService notificationService,
            INotificationSubscriptionRepository subscriptionRepository)
        {
            _notificationService = notificationService;
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpPost("subscribers/send")]
        public async Task SendMessageToAll(string message, CancellationToken cancellationToken)
        {
            await _notificationService.SendMessageAsync(message, cancellationToken);
        }

        [HttpPost("subscriptions")]
        public async Task SubscribeToNotifications(string externalKey, NotificationType notificationType, CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var subscription = await _subscriptionRepository.Get(
                s => s.UserId == userId && s.NotificationType == notificationType,
                cancellationToken);

            if (subscription == null)
            {
                await _subscriptionRepository.Add(new NotificationSubscription()
                {
                    UserId = userId,
                    ExternalSystemKey = externalKey,
                    IsConfirmed = false,
                    NotificationType = notificationType
                }, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Подписка уже создана");
            }
        }
    }
}