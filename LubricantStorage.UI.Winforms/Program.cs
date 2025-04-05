namespace LubricantStorage.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new ApplicationForm());
            }
            catch
            {
                MessageBox.Show("¬нутренн€€ ошибка сервера");
            }
        }
    }
}