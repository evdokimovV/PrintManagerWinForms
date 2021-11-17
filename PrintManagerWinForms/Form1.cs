using PrintManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManagerWinForms
{
    public partial class Form1 : Form
    {
        public PrintManagerViewModel PrintManagerModel { get; set; }
        public Form1()
        {
            InitializeComponent();
            PrintManagerModel = new PrintManagerViewModel();
            bsDocs.DataSource = PrintManagerModel.Docs;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            await PrintManagerModel.StartPrinting();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PrintManagerModel.StopPrinting();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PrintManagerModel.AddNewDoc();
            dataGridView1.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PrintManagerModel.CancelDocPrint((DocGridItem)bsDocs.Current);
        }

        private void btnAvgPrintTime_Click(object sender, EventArgs e)
        {
            var printedDocs = PrintManagerModel.Docs.Where(s => s.Printed == PrintManager.Enums.DocStatusEnum.Printed);
            if (!printedDocs.Any()) return;
            MessageBox.Show($"Среднее время печати: {printedDocs.Average(s => s.PrintTime)} сек.");
        }

        private void btnPrintedDocs_Click(object sender, EventArgs e)
        {
            var printedDocs = PrintManagerModel.Docs.Where(s => s.Printed == PrintManager.Enums.DocStatusEnum.Printed);
            if (!printedDocs.Any()) return;
            MessageBox.Show($"Напечатанные документы:{Environment.NewLine}{string.Join(Environment.NewLine, printedDocs.Select(s => s.Name))}");
        }
    }
}
