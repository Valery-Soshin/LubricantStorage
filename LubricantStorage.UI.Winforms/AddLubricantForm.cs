using LubricantStorage.Core.Lubricants;
using LubricantStorage.UI.Winforms;
using System.Net;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public partial class AddLubricantForm : FormBase
    {
        public AddLubricantForm()
        {
            InitializeComponent();
        }

        protected async virtual void CreateLubricantButton_Click(object sender, EventArgs e)
        {
            var lubricant = MapLubricantFromControls();

            var response = await _httpClient.PostAsJsonAsync("api/v1/lubricants", lubricant);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                MessageBox.Show("Масло успешно добавлено в систему");
                if (Controls["BackButton"] is Button backButton)
                {
                    backButton.PerformClick();
                }
            }
        }

        protected Lubricant MapLubricantFromControls()
        {
            return new Lubricant
            {
                Name = LubricantNameTextBox.Text,
                Characteristics = new LubricantСharacteristics
                {
                    KinematicViscosity40C =
                        ParseHelper.TryParseDoubleOrDefault(KinematicViscosity40TextBox.Text),

                    KinematicViscosity100C =
                        ParseHelper.TryParseDoubleOrDefault(KinematicViscosity100TextBox.Text),

                    ViscosityIndex =
                        ParseHelper.TryParseIntOrDefaultValue(ViscosityIndexTextBox.Text),

                    PourPoint =
                        ParseHelper.TryParseDoubleOrDefault(PourPointTextBox.Text),

                    FlashPoint =
                        ParseHelper.TryParseDoubleOrDefault(FlashPointTextBox.Text),

                    EvaporationTemperature =
                        ParseHelper.TryParseDoubleOrDefault(EvaporationTemperatureTextBox.Text),

                    Density =
                        ParseHelper.TryParseDoubleOrDefault(DensityTextBox.Text),

                    AcidNumber =
                        ParseHelper.TryParseDoubleOrDefault(AcidNumberTextBox.Text),

                    BaseNumber =
                        ParseHelper.TryParseDoubleOrDefault(BaseNumberTextBox.Text),

                    SulfatedAshContent =
                        ParseHelper.TryParseDoubleOrDefault(SulfatedAshContentTextBox.Text),

                    WaterContent =
                        ParseHelper.TryParseDoubleOrDefault(WaterContentTextBox.Text),

                    Contaminants =
                        ParseHelper.TryParseDoubleOrDefault(ContaminantsTextBox.Text),

                    OxidativeStability =
                        ParseHelper.TryParseDoubleOrDefault(OxidativeStabilityTextBox.Text),

                    AdditiveComposition = AdditiveCompositionTextBox.Text,
                    MaterialCompatibility = MaterialCompatibilityTextBox.Text
                }
            };
        }
    }
}