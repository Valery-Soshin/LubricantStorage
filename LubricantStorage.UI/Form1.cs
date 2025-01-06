using LubricantStorage.API.Commands;
using System.Net.Http.Json;

namespace LubricantStorage.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("column2", "helloooo");
            dataGridView1.Rows.Add("helo", "hello2");
            dataGridView1.Rows.Add("helo");
        }

        private async void Form1_ClickAsync(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var createLubricantCommand = new CreateLubricantCommand
            {
                Name = "cool - lubricant - 2024"
            };

            var response = await httpClient
                .PostAsJsonAsync("https://localhost:7136/lubricants", createLubricantCommand );
        }
    }
}