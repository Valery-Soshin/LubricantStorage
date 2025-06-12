using LubricantStorage.Core.Lubricants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    [AllowAnonymous]
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
