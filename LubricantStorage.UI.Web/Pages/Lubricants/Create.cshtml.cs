using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class CreateModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public Lubricant? Lubricant { get; set; }

        public async Task<IActionResult> OnPost(Lubricant lubricant)
        {
            var result = await HttpClient.PostAsJsonAsync(ApiConfig.LubricantApiName, lubricant);
            return RedirectToPage("/Lubricants/Index");
        }
    }
}