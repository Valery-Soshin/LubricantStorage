namespace OilStorage.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = (new HttpClient().GetStringAsync("https://localhost:7136/oils")).Result;
            
            dataGridView1.Columns.Add("column2", "helloooo");
            dataGridView1.Rows.Add("helo", "hello2");
            dataGridView1.Rows.Add("helo");
        }
    }
}