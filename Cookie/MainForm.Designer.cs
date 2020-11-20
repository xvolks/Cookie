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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lPos = new System.Windows.Forms.Label();
            this.bWest = new Cookie.Design.BButton();
            this.bEast = new Cookie.Design.BButton();
            this.bSouth = new Cookie.Design.BButton();
            this.bNorth = new Cookie.Design.BButton();
            this.mapControl = new DofusMapControl.MapControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PacketsListView = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabPlugin = new Cookie.Design.BTabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.HideFight = new System.Windows.Forms.CheckBox();
            this.LockFight = new System.Windows.Forms.CheckBox();
            this.TabIAControl = new Cookie.Design.BTabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.MinimizeButton = new Cookie.Design.BButton();
            this.MaximizeButton = new Cookie.Design.BButton();
            this.CloseButton = new Cookie.Design.BButton();
            this.PartyOnly = new System.Windows.Forms.CheckBox();
            this.bForm1.SuspendLayout();
            this.bTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TabPlugin.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.TabIAControl.SuspendLayout();
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
            this.bTabControl1.Controls.Add(this.tabPage3);
            this.bTabControl1.Controls.Add(this.tabPage4);
            this.bTabControl1.Controls.Add(this.tabPage2);
            this.bTabControl1.Controls.Add(this.tabPage5);
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
            this.tabPage1.Text = "Accueil";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LogTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChatTextBox, 0, 1);
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
            this.LogTextBox.Location = new System.Drawing.Point(3, 3);
            this.LogTextBox.MultiLine = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.SelectedText = "";
            this.LogTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.LogTextBox.SelectionLength = 0;
            this.LogTextBox.SelectionStart = 0;
            this.LogTextBox.Size = new System.Drawing.Size(895, 532);
            this.LogTextBox.TabIndex = 4;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatTextBox.Location = new System.Drawing.Point(3, 541);
            this.ChatTextBox.MultiLine = false;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.ReadOnly = false;
            this.ChatTextBox.SelectionStart = 0;
            this.ChatTextBox.Size = new System.Drawing.Size(895, 25);
            this.ChatTextBox.TabIndex = 5;
            this.ChatTextBox.UseSystemPasswordChar = false;
            this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage3.Controls.Add(this.lPos);
            this.tabPage3.Controls.Add(this.bWest);
            this.tabPage3.Controls.Add(this.bEast);
            this.tabPage3.Controls.Add(this.bSouth);
            this.tabPage3.Controls.Add(this.bNorth);
            this.tabPage3.Controls.Add(this.mapControl);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage3.Location = new System.Drawing.Point(174, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(907, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Map";
            // 
            // lPos
            // 
            this.lPos.AutoSize = true;
            this.lPos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPos.ForeColor = System.Drawing.Color.RosyBrown;
            this.lPos.Location = new System.Drawing.Point(66, 29);
            this.lPos.Name = "lPos";
            this.lPos.Size = new System.Drawing.Size(0, 20);
            this.lPos.TabIndex = 5;
            // 
            // bWest
            // 
            this.bWest.DisplayImage = null;
            this.bWest.Dock = System.Windows.Forms.DockStyle.Left;
            this.bWest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bWest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bWest.Location = new System.Drawing.Point(3, 26);
            this.bWest.Name = "bWest";
            this.bWest.Size = new System.Drawing.Size(57, 522);
            this.bWest.TabIndex = 4;
            this.bWest.Text = "West";
            this.bWest.UseVisualStyleBackColor = true;
            this.bWest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BWest_MouseClick);
            // 
            // bEast
            // 
            this.bEast.DisplayImage = null;
            this.bEast.Dock = System.Windows.Forms.DockStyle.Right;
            this.bEast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bEast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bEast.Location = new System.Drawing.Point(846, 26);
            this.bEast.Name = "bEast";
            this.bEast.Size = new System.Drawing.Size(58, 522);
            this.bEast.TabIndex = 3;
            this.bEast.Text = "East";
            this.bEast.UseVisualStyleBackColor = true;
            this.bEast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BEast_MouseClick);
            // 
            // bSouth
            // 
            this.bSouth.DisplayImage = null;
            this.bSouth.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bSouth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bSouth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bSouth.Location = new System.Drawing.Point(3, 548);
            this.bSouth.Name = "bSouth";
            this.bSouth.Size = new System.Drawing.Size(901, 23);
            this.bSouth.TabIndex = 2;
            this.bSouth.Text = "South";
            this.bSouth.UseVisualStyleBackColor = true;
            this.bSouth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BSouth_MouseClick);
            // 
            // bNorth
            // 
            this.bNorth.DisplayImage = null;
            this.bNorth.Dock = System.Windows.Forms.DockStyle.Top;
            this.bNorth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bNorth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bNorth.Location = new System.Drawing.Point(3, 3);
            this.bNorth.Name = "bNorth";
            this.bNorth.Size = new System.Drawing.Size(901, 23);
            this.bNorth.TabIndex = 1;
            this.bNorth.Text = "North";
            this.bNorth.UseVisualStyleBackColor = true;
            this.bNorth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BNorth_MouseClick);
            // 
            // mapControl
            // 
            this.mapControl.ActiveCellColor = System.Drawing.Color.Transparent;
            this.mapControl.BorderColorOnOver = System.Drawing.Color.Empty;
            this.mapControl.CommonCellHeight = 43D;
            this.mapControl.CommonCellWidth = 86D;
            this.mapControl.DrawMode = ((DofusMapControl.DrawMode)((((DofusMapControl.DrawMode.Movements | DofusMapControl.DrawMode.Fights) 
            | DofusMapControl.DrawMode.Triggers) 
            | DofusMapControl.DrawMode.Others)));
            this.mapControl.InactiveCellColor = System.Drawing.Color.DarkGray;
            this.mapControl.LesserQuality = false;
            this.mapControl.Location = new System.Drawing.Point(66, 33);
            this.mapControl.MapHeight = 20;
            this.mapControl.MapWidth = 14;
            this.mapControl.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(770, 504);
            this.mapControl.TabIndex = 0;
            this.mapControl.TraceOnOver = false;
            this.mapControl.ViewGrid = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage4.Controls.Add(this.PacketsListView);
            this.tabPage4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage4.Location = new System.Drawing.Point(174, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(907, 574);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Packets";
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
            this.PacketsListView.HideSelection = false;
            this.PacketsListView.Location = new System.Drawing.Point(3, 3);
            this.PacketsListView.Name = "PacketsListView";
            this.PacketsListView.Size = new System.Drawing.Size(901, 568);
            this.PacketsListView.TabIndex = 7;
            this.PacketsListView.UseCompatibleStateImageBehavior = false;
            this.PacketsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Heure";
            this.columnHeaderTime.Width = 148;
            // 
            // columnHeaderOrigin
            // 
            this.columnHeaderOrigin.Text = "Origine";
            this.columnHeaderOrigin.Width = 79;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 91;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Nom";
            this.columnHeaderName.Width = 356;
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
            this.TabPlugin.Controls.Add(this.tabPage7);
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
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage7.Location = new System.Drawing.Point(174, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(723, 560);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "tabPage7";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage5.Controls.Add(this.PartyOnly);
            this.tabPage5.Controls.Add(this.HideFight);
            this.tabPage5.Controls.Add(this.LockFight);
            this.tabPage5.Controls.Add(this.TabIAControl);
            this.tabPage5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage5.Location = new System.Drawing.Point(174, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.tabPage5.Size = new System.Drawing.Size(907, 574);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "IA Settings";
            // 
            // HideFight
            // 
            this.HideFight.AutoCheck = false;
            this.HideFight.AutoSize = true;
            this.HideFight.Location = new System.Drawing.Point(820, 547);
            this.HideFight.Name = "HideFight";
            this.HideFight.Size = new System.Drawing.Size(81, 19);
            this.HideFight.TabIndex = 2;
            this.HideFight.Text = "Hide Fight";
            this.HideFight.UseVisualStyleBackColor = true;
            this.HideFight.CheckedChanged += new System.EventHandler(this.HideFight_CheckedChanged);
            // 
            // LockFight
            // 
            this.LockFight.AutoCheck = false;
            this.LockFight.AutoSize = true;
            this.LockFight.Location = new System.Drawing.Point(736, 547);
            this.LockFight.Name = "LockFight";
            this.LockFight.Size = new System.Drawing.Size(81, 19);
            this.LockFight.TabIndex = 1;
            this.LockFight.Text = "Lock Fight";
            this.LockFight.UseVisualStyleBackColor = true;
            this.LockFight.CheckedChanged += new System.EventHandler(this.LockFight_CheckedChanged);
            // 
            // TabIAControl
            // 
            this.TabIAControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabIAControl.Controls.Add(this.tabPage6);
            this.TabIAControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TabIAControl.ItemSize = new System.Drawing.Size(32, 170);
            this.TabIAControl.Location = new System.Drawing.Point(3, 3);
            this.TabIAControl.Multiline = true;
            this.TabIAControl.Name = "TabIAControl";
            this.TabIAControl.SelectedIndex = 0;
            this.TabIAControl.Size = new System.Drawing.Size(902, 541);
            this.TabIAControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabIAControl.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabPage6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabPage6.Location = new System.Drawing.Point(174, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(724, 533);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Skill Picker";
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
            // PartyOnly
            // 
            this.PartyOnly.AutoSize = true;
            this.PartyOnly.Location = new System.Drawing.Point(647, 546);
            this.PartyOnly.Name = "PartyOnly";
            this.PartyOnly.Size = new System.Drawing.Size(81, 19);
            this.PartyOnly.TabIndex = 4;
            this.PartyOnly.Text = "Party Only";
            this.PartyOnly.UseVisualStyleBackColor = true;
            this.PartyOnly.CheckedChanged += new System.EventHandler(this.PartyOnly_CheckedChanged);
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.TabPlugin.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.TabIAControl.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage3;
        public DofusMapControl.MapControl mapControl;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView PacketsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderOrigin;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private Design.BButton bWest;
        private Design.BButton bEast;
        private Design.BButton bSouth;
        private Design.BButton bNorth;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lPos;
        private System.Windows.Forms.CheckBox HideFight;
        private System.Windows.Forms.CheckBox LockFight;
        private System.Windows.Forms.TabPage tabPage7;
        private Design.BTabControl TabIAControl;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox PartyOnly;
    }
}

