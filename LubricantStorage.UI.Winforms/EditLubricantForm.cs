using LubricantStorage.Core;
using System.Net;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public partial class EditLubricantForm : AddLubricantForm
    {
        protected readonly string _lubricantId;

        public EditLubricantForm(string lubricantId)
        {
            _lubricantId = lubricantId;

            ModifyForm();

            LoadLubricantToForm();
        }

        private void ModifyForm()
        {
            Text = "Изменение данных масла";

            CreateLubricantButton.Text = "Обновить";

            CharacteristicsPanel.BackColor = Color.IndianRed;

            LubricantNameTextBox.Enabled = false;
        }

        protected async override void CreateLubricantButton_Click(object sender, EventArgs e)
        {
            var lubricant = MapLubricantFromControls();

            lubricant.Id = _lubricantId;

            var response = await _httpClient.PutAsJsonAsync("api/v1/lubricants", lubricant);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Данные масла успешно изменены");
                Close();
            }
        }

        protected async virtual void LoadLubricantToForm()
        {
            var lubricant = await _httpClient
                .GetFromJsonAsync<Lubricant>($"api/v1/lubricants/{_lubricantId}");

            if (lubricant == null || lubricant.Characteristics == null)
            {
                MessageBox.Show("Внутренняя ошибка сервера");
                Close();
            }

            LubricantNameTextBox.Text = lubricant.Name;       
            KinematicViscosity40TextBox.Text = lubricant.Characteristics.KinematicViscosity40C.ToString();
            KinematicViscosity100TextBox.Text = lubricant.Characteristics.KinematicViscosity100C.ToString();
            ViscosityIndexTextBox.Text = lubricant.Characteristics.ViscosityIndex.ToString();
            PourPointTextBox.Text = lubricant.Characteristics.PourPoint.ToString();
            FlashPointTextBox.Text = lubricant.Characteristics.FlashPoint.ToString();
            EvaporationTemperatureTextBox.Text = lubricant.Characteristics.EvaporationTemperature.ToString();
            DensityTextBox.Text = lubricant.Characteristics.Density.ToString();
            AcidNumberTextBox.Text = lubricant.Characteristics.AcidNumber.ToString();
            BaseNumberTextBox.Text = lubricant.Characteristics.BaseNumber.ToString();
            SulfatedAshContentTextBox.Text = lubricant.Characteristics.SulfatedAshContent.ToString();
            WaterContentTextBox.Text = lubricant.Characteristics.WaterContent.ToString();
            ContaminantsTextBox.Text = lubricant.Characteristics.Contaminants.ToString();
            OxidativeStabilityTextBox.Text = lubricant.Characteristics.OxidativeStability.ToString();
            AdditiveCompositionTextBox.Text = lubricant.Characteristics.AdditiveComposition.ToString();
            MaterialCompatibilityTextBox.Text = lubricant.Characteristics.MaterialCompatibility.ToString();
        }
    }
}