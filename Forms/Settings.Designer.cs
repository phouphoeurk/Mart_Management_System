namespace Mart_Management_System.Forms
{
    partial class Settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnAccountInfo = new System.Windows.Forms.Button();
            this.pnlSettingsContent = new System.Windows.Forms.Panel();
            this.pnlAccountInfo = new System.Windows.Forms.Panel();
            this.lblAITitle = new System.Windows.Forms.Label();
            this.pnlUserManagement = new System.Windows.Forms.Panel();
            this.lblUMTitle = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlSettingsContent.SuspendLayout();
            this.pnlAccountInfo.SuspendLayout();
            this.pnlUserManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.pnlMenu.Controls.Add(this.btnUserManagement);
            this.pnlMenu.Controls.Add(this.btnAccountInfo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 450);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 50);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(200, 50);
            this.btnUserManagement.TabIndex = 1;
            this.btnUserManagement.Text = "👥 User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            //this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccountInfo.FlatAppearance.BorderSize = 0;
            this.btnAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccountInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAccountInfo.Size = new System.Drawing.Size(200, 50);
            this.btnAccountInfo.TabIndex = 0;
            this.btnAccountInfo.Text = "👤 Account Info";
            this.btnAccountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountInfo.UseVisualStyleBackColor = true;
            //this.btnAccountInfo.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // pnlSettingsContent
            // 
            this.pnlSettingsContent.Controls.Add(this.pnlAccountInfo);
            this.pnlSettingsContent.Controls.Add(this.pnlUserManagement);
            this.pnlSettingsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettingsContent.Location = new System.Drawing.Point(200, 0);
            this.pnlSettingsContent.Name = "pnlSettingsContent";
            this.pnlSettingsContent.Size = new System.Drawing.Size(600, 450);
            this.pnlSettingsContent.TabIndex = 1;
            // 
            // pnlAccountInfo
            // 
            this.pnlAccountInfo.BackColor = System.Drawing.Color.White;
            this.pnlAccountInfo.Controls.Add(this.lblAITitle);
            this.pnlAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlAccountInfo.Name = "pnlAccountInfo";
            this.pnlAccountInfo.Size = new System.Drawing.Size(600, 450);
            this.pnlAccountInfo.TabIndex = 0;
            // 
            // lblAITitle
            // 
            this.lblAITitle.AutoSize = true;
            this.lblAITitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAITitle.Location = new System.Drawing.Point(20, 20);
            this.lblAITitle.Name = "lblAITitle";
            this.lblAITitle.Size = new System.Drawing.Size(227, 30);
            this.lblAITitle.TabIndex = 0;
            this.lblAITitle.Text = "Account Information";
            // 
            // pnlUserManagement
            // 
            this.pnlUserManagement.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlUserManagement.Controls.Add(this.lblUMTitle);
            this.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserManagement.Location = new System.Drawing.Point(0, 0);
            this.pnlUserManagement.Name = "pnlUserManagement";
            this.pnlUserManagement.Size = new System.Drawing.Size(600, 450);
            this.pnlUserManagement.TabIndex = 1;
            // 
            // lblUMTitle
            // 
            this.lblUMTitle.AutoSize = true;
            this.lblUMTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUMTitle.Location = new System.Drawing.Point(20, 20);
            this.lblUMTitle.Name = "lblUMTitle";
            this.lblUMTitle.Size = new System.Drawing.Size(205, 30);
            this.lblUMTitle.TabIndex = 0;
            this.lblUMTitle.Text = "User Management";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlSettingsContent);
            this.Controls.Add(this.pnlMenu);
            this.Name = "Settings";
            this.Text = "Settings";
            this.pnlMenu.ResumeLayout(false);
            this.pnlSettingsContent.ResumeLayout(false);
            this.pnlAccountInfo.ResumeLayout(false);
            this.pnlAccountInfo.PerformLayout();
            this.pnlUserManagement.ResumeLayout(false);
            this.pnlUserManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnAccountInfo;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Panel pnlSettingsContent;
        private System.Windows.Forms.Panel pnlAccountInfo;
        private System.Windows.Forms.Panel pnlUserManagement;
        private System.Windows.Forms.Label lblAITitle;
        private System.Windows.Forms.Label lblUMTitle;
    }
}