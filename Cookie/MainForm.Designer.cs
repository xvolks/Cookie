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
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PacketsListView = new System.Windows.Forms.ListView();
            this.TimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OriginColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.MinimizeButton = new Cookie.Design.BButton();
            this.MaximizeButton = new Cookie.Design.BButton();
            this.CloseButton = new Cookie.Design.BButton();
            this.bForm1.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bForm1
            // 
            this.bForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bForm1.Controls.Add(this.MainTableLayoutPanel);
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
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.MainTableLayoutPanel.Controls.Add(this.ChatTextBox, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.LogTextBox, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.PacketsListView, 0, 0);
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(12, 42);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1064, 560);
            this.MainTableLayoutPanel.TabIndex = 10;
            // 
            // PacketsListView
            // 
            this.PacketsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.PacketsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeColumnHeader,
            this.OriginColumnHeader,
            this.IdColumnHeader,
            this.NameColumnHeader});
            this.PacketsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PacketsListView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketsListView.Location = new System.Drawing.Point(3, 3);
            this.PacketsListView.Name = "PacketsListView";
            this.MainTableLayoutPanel.SetRowSpan(this.PacketsListView, 2);
            this.PacketsListView.Size = new System.Drawing.Size(472, 554);
            this.PacketsListView.TabIndex = 5;
            this.PacketsListView.UseCompatibleStateImageBehavior = false;
            this.PacketsListView.View = System.Windows.Forms.View.Details;
            // 
            // TimeColumnHeader
            // 
            this.TimeColumnHeader.Text = "Heure";
            this.TimeColumnHeader.Width = 70;
            // 
            // OriginColumnHeader
            // 
            this.OriginColumnHeader.Text = "Origine";
            this.OriginColumnHeader.Width = 51;
            // 
            // IdColumnHeader
            // 
            this.IdColumnHeader.Text = "ID";
            this.IdColumnHeader.Width = 51;
            // 
            // NameColumnHeader
            // 
            this.NameColumnHeader.Text = "Nom";
            this.NameColumnHeader.Width = 267;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ChatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTextBox.ForeColor = System.Drawing.Color.White;
            this.ChatTextBox.Location = new System.Drawing.Point(481, 523);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(580, 34);
            this.ChatTextBox.TabIndex = 6;
            this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyDown);
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(481, 3);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(580, 514);
            this.LogTextBox.TabIndex = 4;
            this.LogTextBox.Text = "";
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
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Design.BForm bForm1;
        public System.Windows.Forms.ListView PacketsListView;
        private System.Windows.Forms.ColumnHeader TimeColumnHeader;
        private System.Windows.Forms.ColumnHeader OriginColumnHeader;
        private System.Windows.Forms.ColumnHeader IdColumnHeader;
        private System.Windows.Forms.ColumnHeader NameColumnHeader;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.TextBox ChatTextBox;
        private Design.BButton MinimizeButton;
        private Design.BButton MaximizeButton;
        private Design.BButton CloseButton;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
    }
}

