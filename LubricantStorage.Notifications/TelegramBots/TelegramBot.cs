using LubricantStorage.Configs;
using LubricantStorage.Core.Notifications;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LubricantStorage.Notifications.TelegramBots
{
    public class TelegramBot : ITelegramBot
    {
        private readonly ITelegramBotClient _botClient;
        private readonly INotificationSubscriptionRepository _subscriptionRepository;
        private readonly INotificationTokenRepository _tokenRepository;
        private readonly TelegramBotConfig _botConfig;

        private const string StartCommand = "/start";
        private const string HelpCommand = "/help";
        private const string SubscriptionCommand = "/sub";
        private const string UnSubscriptionCommand = "/unsub";

        public TelegramBot(
            ITelegramBotClient botClient,
            INotificationSubscriptionRepository subscriptionRepository,
            INotificationTokenRepository tokenRepository,
            IOptions<TelegramBotConfig> config)
        {
            _botClient = botClient;
            _subscriptionRepository = subscriptionRepository;
            _tokenRepository = tokenRepository;
            _botConfig = config.Value;
        }

        public async Task HandleUpdate(Update update, CancellationToken cancellationToken)
        {
            if (IsOldMessage(update))
            {
                return;
            }

            var message = update.Message;
            var chatId = message.Chat.Id;

            if (message != null && message.Text != null)
            {
                var messageText = message.Text.Trim();

                if (messageText is StartCommand)
                {
                    await HandleStartCommand(message, chatId, cancellationToken);
                }
                else if (messageText.StartsWith(SubscriptionCommand))
                {
                    await HandleSubscriptionCommand(message, chatId, cancellationToken);
                }
                else if (messageText is UnSubscriptionCommand)
                {
                    await HandleUnSubscriptionCommand(message, cancellationToken);
                }
                else if (messageText is HelpCommand)
                {
                    await HandleHelpCommand(chatId, cancellationToken);
                }
                else
                {
                    await HandleCommandNotFound(chatId, cancellationToken);
                }
            }
        }

        private async Task HandleStartCommand(Message message, long chatId, CancellationToken cancellationToken)
        {
            var existingSubscribe = await _subscriptionRepository.CheckAny(
                s => s.ExternalSystemKey == chatId &&
                s.NotificationType == NotificationType.Telegram,
                cancellationToken);

            if (!existingSubscribe)
            {
                await _subscriptionRepository.Add(new NotificationSubscription()
                {
                    ExternalSystemKey = message.Chat.Id
                }, cancellationToken);

                await _botClient.SendMessage(message.Chat.Id,
                    "📢 Бот уведомлений LubricantStorage\r\n" +
                    "Подпишись (/sub [TOKEN]) и получай уведомления по системе.",
                    cancellationToken: cancellationToken);
            }
            else
            {
                await HandleCommandNotFound(chatId, cancellationToken);
            }
        }

        private async Task HandleHelpCommand(long chatId, CancellationToken cancellationToken)
        {
            await _botClient.SendMessage(chatId,
                $"Доступные вам команды:\n{string.Join("\n", GetAvailableCommands())}",
                cancellationToken: cancellationToken);
        }

        private async Task HandleSubscriptionCommand(Message message, long chatId, CancellationToken cancellationToken)
        {
            var messageText = message.Text.Trim();
            var messageParts = messageText.Split("/sub");

            if (messageParts.Length != 2)
            {
                await _botClient.SendMessage(chatId,
                    "Некорректный синтаксис команды.\n" +
                    "Нужно ввести в следующем формате: /sub [TOKEN]." +
                    "Квадратные скобки не нужно указывать.",
                    cancellationToken: cancellationToken);

                return;
            }

            var inputToken = messageParts[1]?.Trim();
            if (inputToken == null || inputToken.Length != 6)
            {
                await _botClient.SendMessage(chatId,
                    "Введен неправильный токен авторизации.",
                    cancellationToken: cancellationToken);

                return;
            }

            var subscribe = await _subscriptionRepository.Get(s => s.ExternalSystemKey == chatId);
            if (!subscribe.IsConfirmed)
            {
                var dbToken = await _tokenRepository.Get(t => t.Value == inputToken, cancellationToken);
                if (dbToken == null)
                {
                    await _botClient.SendMessage(chatId,
                        "Введен неправильный токен авторизации.",
                        cancellationToken: cancellationToken);

                    return;
                }
                else if (DateTimeOffset.UtcNow > dbToken.ExpiresAt)
                {
                    await _botClient.SendMessage(chatId,
                        "Истек срок жизни токена авторизации. Вам необходимо запросить новый.",
                        cancellationToken: cancellationToken);

                    return;
                }

                subscribe.UserId = dbToken.UserId;
                subscribe.IsConfirmed = true;

                await _subscriptionRepository.Update(subscribe, cancellationToken);

                await _tokenRepository.Remove(t => t.Id == dbToken.Id, cancellationToken);

                await _botClient.SendMessage(message.Chat.Id,
                    "Вы успешно подписались на уведомления системы Lubricant Storage.",
                    cancellationToken: cancellationToken);
            }
            else
            {
                await _botClient.SendMessage(message.Chat.Id,
                    "Невозможно повторно подписаться на уведомления.",
                    cancellationToken: cancellationToken);
            }
        }

        private async Task HandleUnSubscriptionCommand(Message message, CancellationToken cancellationToken)
        {
            var subscribe = await _subscriptionRepository.Get(
                s => s.ExternalSystemKey == message.Chat.Id,
                cancellationToken);

            if (subscribe != null)
            {
                subscribe.IsConfirmed = false;

                await _subscriptionRepository.Update(subscribe, cancellationToken);

                await _botClient.SendMessage(message.Chat.Id,
                    "Вы успешно отписались от уведомлений.",
                    cancellationToken: cancellationToken);
            }
            else
            {
                await _botClient.SendMessage(message.Chat.Id,
                    "Невозможно отписаться, Вы не подписаны на уведомления.",
                    cancellationToken: cancellationToken);
            }
        }

        private async Task HandleCommandNotFound(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendMessage(chatId,
                "Команда не найдена. Воспользуейтесь /help, чтобы увидеть доступные команды.",
                cancellationToken: cancellationToken);
        }
        
        private static bool IsOldMessage(Update update)
        {
            var times = DateTime.UtcNow - update.Message.Date;

            return times.TotalMinutes > 3;
        }

        private static List<string> GetAvailableCommands()
        {
            return [SubscriptionCommand, UnSubscriptionCommand];
        }
    }
}