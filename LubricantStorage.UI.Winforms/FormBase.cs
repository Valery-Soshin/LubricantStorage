namespace LubricantStorage.UI
{
    public class FormBase : Form
    {
        protected readonly HttpClient _httpClient;

        public FormBase()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://lubstorage.ru/"),
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

            newForm.FormClosed += (s, e) => Show();
            newForm.Show();
        }
    }
}