using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LubricantStorage.UI.Web.Pages
{
    public class PageBase : PageModel
    {
        protected HttpClient HttpClient
        {
            get
            {
                if (Request != null && Request.Cookies != null &&
                    Request.Cookies.ContainsKey("JwtToken"))
                {
                    if (_httpClient != null && !_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                    {
                        var token = Request.Cookies["JwtToken"];
                        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }
                }

                return _httpClient;
            }
        }

        private readonly HttpClient _httpClient;

        public PageBase(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApiConfig.HttpClientName);        
        }
    }
}