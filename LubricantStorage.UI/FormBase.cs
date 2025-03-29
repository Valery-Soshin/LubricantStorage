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

        protected void HideWithOpeningNewForm(Form newForm)
        {
            Hide();

            newForm.FormClosed += (s, args) => Show();
            newForm.Show();
        }
    }
}