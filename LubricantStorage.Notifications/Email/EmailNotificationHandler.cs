using LubricantStorage.Configs;
using LubricantStorage.Core.Notifications;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace LubricantStorage.Notifications.Email
{
    public class EmailNotificationHandler : INotificationHandler
    {
        private readonly INotificationSubscriptionRepository _notificationSubscription;
        private readonly EmailConfig _emailConfig;

        public EmailNotificationHandler(
            INotificationSubscriptionRepository notificationSubscription,
            IOptions<EmailConfig> emailOptions)
        {
            _notificationSubscription = notificationSubscription;
            _emailConfig = emailOptions.Value;
        }

        public async Task SendMessageToAll(string message, CancellationToken cancellationToken = default)
        {
            var subscriptions = await _notificationSubscription.List(
                s => s.NotificationType == NotificationType.Email && s.IsConfirmed,
                cancellationToken);

            if (subscriptions == null || subscriptions.Count == 0)
            {
                return;
            }

            foreach (var subscription in subscriptions)
            {
                await SendMessage(subscription.ExternalSystemKey, message, cancellationToken);
            }
        }

        public async Task SendMessageToUser(string userId, string message, CancellationToken cancellationToken = default)
        {
            var subscription = await _notificationSubscription.Get(
                s => s.UserId == userId && s.NotificationType == NotificationType.Email && s.IsConfirmed,
                cancellationToken);

            if (subscription == null)
            {
                throw new ArgumentException("Пользователь не найден");
            }

            await SendMessage(subscription.ExternalSystemKey, message, cancellationToken);
        }

        private async Task SendMessage(string email, string message, CancellationToken cancellationToken)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.System, _emailConfig.Login));
            emailMessage.To.Add(new MailboxAddress("Уважаемый", email));
            emailMessage.Subject = _emailConfig.Subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using var smtpClient = new SmtpClient();

            await smtpClient.ConnectAsync(_emailConfig.Host, _emailConfig.Port, true, cancellationToken);
            await smtpClient.AuthenticateAsync(_emailConfig.Login, _emailConfig.Password, cancellationToken);
            await smtpClient.SendAsync(emailMessage);
            await smtpClient.DisconnectAsync(true, cancellationToken);
        }
    }
}