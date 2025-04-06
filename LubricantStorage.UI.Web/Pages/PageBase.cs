using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LubricantStorage.UI.Web.Pages
{
    public class PageBase : PageModel
    {
        protected readonly HttpClient _httpClient;

        public PageBase(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApiConfig.HttpClientName);
        }
    }
}