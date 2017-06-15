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
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.PacketsListView = new System.Windows.Forms.ListView();
            this.TimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OriginColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NoHandlersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.LogTextBox.Location = new System.Drawing.Point(527, 0);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(757, 591);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.Text = "";
            // 
            // PacketsListView
            // 
            this.PacketsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.PacketsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeColumnHeader,
            this.OriginColumnHeader,
            this.IdColumnHeader,
            this.NameColumnHeader});
            this.PacketsListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.PacketsListView.Location = new System.Drawing.Point(0, 0);
            this.PacketsListView.Name = "PacketsListView";
            this.PacketsListView.Size = new System.Drawing.Size(527, 541);
            this.PacketsListView.TabIndex = 1;
            this.PacketsListView.UseCompatibleStateImageBehavior = false;
            this.PacketsListView.View = System.Windows.Forms.View.Details;
            // 
            // TimeColumnHeader
            // 
            this.TimeColumnHeader.Text = "Heure";
            this.TimeColumnHeader.Width = 80;
            // 
            // OriginColumnHeader
            // 
            this.OriginColumnHeader.Text = "Origine";
            this.OriginColumnHeader.Width = 69;
            // 
            // IdColumnHeader
            // 
            this.IdColumnHeader.Text = "ID";
            this.IdColumnHeader.Width = 47;
            // 
            // NameColumnHeader
            // 
            this.NameColumnHeader.Text = "Nom";
            this.NameColumnHeader.Width = 286;
            // 
            // NoHandlersListBox
            // 
            this.NoHandlersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.NoHandlersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoHandlersListBox.ForeColor = System.Drawing.Color.White;
            this.NoHandlersListBox.FormattingEnabled = true;
            this.NoHandlersListBox.Location = new System.Drawing.Point(0, 541);
            this.NoHandlersListBox.Name = "NoHandlersListBox";
            this.NoHandlersListBox.Size = new System.Drawing.Size(527, 50);
            this.NoHandlersListBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 591);
            this.Controls.Add(this.NoHandlersListBox);
            this.Controls.Add(this.PacketsListView);
            this.Controls.Add(this.LogTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cookie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.ListView PacketsListView;
        private System.Windows.Forms.ListBox NoHandlersListBox;
        private System.Windows.Forms.ColumnHeader TimeColumnHeader;
        private System.Windows.Forms.ColumnHeader OriginColumnHeader;
        private System.Windows.Forms.ColumnHeader IdColumnHeader;
        private System.Windows.Forms.ColumnHeader NameColumnHeader;
    }
}

