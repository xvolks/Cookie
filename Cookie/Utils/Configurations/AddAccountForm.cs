using System;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public partial class AddAccountForm : Form
    {

        // Properties
        public string Username { get; private set; }
        public string Password { get; private set; }


        // Constructor
        public AddAccountForm()
        {
            InitializeComponent();
        }


        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) => Environment.Exit(0);
    }
}
