using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class DeleteModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        public async Task<IActionResult> OnPost(string id)
        {
            await HttpClient.DeleteAsync(ApiConfig.LubricantApiName + $"/{id}");

            return RedirectToPage("./Index");
        }
    }
}