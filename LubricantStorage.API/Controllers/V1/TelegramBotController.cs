using LubricantStorage.API.Configs;
using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/telegram-bot")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ITelegramSubscriptionRepository _subscriptionRepository;
        private readonly ITelegramTokenRepository _tokenRepository;
        private readonly TelegramBotConfig _botConfig;

        public TelegramBotController(
            ITelegramBotClient botClient,
            ITelegramSubscriptionRepository subscriptionRepository,
            ITelegramTokenRepository tokenRepository,
            IOptions<TelegramBotConfig> config)
        {
            _botClient = botClient;
            _subscriptionRepository = subscriptionRepository;
            _tokenRepository = tokenRepository;
            _botConfig = config.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task HandleUpdate([FromBody] Update update, CancellationToken cancellationToken)
        {
            var times = DateTime.UtcNow - update.Message.Date;
            if (times.TotalMinutes > 3)
            {
                return;
            }

            var message = update.Message;
            if (message != null && message.Text != null)
            {
                var messageText = message.Text.Trim();
                var chatId = message.Chat.Id;

                cancellationToken.ThrowIfCancellationRequested();

                if (messageText is "/start")
                {
                    var existingSubscribe = await _subscriptionRepository.CheckAny(s => s.ChatId == chatId);
                    if (!existingSubscribe)
                    {
                        await _subscriptionRepository.Add(new TelegramSubscription()
                        {
                            ChatId = message.Chat.Id
                        });

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
                else if (messageText.StartsWith("/sub"))
                {
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

                    var subscribe = await _subscriptionRepository.Get(s => s.ChatId == chatId);
                    if (!subscribe.IsAuthorized)
                    {
                        var dbToken = await _tokenRepository.Get(t => t.Value == inputToken);
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
                        subscribe.IsAuthorized = true;

                        await _subscriptionRepository.Update(subscribe);

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
                else if (messageText is "/unsub")
                {
                    var subscribe = await _subscriptionRepository.Get(s => s.ChatId == message.Chat.Id);
                    if (subscribe != null)
                    {
                        await _subscriptionRepository.Remove(s => s.Id == subscribe.Id);

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
                else if (messageText is "/help")
                {
                    await _botClient.SendMessage(chatId,
                        $"Доступные вам команды:\n{string.Join("\n", GetAvailableCommands())}",
                            cancellationToken: cancellationToken);
                }
                else
                {
                    await HandleCommandNotFound(chatId, cancellationToken);
                }
            }
        }

        [HttpGet("generate-token")]
        public async Task<string> GenerateToken(CancellationToken cancellationToken)
        {
            var userId = User.Identity.Name;

            var dbToken = await _tokenRepository.Get(t => t.UserId == userId);
            if (dbToken == null )
            {
                var tokenValue = Random.Shared.Next(100000, 999999).ToString();

                await _tokenRepository.Add(new TelegramToken()
                {
                    UserId = userId,
                    Value = tokenValue,
                    ExpiresAt = DateTimeOffset.UtcNow + _botConfig.TokenExpiresIn
                });

                return tokenValue;
            }
            else if (DateTimeOffset.UtcNow > dbToken.ExpiresAt)
            {
                await _tokenRepository.Remove(t => t.UserId == userId);

                var tokenValue = Random.Shared.Next(100000, 999999).ToString();

                await _tokenRepository.Add(new TelegramToken()
                {
                    UserId = userId,
                    Value = tokenValue,
                    ExpiresAt = DateTimeOffset.UtcNow + _botConfig.TokenExpiresIn
                });

                return tokenValue;
            }
            else
            {
                return dbToken.Value;
            }
        }

        private async Task HandleCommandNotFound(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendMessage(chatId,
                "Команда не найдена. Воспользуейтесь /help, чтобы увидеть доступные команды.",
                cancellationToken: cancellationToken);
        }

        private List<string> GetAvailableCommands()
        {
            return ["/sub", "/unsub"];
        }
    }
}