using LubricantStorage.Core.Notifications;
using LubricantStorage.Notifications.TelegramBots;
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
        private readonly INotificaitonTokenGenerator _notificaitonTokenGenerator;

        public TelegramBotController(
            ITelegramBot telegramBot,
            INotificaitonTokenGenerator notificaitonTokenGenerator)
        {
            _telegramBot = telegramBot;
            _notificaitonTokenGenerator = notificaitonTokenGenerator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task HandleUpdate([FromBody] Update update, CancellationToken cancellationToken)
        {
            await _telegramBot.HandleUpdate(update, cancellationToken);
        }

        [HttpGet("generate-token")]
        public async Task<string> GenerateToken(CancellationToken cancellationToken)
        {
            return await _notificaitonTokenGenerator.GenerateAsync(User.Identity.Name, cancellationToken);
        }
    }
}