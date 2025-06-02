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

        public TelegramBotController(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            var message = update.Message;

            if (message != null && message.Text != null)
            {
                await _botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: $"Вы сказали: {message.Text}");
            }

            return Ok();
        }
    }
}