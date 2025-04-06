using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class EditModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public required Lubricant Lubricant { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            var lubricant = await _httpClient.GetFromJsonAsync<Lubricant>(
                ApiConfig.LubricantApiName + $"/{id}");

            if (lubricant == null)
            {
                return RedirectToPage("/Error");
            }

            Lubricant = lubricant;

            return Page();
        }

        public async Task<IActionResult> OnPost(Lubricant lubricant)
        {
            await _httpClient.PostAsJsonAsync(ApiConfig.LubricantApiName, lubricant);
            return RedirectToPage("/Lubricants/Index");
        }
    }
}