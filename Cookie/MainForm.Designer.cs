namespace Cookie
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bForm1 = new Cookie.Design.BForm();
            this.bTabControl1 = new Cookie.Design.BTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LogTextBox = new Cookie.Design.BRichTextBox();
            this.ChatTextBox = new Cookie.Design.BTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabPlugin = new Cookie.Design.BTabControl();
            this.MinimizeButton = new Cookie.Design.BButton();
            this.MaximizeButton = new Cookie.Design.BButton();
            this.CloseButton = new Cookie.Design.BButton();
            this.PacketsListView = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bForm1.SuspendLayout();
            this.bTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bForm1
            // 
            this.bForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bForm1.Controls.Add(this.bTabControl1);
            this.bForm1.Controls.Add(this.MinimizeButton);
            this.bForm1.Controls.Add(this.MaximizeButton);
            this.bForm1.Controls.Add(this.CloseButton);
            this.bForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bForm1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bForm1.Location = new System.Drawing.Point(0, 0);
            this.bForm1.Name = "bForm1";
            this.bForm1.Size = new System.Drawing.Size(1088, 614);
            this.bForm1.TabIndex = 0;
            this.bForm1.Text = "Cookie";
            // 
            // bTabControl1
            // 
            this.bTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.bTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bTabControl1.Controls.Add(this.tabPage1);
            this.bTabControl1.Controls.Add(this.tabPage2);
            this.bTabControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bTabControl1.ItemSize = new System.Drawing.Size(32, 170);
            this.bTabControl1.Location = new System.Drawing.Point(0, 32);
            this.bTabControl1.Multiline = true;
            this.bTabControl1.Name = "bTabControl1";
            this.bTabControl1.SelectedIndex = 0;
            this.bTabControl1.Size = new System.Drawing.Size(1085, 582);
            this.bTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.bTabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage1.Location = new System.Drawing.Point(174, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(907, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LogTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChatTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PacketsListView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(453, 3);
            this.LogTextBox.MultiLine = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.SelectedText = "";
            this.LogTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.LogTextBox.SelectionLength = 0;
            this.LogTextBox.SelectionStart = 0;
            this.LogTextBox.Size = new System.Drawing.Size(445, 532);
            this.LogTextBox.TabIndex = 4;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatTextBox.Location = new System.Drawing.Point(453, 541);
            this.ChatTextBox.MultiLine = false;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.ReadOnly = false;
            this.ChatTextBox.Size = new System.Drawing.Size(445, 25);
            this.ChatTextBox.TabIndex = 5;
            this.ChatTextBox.UseSystemPasswordChar = false;
            this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage2.Controls.Add(this.TabPlugin);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage2.Location = new System.Drawing.Point(174, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(907, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plugins";
            // 
            // TabPlugin
            // 
            this.TabPlugin.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPlugin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TabPlugin.ItemSize = new System.Drawing.Size(32, 170);
            this.TabPlugin.Location = new System.Drawing.Point(3, 3);
            this.TabPlugin.Multiline = true;
            this.TabPlugin.Name = "TabPlugin";
            this.TabPlugin.SelectedIndex = 0;
            this.TabPlugin.Size = new System.Drawing.Size(901, 568);
            this.TabPlugin.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabPlugin.TabIndex = 0;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.DisplayImage = global::Cookie.Properties.Resources.minimize_tab;
            this.MinimizeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.MinimizeButton.Location = new System.Drawing.Point(998, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(22, 23);
            this.MinimizeButton.TabIndex = 9;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeButton.DisplayImage = global::Cookie.Properties.Resources.maximize;
            this.MaximizeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.MaximizeButton.Location = new System.Drawing.Point(1026, 3);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(22, 23);
            this.MaximizeButton.TabIndex = 8;
            this.MaximizeButton.UseVisualStyleBackColor = true;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DisplayImage = global::Cookie.Properties.Resources.cross_remove_sign;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CloseButton.Location = new System.Drawing.Point(1054, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(22, 23);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PacketsListView
            // 
            this.PacketsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.PacketsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderOrigin,
            this.columnHeaderId,
            this.columnHeaderName});
            this.PacketsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PacketsListView.Location = new System.Drawing.Point(3, 3);
            this.PacketsListView.Name = "PacketsListView";
            this.tableLayoutPanel1.SetRowSpan(this.PacketsListView, 2);
            this.PacketsListView.Size = new System.Drawing.Size(444, 562);
            this.PacketsListView.TabIndex = 6;
            this.PacketsListView.UseCompatibleStateImageBehavior = false;
            this.PacketsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Heure";
            this.columnHeaderTime.Width = 77;
            // 
            // columnHeaderOrigin
            // 
            this.columnHeaderOrigin.Text = "Origine";
            this.columnHeaderOrigin.Width = 54;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 51;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Nom";
            this.columnHeaderName.Width = 223;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 614);
            this.Controls.Add(this.bForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cookie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.bForm1.ResumeLayout(false);
            this.bTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.BForm bForm1;
        private Design.BButton MinimizeButton;
        private Design.BButton MaximizeButton;
        private Design.BButton CloseButton;
        private Design.BTabControl bTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Design.BTabControl TabPlugin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Design.BRichTextBox LogTextBox;
        private Design.BTextBox ChatTextBox;
        private System.Windows.Forms.ListView PacketsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderOrigin;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
    }
}

