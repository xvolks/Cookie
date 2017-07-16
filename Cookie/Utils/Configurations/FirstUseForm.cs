using System;
using System.IO;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public partial class FirstUseForm : Form
    {
        // Constructor
        public FirstUseForm()
        {
            InitializeComponent();
        }

        // Properties
        public string DofusPath { get; private set; }


        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() != DialogResult.OK) return;
                var path = fbd.SelectedPath;
                txtPath.Text = path;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;

            if (string.IsNullOrEmpty(path) ||
                !File.Exists(Path.Combine(path, "Dofus.exe")) ||
                !Directory.Exists(Path.Combine(path, "app")))
            {
                MessageBox.Show(@"Mauvais chemin vers Dofus.");
                return;
            }

            DofusPath = path;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}