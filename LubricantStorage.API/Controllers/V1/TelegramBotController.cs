using LubricantStorage.Notifications.Telegram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/telegram-bot")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ITelegramBot _telegramBot;

        public TelegramBotController(ITelegramBot telegramBot)
        {
            _telegramBot = telegramBot;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task HandleUpdate([FromBody] Update update, CancellationToken cancellationToken)
        {
            await _telegramBot.HandleUpdate(update, cancellationToken);
        }
    }
}