namespace Cookie.Utils.Configurations
{
    partial class AccountsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsForm));
            this.bForm1 = new Cookie.Design.BForm();
            this.lvAccounts = new Cookie.Design.BListView();
            this.MainContextMenuStrip = new Cookie.Design.BContextMenuStrip();
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseButton = new Cookie.Design.BButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bForm1.SuspendLayout();
            this.MainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bForm1
            // 
            this.bForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bForm1.Controls.Add(this.lvAccounts);
            this.bForm1.Controls.Add(this.CloseButton);
            this.bForm1.Controls.Add(this.label1);
            this.bForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bForm1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bForm1.Location = new System.Drawing.Point(0, 0);
            this.bForm1.Name = "bForm1";
            this.bForm1.Size = new System.Drawing.Size(341, 285);
            this.bForm1.TabIndex = 1;
            this.bForm1.Text = "Cookie - Connecter un compte";
            // 
            // lvAccounts
            // 
            this.lvAccounts.Columns = new string[] {
        "Nom de compte",
        "Mot de passe"};
            this.lvAccounts.ColumnWidth = 120;
            this.lvAccounts.ContextMenuStrip = this.MainContextMenuStrip;
            this.lvAccounts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lvAccounts.Grid = false;
            this.lvAccounts.HandleItemsForeColor = false;
            this.lvAccounts.Items = null;
            this.lvAccounts.Location = new System.Drawing.Point(12, 75);
            this.lvAccounts.Multiselect = false;
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.SelectedIndex = -1;
            this.lvAccounts.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("lvAccounts.SelectedIndexes")));
            this.lvAccounts.Size = new System.Drawing.Size(317, 198);
            this.lvAccounts.TabIndex = 9;
            this.lvAccounts.Text = "bListView1";
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.MainContextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolStripMenuItem,
            this.toolStripSeparator1,
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.Size = new System.Drawing.Size(128, 76);
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ConnectToolStripMenuItem.Text = "Connecter";
            this.ConnectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.AddToolStripMenuItem.Text = "Ajouter";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.RemoveToolStripMenuItem.Text = "Supprimer";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DisplayImage = global::Cookie.Properties.Resources.cross_remove_sign;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CloseButton.Location = new System.Drawing.Point(307, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(22, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compte(s) :";
            // 
            // AccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 285);
            this.Controls.Add(this.bForm1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cookie - Comptes";
            this.bForm1.ResumeLayout(false);
            this.bForm1.PerformLayout();
            this.MainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Design.BForm bForm1;
        private System.Windows.Forms.Label label1;
        private Design.BContextMenuStrip MainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private Design.BButton CloseButton;
        private Design.BListView lvAccounts;
    }
}