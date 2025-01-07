using LubricantStorage.API.Application.Lubricants.Commands;
using LubricantStorage.API.Models;
using System.Net.Http.Json;

namespace LubricantStorage.UI;

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
        var createLubricantCommand = new CreateLubricantCommand
        {
            Name = "cool - lubricant - 2024"
        };

        var response = await _httpClient
            .PostAsJsonAsync("api/v1/lubricants", createLubricantCommand);
    }

    private async void Get_ClickAsync(object sender, EventArgs e)
    {
        var lubricant = await _httpClient
            .GetFromJsonAsync<Lubricant>($"api/v1/lubricants/677d3607f34867648e41ad77");

        label1.Text = lubricant?.Name;
    }
}