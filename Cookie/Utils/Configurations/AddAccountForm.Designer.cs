namespace Cookie.Utils.Configurations
{
    partial class AddAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountForm));
            this.bForm1 = new Cookie.Design.BForm();
            this.CloseButton = new Cookie.Design.BButton();
            this.btnConfirm = new Cookie.Design.BButton();
            this.txtPassword = new Cookie.Design.BTextBox();
            this.txtUsername = new Cookie.Design.BTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bForm1
            // 
            this.bForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bForm1.Controls.Add(this.CloseButton);
            this.bForm1.Controls.Add(this.btnConfirm);
            this.bForm1.Controls.Add(this.txtPassword);
            this.bForm1.Controls.Add(this.txtUsername);
            this.bForm1.Controls.Add(this.label2);
            this.bForm1.Controls.Add(this.label1);
            this.bForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bForm1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bForm1.Location = new System.Drawing.Point(0, 0);
            this.bForm1.Name = "bForm1";
            this.bForm1.Size = new System.Drawing.Size(263, 161);
            this.bForm1.TabIndex = 0;
            this.bForm1.Text = "Cookie - Ajouter un compte";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DisplayImage = global::Cookie.Properties.Resources.cross_remove_sign;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CloseButton.Location = new System.Drawing.Point(229, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(22, 23);
            this.CloseButton.TabIndex = 11;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.DisplayImage = null;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnConfirm.Location = new System.Drawing.Point(165, 118);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 31);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirmer";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 78);
            this.txtPassword.MultiLine = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = false;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(138, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(130, 46);
            this.txtUsername.MultiLine = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = false;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(121, 22);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mot de passe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom du compte :";
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 161);
            this.Controls.Add(this.bForm1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cookie - Ajouter un compte";
            this.bForm1.ResumeLayout(false);
            this.bForm1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Design.BForm bForm1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Design.BButton btnConfirm;
        private Design.BTextBox txtPassword;
        private Design.BTextBox txtUsername;
        private Design.BButton CloseButton;
    }
}