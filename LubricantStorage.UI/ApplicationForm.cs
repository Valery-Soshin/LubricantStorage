using LubricantStorage.Core;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public partial class ApplicationForm : Form
    {
        private readonly HttpClient _httpClient;

        public ApplicationForm()
        {
            InitializeComponent();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7136"),
            };
        }

        private async void Create_ClickAsync(object sender, EventArgs e)
        {
            var lubricant = new Lubricant
            {
                Name = "cool - lubricant - 2024"
            };

            var response = await _httpClient
                .PostAsJsonAsync("api/v1/lubricants", lubricant);
        }

        private async void Get_ClickAsync(object sender, EventArgs e)
        {
            var lubricant = await _httpClient
                .GetFromJsonAsync<Lubricant>($"api/v1/lubricants/677ff150224fac04ff993e4c");

            label1.Text = lubricant?.Name;
        }
    }
}