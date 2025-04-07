using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class ListLubricantsModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public List<Lubricant>? Lubricants { get; set; }

        public async Task OnGetAsync()
        {
            Lubricants = await HttpClient.GetFromJsonAsync<List<Lubricant>>("api/v1/lubricants");
        }
    }
}
