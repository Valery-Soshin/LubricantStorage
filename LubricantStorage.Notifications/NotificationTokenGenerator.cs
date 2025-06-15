using LubricantStorage.Configs;
using LubricantStorage.Core.Notifications;
using Microsoft.Extensions.Options;

namespace LubricantStorage.Notifications
{
    public class NotificationTokenGenerator : INotificaitonTokenGenerator
    {
        private readonly INotificationTokenRepository _tokenRepository;
        private readonly TelegramBotConfig _botConfig;

        public NotificationTokenGenerator(
            INotificationTokenRepository tokenRepository,
            IOptions<TelegramBotConfig> config)
        {
            _tokenRepository = tokenRepository;
            _botConfig = config.Value;
        }

        public async Task<string> GenerateToken(string userId, NotificationType notificationType, CancellationToken cancellationToken)
        {
            var dbToken = await _tokenRepository.Get(t => t.UserId == userId && t.NotificationType == notificationType, cancellationToken);
            if (dbToken == null)
            {
                var token = GenerateToken(userId, notificationType);
                await _tokenRepository.Add(token, cancellationToken);
                return token.Value;
            }
            else if (DateTimeOffset.UtcNow > dbToken.ExpiresAt)
            {
                await _tokenRepository.Remove(t => t.UserId == userId, cancellationToken);

                var token = GenerateToken(userId, notificationType);
                await _tokenRepository.Add(token, cancellationToken);
                return token.Value;
            }
            else
            {
                return dbToken.Value;
            }
        }

        private NotificationToken GenerateToken(string userId, NotificationType notificationType)
        {
            return new NotificationToken()
            {
                UserId = userId,
                Value = Random.Shared.Next(100000, 999999).ToString(),
                ExpiresAt = DateTimeOffset.UtcNow + _botConfig.TokenExpiresIn,
                NotificationType = notificationType
            };
        }
    }
}