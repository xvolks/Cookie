using System;
using System.Windows.Forms;

namespace Cookie.Utils.Configurations
{
    public partial class AccountsForm : Form
    {
        // Constructor
        public AccountsForm()
        {
            InitializeComponent();

            RefreshAccounts();
        }

        // Properties
        public AccountConfiguration AccountToConnect { get; private set; }

        private void RefreshAccounts()
        {
            lvAccounts.Items = new ListViewItem[] { }; // lvAccounts.Items.Clear();

            GlobalConfiguration.Instance.Accounts.ForEach(a =>
            {
                lvAccounts.Add(new ListViewItem(a.Username));
                lvAccounts.Items[lvAccounts.Items.Length - 1].SubItems.Add(new string('•', a.Password.Length));
            });
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedIndex == -1)
                return;

            AccountToConnect = GlobalConfiguration.Instance.Accounts[lvAccounts.SelectedIndex];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aaf = new AddAccountForm())
            {
                if (aaf.ShowDialog() != DialogResult.OK) return;
                GlobalConfiguration.Instance.AddAccount(aaf.Username, aaf.Password);
                RefreshAccounts();
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAccounts.FocusedItem == null)
                return;

            GlobalConfiguration.Instance.removeAccount(lvAccounts.SelectedIndex);
            lvAccounts.SelectedIndex = -1;
            RefreshAccounts();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}