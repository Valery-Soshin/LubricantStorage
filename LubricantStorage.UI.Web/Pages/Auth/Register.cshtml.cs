using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LubricantStorage.UI.Web.Pages.Auth
{
    [AllowAnonymous]
    public class RegisterModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public RegisterViewData Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await HttpClient.PostAsJsonAsync("/api/v1/Auth/Register", Input);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (result == null)
                {
                    TempData["ErrorMessage"] = "������ ��������� ������ �������";
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
                var errorContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    TempData["ErrorMessage"] = $"������ email ��� ������������ ������ �������������";
                }

                return Page();
            }
        }
    }

    public class RegisterViewData
    {
        [Required(ErrorMessage = "���� ����� ����������� ��� ����������")]
        [EmailAddress(ErrorMessage = "������� ���������� email �����")]
        public string Email { get; set; }

        [Required(ErrorMessage = "���� ������ ����������� ��� ����������")]
        [StringLength(100, ErrorMessage = "������ ������ ��������� �� {2} �� {1} ��������", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "���� ���������� ������ ����������� ��� ����������")]
        [Compare("Password", ErrorMessage = "������ �� ���������")]
        public string ConfirmPassword { get; set; }
    }

    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}