using LubricantStorage.Core.Notifications;
using LubricantStorage.Notifications.Email;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/notifications/tokens")]
    public class NotificationTokensController : ControllerBase
    {
        private readonly INotificationSubscriptionRepository _subscriptionRepository;
        private readonly INotificationTokenRepository _notificationTokenRepository;
        private readonly INotificaitonTokenGenerator _notificaitonTokenGenerator;
        private readonly EmailNotificationHandler _emailNotificationHandler;

        public NotificationTokensController(
            INotificationSubscriptionRepository notificationSubscriptionRepository,
            INotificationTokenRepository notificationTokenRepository,
            INotificaitonTokenGenerator notificaitonTokenGenerator,
            EmailNotificationHandler emailNotificationHandler)
        {
            _subscriptionRepository = notificationSubscriptionRepository;
            _notificationTokenRepository = notificationTokenRepository;
            _notificaitonTokenGenerator = notificaitonTokenGenerator;
            _emailNotificationHandler = emailNotificationHandler;
        }

        [HttpPost]
        public async Task<string> GenerateToken(NotificationType notificationType, CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var generatedToken = await _notificaitonTokenGenerator.GenerateToken(
                userId, notificationType, cancellationToken);

            return generatedToken.Id;
        }

        [HttpPost("{tokenId}/send-email")]
        public async Task SendTokenToEmail(string tokenId, CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var token = await _notificationTokenRepository.Get(
                t => t.UserId == userId && t.Id == tokenId,
                cancellationToken);

            if (token == null)
            {
                throw new ApplicationException("Токен не найден");
            }

            await _emailNotificationHandler.SendMessageToUser(userId,
                $"Токен авторизации: {token.Value}", cancellationToken);
        }

        [HttpPost("{tokenId}/confirm")]
        public async Task ConfirmToken(string tokenId, string tokenValue, CancellationToken cancellationToken)
        {
            var dbToken = await _notificationTokenRepository.Get(
                t => t.Id == tokenId, cancellationToken);

            if (dbToken == null)
            {
                throw new ArgumentException("Токен не найден.");
            }

            if (dbToken.Value == tokenValue)
            {
                var subscription = await _subscriptionRepository.Get(
                    s => s.UserId == dbToken.UserId && s.NotificationType == dbToken.NotificationType,
                    cancellationToken);

                if (subscription == null)
                {
                    throw new ArgumentException("Подписка на события не найдена.");
                }

                subscription.IsConfirmed = true;

                await _subscriptionRepository.Update(subscription, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Токен неверный");
            }
        }
    }
}