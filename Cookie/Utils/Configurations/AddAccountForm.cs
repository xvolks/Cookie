using System;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public partial class AddAccountForm : Form
    {
        // Constructor
        public AddAccountForm()
        {
            InitializeComponent();
        }

        // Properties
        public string Username { get; private set; }

        public string Password { get; private set; }


        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)) return;
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}