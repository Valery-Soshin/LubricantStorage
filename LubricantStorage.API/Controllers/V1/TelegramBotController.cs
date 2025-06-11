using LubricantStorage.Core.Entities;
using LubricantStorage.Core.Repositories;
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
        private readonly ITelegramBotClient _botClient;
        private readonly ITelegramSubscriptionRepository _subscriptionRepository;

        public TelegramBotController(
            ITelegramBotClient botClient,
            ITelegramSubscriptionRepository subscriptionRepository)
        {
            _botClient = botClient;
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpPost]
        public async Task HandleRequest([FromBody] Update update)
        {
            var message = update.Message;
            if (message != null && message.Text != null)
            {
                var messageText = message.Text.Trim();
                if (messageText is "/subscribe" or "/подписаться")
                {
                    var userId = User.Identity.Name;

                    ArgumentException.ThrowIfNullOrWhiteSpace(userId);

                    var existingSubscribe = await _subscriptionRepository.CheckAny(s => s.UserId == userId);
                    if (!existingSubscribe)
                    {
                        await _subscriptionRepository.Add(new TelegramSubscription()
                        {
                            UserId = userId,
                            ChatId = message.Chat.Id
                        });

                        await _botClient.SendMessage(message.Chat.Id,
                            "Вы успешно подписались на уведомления системы Lubricant Storage.");
                    }
                    else
                    {
                        await _botClient.SendMessage(message.Chat.Id,
                            "Невозможно повторно подписаться на уведомления.");
                    }
                }
            }
        }
    }
}