using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public LoginViewData Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var response = await HttpClient.PostAsJsonAsync("/api/v1/Auth/Login", Input);
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

    public class LoginViewData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}