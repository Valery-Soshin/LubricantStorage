using LubricantStorage.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v{version:apiVersion}/webhook")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ITelegramSubscriptionRepository _subscriptionRepository;

        public TelegramBotController(
            ITelegramBotClient botClient,
            ITelegramSubscriptionRepository subscriptionRepository)
        {
            _telegramBotClient = botClient;
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpPost]
        public async Task HandleUpdate([FromBody] Update update)
        {
            var message = update.Message;
            if (message != null && message.Text != null)
            {
                var messageText = message.Text.Trim();
                var chatId = message.Chat.Id;

                if (messageText is "/start")
                {
                    var existingSubscribe = await _subscriptionRepository.CheckAny(s => s.ChatId == chatId);
                    if (!existingSubscribe)
                    {
                        await _subscriptionRepository.Add(new TelegramSubscription()
                        {
                            ChatId = message.Chat.Id
                        });

                        await _telegramBotClient.SendMessage(message.Chat.Id,
                            "📢 Бот уведомлений LubricantStorage\r\n" +
                            "Подпишись (/sub [TOKEN]) и получай уведомления по системе.");
                    }
                    else
                    {
                        await HandleCommandNotFound(chatId);
                    }
                }
                else if (messageText is "/sub")
                {
                    var userId = "ValerySoshin";

                    ArgumentException.ThrowIfNullOrWhiteSpace(userId);

                    var existingSubscribe = await _subscriptionRepository.CheckAny(s => s.UserId == userId);
                    if (!existingSubscribe)
                    {
                        await _subscriptionRepository.Add(new TelegramSubscription()
                        {
                            UserId = userId,
                            ChatId = message.Chat.Id
                        });

                        await _telegramBotClient.SendMessage(message.Chat.Id,
                            "Вы успешно подписались на уведомления системы Lubricant Storage.");
                    }
                    else
                    {
                        await _telegramBotClient.SendMessage(message.Chat.Id,
                            "Невозможно повторно подписаться на уведомления.");
                    }
                }
                else if (messageText is "/unsub")
                {
                    var subscribe = await _subscriptionRepository.Get(s => s.ChatId == message.Chat.Id);
                    if (subscribe != null)
                    {
                        await _subscriptionRepository.Remove(s => s.Id == subscribe.Id);

                        await _telegramBotClient.SendMessage(message.Chat.Id,
                            "Вы успешно отписались от уведомлений.");
                    }
                    else
                    {
                        await _telegramBotClient.SendMessage(message.Chat.Id,
                            "Невозможно отписаться, Вы не подписаны на уведомления.");
                    }
                }
                else if (messageText is "/help")
                {
                    await _telegramBotClient.SendMessage(chatId,
                        $"Доступные вам команды: {string.Join("\n", GetAvailableCommands())}");
                }
                else
                {
                    await HandleCommandNotFound(chatId);
                }
            }
        }

        public async Task HandleCommandNotFound(long chatId)
        {
            await _telegramBotClient.SendMessage(chatId,
                "Команда не найдена. Воспользуейтесь /help, чтобы увидеть доступные команды.");
        }

        public List<string> GetAvailableCommands()
        {
            return ["/sub", "/unsub"];
        }
    }
}