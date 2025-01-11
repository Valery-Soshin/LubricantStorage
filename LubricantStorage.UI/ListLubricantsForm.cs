using LubricantStorage.Core;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public partial class ListLubricantsForm : FormBase
    {
        public ListLubricantsForm()
        {
            InitializeComponent();
        }

        private async Task LoadTable()
        {
            var lubricants = await _httpClient.GetFromJsonAsync<List<Lubricant>>("api/v1/lubricants");

            foreach (var lubricant in lubricants)
            {
                Table.Rows.Add(
                    lubricant.Name,
                    lubricant.Сharacteristics?.KinematicViscosity40C,
                    lubricant.Сharacteristics?.KinematicViscosity100C,
                    lubricant.Сharacteristics?.ViscosityIndex,
                    lubricant.Сharacteristics?.PourPoint,
                    lubricant.Сharacteristics?.FlashPoint,
                    lubricant.Сharacteristics?.EvaporationTemperature,
                    lubricant.Сharacteristics?.Density,
                    lubricant.Сharacteristics?.AcidNumber,
                    lubricant.Сharacteristics?.BaseNumber,
                    lubricant.Сharacteristics?.SulfatedAshContent,
                    lubricant.Сharacteristics?.WaterContent,
                    lubricant.Сharacteristics?.Contaminants,
                    lubricant.Сharacteristics?.OxidativeStability,
                    lubricant.Сharacteristics?.AdditiveComposition,
                    lubricant.Сharacteristics?.MaterialCompatibility);
            }
        }

        private async void ListLubricantsForm_Load(object sender, EventArgs e)
        {
            await LoadTable();
        }
    }
}