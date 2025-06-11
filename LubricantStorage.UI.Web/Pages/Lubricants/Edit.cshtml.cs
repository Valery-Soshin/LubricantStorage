using LubricantStorage.Core;
using LubricantStorage.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    public class EditModel(IHttpClientFactory httpClientFactory) : PageBase(httpClientFactory)
    {
        [BindProperty]
        public required LubricantViewModel Lubricant { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            var lubricant = await HttpClient.GetFromJsonAsync<Lubricant>(
                ApiConfig.LubricantApiName + $"/{id}");

            if (lubricant == null)
            {
                return RedirectToPage("/Error");
            }

            Lubricant = new LubricantViewModel()
            {
                Id = lubricant.Id,
                Name = lubricant.Name,
                ApplicationType = lubricant.ApplicationType,
                KinematicViscosity40C = lubricant.Characteristics.KinematicViscosity40C,
                KinematicViscosity100C = lubricant.Characteristics.KinematicViscosity100C,
                ViscosityIndex = lubricant.Characteristics.ViscosityIndex,
                PourPoint = lubricant.Characteristics.PourPoint,
                FlashPoint = lubricant.Characteristics.FlashPoint,
                EvaporationTemperature = lubricant.Characteristics.EvaporationTemperature,
                Density = lubricant.Characteristics.Density,
                AcidNumber = lubricant.Characteristics.AcidNumber,
                BaseNumber = lubricant.Characteristics.BaseNumber,
                SulfatedAshContent = lubricant.Characteristics.SulfatedAshContent,
                WaterContent = lubricant.Characteristics.WaterContent,
                Contaminants = lubricant.Characteristics.Contaminants,
                OxidativeStability = lubricant.Characteristics.OxidativeStability,
                AdditiveComposition = lubricant.Characteristics.AdditiveComposition,
                MaterialCompatibility = lubricant.Characteristics.MaterialCompatibility,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var lubricant = new Lubricant
            {
                Id = Lubricant.Id,
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

            await HttpClient.PutAsJsonAsync(ApiConfig.LubricantApiName, lubricant);
            return RedirectToPage("/Lubricants/Index");
        }
    }
}