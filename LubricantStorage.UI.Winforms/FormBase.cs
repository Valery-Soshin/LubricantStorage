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

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidmFsZXJpdXMtc29zaGluQHlhbmRleC5ydSIsImp0aSI6IjlkMTc0MjQ2LTBlZDItNDU5MC1hODQyLTJkZjdiYTNmYmMxMCIsImV4cCI6MTc0NDU0MDcyNCwiaXNzIjoiQXV0aFNlcnZlci5TZXJ2ZXIiLCJhdWQiOiJBdXRoU2VydmVyLkNsaWVudCJ9.RScA79TPclYqBBGoYbg_2Y2iCcgnTkDhXlUdpmq765E");

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