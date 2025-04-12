using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LubricantStorage.UI.Web.Pages.Analytics
{
    public class IndexModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        public List<Lubricant> Lubricants { get; set; } = new();
        public List<string> SelectedLubricantIds { get; set; } = new();

        public async Task OnGetAsync()
        {
            Lubricants = await HttpClient.GetFromJsonAsync<List<Lubricant>>("api/v1/lubricants");
        }

        public async Task<IActionResult> OnPostCompareAsync(List<string> selectedLubricantIds)
        {
            if (selectedLubricantIds == null || selectedLubricantIds.Count < 2)
            {
                TempData["ErrorMessage"] = "Выберите как минимум 2 смазочных материала для сравнения";
                return RedirectToPage();
            }

            SelectedLubricantIds = selectedLubricantIds;
            await OnGetAsync(); // Загружаем данные снова
            return Page();
        }
    }
}