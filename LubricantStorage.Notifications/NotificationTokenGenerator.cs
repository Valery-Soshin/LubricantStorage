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

        public async Task<string> GenerateAsync(string userId, CancellationToken cancellationToken)
        {
            var dbToken = await _tokenRepository.Get(t => t.UserId == userId, cancellationToken);
            if (dbToken == null)
            {
                var tokenValue = Random.Shared.Next(100000, 999999).ToString();

                await _tokenRepository.Add(new NotificationToken()
                {
                    UserId = userId,
                    Value = tokenValue,
                    ExpiresAt = DateTimeOffset.UtcNow + _botConfig.TokenExpiresIn
                }, cancellationToken);

                return tokenValue;
            }
            else if (DateTimeOffset.UtcNow > dbToken.ExpiresAt)
            {
                await _tokenRepository.Remove(t => t.UserId == userId, cancellationToken);

                var tokenValue = Random.Shared.Next(100000, 999999).ToString();

                await _tokenRepository.Add(new NotificationToken()
                {
                    UserId = userId,
                    Value = tokenValue,
                    ExpiresAt = DateTimeOffset.UtcNow + _botConfig.TokenExpiresIn
                }, cancellationToken);

                return tokenValue;
            }
            else
            {
                return dbToken.Value;
            }
        }
    }
}