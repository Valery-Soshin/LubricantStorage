using LubricantStorage.Core.Entities;
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
            Table.Rows.Clear();

            var lubricants = await _httpClient.GetFromJsonAsync<List<Lubricant>>("api/v1/lubricants");

            foreach (var lubricant in lubricants)
            {
                var rowIndex = Table.Rows.Add(
                    lubricant.Name,
                    lubricant.Characteristics?.KinematicViscosity40C,
                    lubricant.Characteristics?.KinematicViscosity100C,
                    lubricant.Characteristics?.ViscosityIndex,
                    lubricant.Characteristics?.PourPoint,
                    lubricant.Characteristics?.FlashPoint,
                    lubricant.Characteristics?.EvaporationTemperature,
                    lubricant.Characteristics?.Density,
                    lubricant.Characteristics?.AcidNumber,
                    lubricant.Characteristics?.BaseNumber,
                    lubricant.Characteristics?.SulfatedAshContent,
                    lubricant.Characteristics?.WaterContent,
                    lubricant.Characteristics?.Contaminants,
                    lubricant.Characteristics?.OxidativeStability,
                    lubricant.Characteristics?.AdditiveComposition,
                    lubricant.Characteristics?.MaterialCompatibility);

                var editControl = new ToolStripMenuItem("Редактировать");
                editControl.Click += (sender, e) =>
                {
                    HideWithOpeningNewForm(new EditLubricantForm(lubricant.Id));
                };

                var row = Table.Rows[rowIndex];
                row.ContextMenuStrip = new ContextMenuStrip()
                {
                    ShowItemToolTips = true
                };
                row.ContextMenuStrip.Items.Add(editControl);
            }
        }

        private async void ListLubricantsForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadTable();
            }
            catch
            {
                MessageBox.Show("Внутренняя ошибка сервера");
            }
        }

        protected override void HideWithOpeningNewForm(FormBase newForm)
        {
            Hide();

            newForm.FormClosed += async (s, e) =>
            {
                await LoadTable();
                Show();
            };

            newForm.Show();
        }
    }
}