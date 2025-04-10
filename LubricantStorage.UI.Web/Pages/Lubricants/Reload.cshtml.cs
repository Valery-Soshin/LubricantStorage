using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class ReloadModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        public async Task<IActionResult> OnGet()
        {
            await HttpClient.GetAsync(ApiConfig.LubricantApiName + "/reload");

            return RedirectToPage("./Index");
        }
    }
}