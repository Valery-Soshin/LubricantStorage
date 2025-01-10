using LubricantStorage.Core;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public class AddLubricantForm : FormBase
    {
        public AddLubricantForm()
        {
            InitializeComponents();
        }

        protected override void InitializeForm()
        {
            Text = "Создание параметров масла";
            Size = new Size(500, 820);

            base.InitializeForm();
        }

        protected void InitializeComponents()
        {
            int top = 20;

            var lubricantName = AddField("Наименование масла", new TextBox(), ref top);
            var textViscosity40C = AddField("Вязкость при 40°C:", new TextBox(), ref top);
            var textViscosity100C = AddField("Вязкость при 100°C:", new TextBox(), ref top);
            var numericViscosityIndex = AddField("Индекс вязкости:", new NumericUpDown(), ref top);
            var textPourPoint = AddField("Температура застывания (°C):", new TextBox(), ref top);
            var textFlashPoint = AddField("Температура вспышки (°C):", new TextBox(), ref top);
            var textEvaporationTemp = AddField("Температура испарения (°C):", new TextBox(), ref top);
            var textDensity = AddField("Плотность при 15°C (г/см³):", new TextBox(), ref top);
            var textAcidNumber = AddField("Кислотное число (TAN):", new TextBox(), ref top);
            var textBaseNumber = AddField("Щелочное число (TBN):", new TextBox(), ref top);
            var textSulfatedAsh = AddField("Сульфатная зольность (%):", new TextBox(), ref top);
            var textWaterContent = AddField("Содержание воды (%):", new TextBox(), ref top);
            var textContaminants = AddField("Содержание загрязнений (%):", new TextBox(), ref top);
            var textOxidativeStability = AddField("Окислительная стабильность:", new TextBox(), ref top);
            var textAdditives = AddField("Состав присадок:", new TextBox(), ref top);
            var textMaterialCompatibility = AddField("Совместимость с материалами:", new TextBox(), ref top);
            var comboApplicationType = AddField("Тип применения:", new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "Motor", "Transmission", "Hydraulic", "Turbine", "Compressor", "Gear", "Industrial", "Biodegradable" }
            }, ref top);

            var buttonCreate = new Button
            {
                Text = "Создать",
                Top = top + 20,
                Left = 20,
                Width = 100
            };

            buttonCreate.Click += async (sender, args) =>
            {
                try
                {
                    var сharacteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = ParseHelper.TryParseOrDefaultValue(textViscosity40C.Text),
                        KinematicViscosity100C = ParseHelper.TryParseOrDefaultValue(textViscosity100C.Text),
                        ViscosityIndex = (int)numericViscosityIndex.Value,
                        PourPoint = ParseHelper.TryParseOrDefaultValue(textPourPoint.Text),
                        FlashPoint = ParseHelper.TryParseOrDefaultValue(textFlashPoint.Text),
                        EvaporationTemperature = ParseHelper.TryParseOrDefaultValue(textEvaporationTemp.Text),
                        Density = ParseHelper.TryParseOrDefaultValue(textDensity.Text),
                        AcidNumber = ParseHelper.TryParseOrDefaultValue(textAcidNumber.Text),
                        BaseNumber = ParseHelper.TryParseOrDefaultValue(textBaseNumber.Text),
                        SulfatedAshContent = ParseHelper.TryParseOrDefaultValue(textSulfatedAsh.Text),
                        WaterContent = ParseHelper.TryParseOrDefaultValue(textWaterContent.Text),
                        Contaminants = ParseHelper.TryParseOrDefaultValue(textContaminants.Text),
                        OxidativeStability = ParseHelper.TryParseOrDefaultValue(textOxidativeStability.Text),
                        AdditiveComposition = textAdditives.Text,
                        MaterialCompatibility = textMaterialCompatibility.Text,
                    };

                    var lubricant = new Lubricant()
                    {
                        Name = lubricantName.Text,
                        Сharacteristics = сharacteristics
                    };

                    var response = await _httpClient.PostAsJsonAsync("api/v1/lubricants", lubricant);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Объект масла создан успешно!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании объекта: {ex.Message} {ex.Data}");
                }
            };

            Controls.Add(buttonCreate);
        }

        private TControl AddField<TControl>(string labelText, TControl inputControl, ref int top) where TControl : Control
        {
            const int labelWidth = 200;
            const int inputWidth = 200;

            var label = new Label
            {
                Text = labelText,
                Top = top,
                Left = 20,
                Width = labelWidth
            };

            inputControl.Top = top;
            inputControl.Left = labelWidth + 30;
            inputControl.Width = inputWidth;

            Controls.Add(label);
            Controls.Add(inputControl);

            top += 40;

            return inputControl;
        }
    }
}