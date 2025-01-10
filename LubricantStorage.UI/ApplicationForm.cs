namespace LubricantStorage.UI
{
    public partial class ApplicationForm : FormBase
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void AddLubricant_Click(object sender, EventArgs e)
        {
            HideWithOpeningNewForm(new AddLubricantForm());
        }

        private void ListLubricants_Click(object sender, EventArgs e)
        {
            HideWithOpeningNewForm(new ListLubricantsForm());
        }
    }
}