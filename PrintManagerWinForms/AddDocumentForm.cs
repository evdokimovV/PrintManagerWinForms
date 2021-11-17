using PrintManager.ViewModels;
using System.Windows.Forms;

namespace PrintManagerWinForms
{
    public partial class AddDocumentForm : Form
    {
        public DocGridItem NewDoc;
        public AddDocumentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            NewDoc = new DocGridItem(tbName.Text, System.Convert.ToInt32(mtbPrintTime.Text));
        }
    }
}
