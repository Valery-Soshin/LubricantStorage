using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LubricantStorage.UI.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public LoginViewData Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await HttpClient.PostAsJsonAsync("/api/v1/Auth/Login", Input);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (result == null)
                {
                    TempData["ErrorMessage"] = "Ошибка обработки ответа сервера";
                    return Page();
                }

                Response.Cookies.Append("JwtToken", result.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = Input.RememberMe ? DateTimeOffset.Now.AddDays(30) : DateTimeOffset.Now.AddHours(1)
                });

                return RedirectToPage("/Lubricants/Index");
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                TempData["ErrorMessage"] = "Неверный email или пароль";
                return Page();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = $"Ошибка авторизации: {errorContent}";
                return Page();
            }
        }
    }

    public class LoginViewData
    {
        [Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Введите корректный email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать от {2} до {1} символов", MinimumLength = 6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}