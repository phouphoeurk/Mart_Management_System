namespace Mart_Management_System.Forms
{
    partial class Settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            lblMenuTitle = new Label();
            btnUserManagement = new Button();
            btnAccountInfo = new Button();
            pnlSettingsContent = new Panel();
            pnlAccountInfo = new Panel();
            lblAITitle = new Label();
            accountLayout = new TableLayoutPanel();
            lblFullNameCaption = new Label();
            lblFullNameValue = new Label();
            lblUsernameCaption = new Label();
            lblUsernameValue = new Label();
            lblRoleCaption = new Label();
            lblRoleValue = new Label();
            lblStatusCaption = new Label();
            lblStatusValue = new Label();
            lblAccountHint = new Label();
            pnlUserManagement = new Panel();
            lblUMTitle = new Label();
            lblUMMessage = new Label();
            pnlMenu.SuspendLayout();
            pnlSettingsContent.SuspendLayout();
            pnlAccountInfo.SuspendLayout();
            accountLayout.SuspendLayout();
            pnlUserManagement.SuspendLayout();
            SuspendLayout();

            pnlMenu.BackColor = Color.FromArgb(31, 95, 45);
            pnlMenu.Controls.Add(btnAccountInfo);
            pnlMenu.Controls.Add(btnUserManagement);
            pnlMenu.Controls.Add(lblMenuTitle);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(0);
            pnlMenu.Size = new Size(220, 600);
            pnlMenu.TabIndex = 0;

            lblMenuTitle.Dock = DockStyle.Top;
            lblMenuTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMenuTitle.ForeColor = Color.White;
            lblMenuTitle.Name = "lblMenuTitle";
            lblMenuTitle.Padding = new Padding(20, 20, 0, 0);
            lblMenuTitle.Size = new Size(220, 64);
            lblMenuTitle.TabIndex = 0;
            lblMenuTitle.Text = "SETTINGS";

            btnUserManagement.Dock = DockStyle.Top;
            btnUserManagement.BackColor = Color.FromArgb(31, 95, 45);
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Segoe UI", 10F);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Location = new Point(0, 64);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Padding = new Padding(18, 0, 0, 0);
            btnUserManagement.Size = new Size(220, 52);
            btnUserManagement.TabIndex = 1;
            btnUserManagement.Text = "👥 User Management";
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;

            btnAccountInfo.Dock = DockStyle.Top;
            btnAccountInfo.BackColor = Color.FromArgb(31, 95, 45);
            btnAccountInfo.FlatAppearance.BorderSize = 0;
            btnAccountInfo.FlatStyle = FlatStyle.Flat;
            btnAccountInfo.Font = new Font("Segoe UI", 10F);
            btnAccountInfo.ForeColor = Color.White;
            btnAccountInfo.Location = new Point(0, 0);
            btnAccountInfo.Name = "btnAccountInfo";
            btnAccountInfo.Padding = new Padding(18, 0, 0, 0);
            btnAccountInfo.Size = new Size(220, 52);
            btnAccountInfo.TabIndex = 2;
            btnAccountInfo.Text = "👤 Account Info";
            btnAccountInfo.TextAlign = ContentAlignment.MiddleLeft;
            btnAccountInfo.UseVisualStyleBackColor = false;
            btnAccountInfo.Click += btnAccountInfo_Click;

            pnlSettingsContent.BackColor = Color.White;
            pnlSettingsContent.Controls.Add(pnlUserManagement);
            pnlSettingsContent.Controls.Add(pnlAccountInfo);
            pnlSettingsContent.Dock = DockStyle.Fill;
            pnlSettingsContent.Location = new Point(220, 0);
            pnlSettingsContent.Name = "pnlSettingsContent";
            pnlSettingsContent.Size = new Size(680, 600);
            pnlSettingsContent.TabIndex = 1;

            pnlAccountInfo.BackColor = Color.White;
            pnlAccountInfo.Controls.Add(accountLayout);
            pnlAccountInfo.Controls.Add(lblAITitle);
            pnlAccountInfo.Dock = DockStyle.Fill;
            pnlAccountInfo.Location = new Point(0, 0);
            pnlAccountInfo.Name = "pnlAccountInfo";
            pnlAccountInfo.Size = new Size(680, 600);
            pnlAccountInfo.TabIndex = 0;

            lblAITitle.Dock = DockStyle.Top;
            lblAITitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAITitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblAITitle.Name = "lblAITitle";
            lblAITitle.Padding = new Padding(24, 22, 0, 0);
            lblAITitle.Size = new Size(680, 72);
            lblAITitle.TabIndex = 0;
            lblAITitle.Text = "Account Information";

            accountLayout.ColumnCount = 2;
            accountLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            accountLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            accountLayout.Dock = DockStyle.Top;
            accountLayout.Location = new Point(0, 72);
            accountLayout.Name = "accountLayout";
            accountLayout.Padding = new Padding(24, 12, 24, 12);
            accountLayout.RowCount = 4;
            accountLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            accountLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            accountLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            accountLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            accountLayout.Size = new Size(680, 216);
            accountLayout.TabIndex = 1;

            ConfigureCaption(lblFullNameCaption, "Full name:");
            ConfigureValue(lblFullNameValue);
            ConfigureCaption(lblUsernameCaption, "Username:");
            ConfigureValue(lblUsernameValue);
            ConfigureCaption(lblRoleCaption, "Role:");
            ConfigureValue(lblRoleValue);
            ConfigureCaption(lblStatusCaption, "Status:");
            ConfigureValue(lblStatusValue);
            accountLayout.Controls.Add(lblFullNameCaption, 0, 0);
            accountLayout.Controls.Add(lblFullNameValue, 1, 0);
            accountLayout.Controls.Add(lblUsernameCaption, 0, 1);
            accountLayout.Controls.Add(lblUsernameValue, 1, 1);
            accountLayout.Controls.Add(lblRoleCaption, 0, 2);
            accountLayout.Controls.Add(lblRoleValue, 1, 2);
            accountLayout.Controls.Add(lblStatusCaption, 0, 3);
            accountLayout.Controls.Add(lblStatusValue, 1, 3);

            lblAccountHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAccountHint.AutoSize = false;
            lblAccountHint.ForeColor = Color.Gray;
            lblAccountHint.Location = new Point(24, 320);
            lblAccountHint.Name = "lblAccountHint";
            lblAccountHint.Size = new Size(632, 40);
            lblAccountHint.TabIndex = 2;
            lblAccountHint.Text = "Account details are read-only. An administrator can manage user accounts from the Users screen.";
            pnlAccountInfo.Controls.Add(lblAccountHint);

            pnlUserManagement.BackColor = Color.White;
            pnlUserManagement.Controls.Add(lblUMTitle);
            pnlUserManagement.Controls.Add(lblUMMessage);
            pnlUserManagement.Dock = DockStyle.Fill;
            pnlUserManagement.Location = new Point(0, 0);
            pnlUserManagement.Name = "pnlUserManagement";
            pnlUserManagement.Size = new Size(680, 600);
            pnlUserManagement.TabIndex = 1;
            pnlUserManagement.Visible = false;

            lblUMTitle.Dock = DockStyle.Top;
            lblUMTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUMTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblUMTitle.Name = "lblUMTitle";
            lblUMTitle.Padding = new Padding(24, 22, 0, 0);
            lblUMTitle.Size = new Size(680, 72);
            lblUMTitle.TabIndex = 0;
            lblUMTitle.Text = "User Management";

            lblUMMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUMMessage.AutoSize = false;
            lblUMMessage.ForeColor = Color.Gray;
            lblUMMessage.Font = new Font("Segoe UI", 11F);
            lblUMMessage.Location = new Point(24, 110);
            lblUMMessage.Name = "lblUMMessage";
            lblUMMessage.Size = new Size(632, 60);
            lblUMMessage.TabIndex = 1;
            lblUMMessage.Text = "Use the Users screen in the main navigation to add, edit, activate, or deactivate user accounts.";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(900, 600);
            Controls.Add(pnlSettingsContent);
            Controls.Add(pnlMenu);
            MinimumSize = new Size(800, 500);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlSettingsContent.ResumeLayout(false);
            pnlAccountInfo.ResumeLayout(false);
            pnlAccountInfo.PerformLayout();
            accountLayout.ResumeLayout(false);
            accountLayout.PerformLayout();
            pnlUserManagement.ResumeLayout(false);
            pnlUserManagement.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private static void ConfigureCaption(Label label, string text)
        {
            label.Anchor = AnchorStyles.Left;
            label.AutoSize = false;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(90, 90, 90);
            label.Name = "lblCaption";
            label.Size = new Size(160, 28);
            label.Text = text;
        }

        private static void ConfigureValue(Label label)
        {
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label.AutoSize = false;
            label.Font = new Font("Segoe UI", 10F);
            label.ForeColor = Color.FromArgb(17, 17, 17);
            label.Name = "lblValue";
            label.Size = new Size(420, 28);
            label.Text = "-";
        }

        private Panel pnlMenu;
        private Label lblMenuTitle;
        private Button btnUserManagement;
        private Button btnAccountInfo;
        private Panel pnlSettingsContent;
        private Panel pnlAccountInfo;
        private Label lblAITitle;
        private TableLayoutPanel accountLayout;
        private Label lblFullNameCaption;
        private Label lblFullNameValue;
        private Label lblUsernameCaption;
        private Label lblUsernameValue;
        private Label lblRoleCaption;
        private Label lblRoleValue;
        private Label lblStatusCaption;
        private Label lblStatusValue;
        private Label lblAccountHint;
        private Panel pnlUserManagement;
        private Label lblUMTitle;
        private Label lblUMMessage;
    }
}
