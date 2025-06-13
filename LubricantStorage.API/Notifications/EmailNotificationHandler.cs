using LubricantStorage.API.Configs;
using LubricantStorage.Core.Notifications;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace LubricantStorage.API.Notifications
{
    public class EmailNotificationHandler : INotificationHandler
    {
        private readonly EmailConfig _emailConfig;

        public EmailNotificationHandler(IOptions<EmailConfig> emailOptions)
        {
            _emailConfig = emailOptions.Value;
        }

        public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.System, _emailConfig.Login));
            emailMessage.To.Add(new MailboxAddress("Уважаемый Валерий", _emailConfig.Login));
            emailMessage.Subject = _emailConfig.Subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using var client = new SmtpClient();

            await client.ConnectAsync(_emailConfig.Host, _emailConfig.Port, true, cancellationToken);
            await client.AuthenticateAsync(_emailConfig.Login, _emailConfig.Password, cancellationToken);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}