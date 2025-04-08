using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class CreateModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public LubricantViewModel? Lubricant { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var lubricant = new Lubricant
            {
                Name = Lubricant.Name,
                ApplicationType = Lubricant.ApplicationType,
                Characteristics = new LubricantСharacteristics
                {
                    KinematicViscosity40C = Lubricant.KinematicViscosity40C,
                    KinematicViscosity100C = Lubricant.KinematicViscosity100C,
                    ViscosityIndex = Lubricant.ViscosityIndex,
                    PourPoint = Lubricant.PourPoint,
                    FlashPoint = Lubricant.FlashPoint,
                    EvaporationTemperature = Lubricant.EvaporationTemperature,
                    Density = Lubricant.Density,
                    AcidNumber = Lubricant.AcidNumber,
                    BaseNumber = Lubricant.BaseNumber,
                    SulfatedAshContent = Lubricant.SulfatedAshContent,
                    WaterContent = Lubricant.WaterContent,
                    Contaminants = Lubricant.Contaminants,
                    OxidativeStability = Lubricant.OxidativeStability,
                    AdditiveComposition = Lubricant.AdditiveComposition,
                    MaterialCompatibility = Lubricant.MaterialCompatibility,
                },
            };

            var response = await HttpClient.PostAsJsonAsync(ApiConfig.LubricantApiName, lubricant);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Lubricants/Index");
            }

            ModelState.AddModelError(string.Empty, "Ошибка при сохранении данных");
            return Page();
        }
    }
}