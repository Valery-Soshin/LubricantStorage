using LubricantStorage.Core.Notifications;
using LubricantStorage.Notifications.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class EmailsController : ControllerBase
    {
        private readonly INotificationSubscriptionRepository _subscriptionRepository;
        private readonly INotificaitonTokenGenerator _notificaitonTokenService;
        private readonly INotificationTokenRepository _notificationTokenRepository;
        private readonly EmailNotificationHandler _emailNotificationHandler;

        public EmailsController(
            INotificationSubscriptionRepository subscriptionRepository,
            INotificaitonTokenGenerator notificaitonTokenService,
            INotificationTokenRepository notificationTokenRepository,
            EmailNotificationHandler emailNotificationHandler)
        {
            _subscriptionRepository = subscriptionRepository;
            _notificaitonTokenService = notificaitonTokenService;
            _notificationTokenRepository = notificationTokenRepository;
            _emailNotificationHandler = emailNotificationHandler;
        }

        [HttpPost]
        public async Task SubscribeToNotifications(CancellationToken cancellationToken)
        {
            var userId = User.Identity.Name;

            var subscription = await _subscriptionRepository.Get(
                s => s.UserId == userId && s.NotificationType == NotificationType.Email,
                cancellationToken);

            if (subscription == null)
            {
                await _subscriptionRepository.Add(new NotificationSubscription()
                {
                    UserId = userId,
                    ExternalSystemKey = userId,
                    IsConfirmed = false,
                    NotificationType = NotificationType.Email
                }, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Подписка уже создана");
            }
        }

        [HttpPost]
        public async Task SendNotificationToken(CancellationToken cancellationToken)
        {
            var userId = User.Identity.Name;

            var token = await _notificaitonTokenService.GenerateToken(
                userId,
                NotificationType.Email, 
                cancellationToken);

            await _emailNotificationHandler.SendMessageToUser(userId,
                $"Токен авторизации: {token}", cancellationToken);
        }

        [HttpPost]
        public async Task ConfirmNotificationToken(string token, CancellationToken cancellationToken)
        {
            var userId = User.Identity.Name;

            var notificationToken = await _notificationTokenRepository.Get(
                t => t.UserId == userId && t.NotificationType == NotificationType.Email,
                cancellationToken);

            if (notificationToken == null)
            {
                throw new ArgumentException("Токен не найден.");
            }

            if (notificationToken.Value == token)
            {
                var subscription = await _subscriptionRepository.Get(
                    s => s.UserId == userId && s.NotificationType == NotificationType.Email, 
                    cancellationToken);

                if (subscription == null)
                {
                    throw new ArgumentException("Подписка на события не найдена.");
                }

                subscription.IsConfirmed = true;

                await _subscriptionRepository.Update(subscription, cancellationToken);
            }
        }
    }
}