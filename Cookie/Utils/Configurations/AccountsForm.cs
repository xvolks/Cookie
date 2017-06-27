using System;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public partial class AccountsForm : Form
    {

        // Properties
        public AccountConfiguration AccountToConnect { get; private set; }


        // Constructor
        public AccountsForm()
        {
            InitializeComponent();

            RefreshAccounts();
        }


        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddAccountForm aaf = new AddAccountForm())
            {
                if (aaf.ShowDialog() == DialogResult.OK)
                {
                    GlobalConfiguration.Instance.AddAccount(aaf.Username, aaf.Password);
                    RefreshAccounts();
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAccounts.FocusedItem == null)
                return;

            GlobalConfiguration.Instance.Accounts.RemoveAt(lvAccounts.FocusedItem.Index);
            RefreshAccounts();
        }

        private void connecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAccounts.FocusedItem == null)
                return;

            AccountToConnect = GlobalConfiguration.Instance.Accounts[lvAccounts.FocusedItem.Index];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RefreshAccounts()
        {
            lvAccounts.Items.Clear();

            GlobalConfiguration.Instance.Accounts.ForEach(a =>
            {
                lvAccounts.Items.Add(a.Username).SubItems.Add(new string('•', a.Password.Length));
            });
        }

    }
}
