namespace LubricantStorage.UI
{
    public class FormBase : Form
    {
        protected readonly HttpClient _httpClient;

        public FormBase()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5173"),
            };

            InitializeForm();
        }

        protected virtual void InitializeForm()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected virtual void HideWithOpeningNewForm(FormBase newForm)
        {
            Hide();

            var button = new Button
            {
                Name = "BackButton",
                Text = "Назад",
                Margin = new Padding(0, 0, 0, 20)
            };

            button.Click += (s, args) =>
            {
                newForm.Close();
                Show();
            };

            var controls = newForm.Controls.Cast<Control>().ToArray();
            newForm.Controls.Clear();
            newForm.Controls.Add(button);
            newForm.Controls.AddRange(controls);

            newForm.Show();
        }
    }
}