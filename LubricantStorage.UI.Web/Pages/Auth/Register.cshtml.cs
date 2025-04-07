using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Auth
{
    [AllowAnonymous]
    public class RegisterModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public RegisterViewData Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var response = await HttpClient.PostAsJsonAsync("/api/v1/Auth/Register", Input);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (result == null)
                {
                    return Page();
                }

                Response.Cookies.Append("JwtToken", result.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });

                return RedirectToPage("/Lubricants/Index");
            }
            else
            {
                return Page();
            }
        }
    }

    public class RegisterViewData
    {
        public string Email { get; set;  }
        public string Password { get; set;  }
        public string ConfirmPassword { get; set;  }
    }

    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}