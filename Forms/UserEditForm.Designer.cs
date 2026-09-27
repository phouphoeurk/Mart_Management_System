namespace Mart_Management_System.Forms
{
    partial class UserEditForm
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
            lblTitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            chkShowPassword = new CheckBox();
            lblRole = new Label();
            cbRole = new ComboBox();
            chkActive = new CheckBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(130, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User";

            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.Location = new Point(25, 70);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(70, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full name:";

            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(25, 95);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(400, 28);
            txtFullName.TabIndex = 2;

            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(25, 135);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 20);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";

            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(25, 160);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 28);
            txtUsername.TabIndex = 4;

            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(25, 200);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";

            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(25, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(400, 28);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;

            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            lblConfirmPassword.Location = new Point(25, 265);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(120, 20);
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirm password:";

            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(25, 290);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(400, 28);
            txtConfirmPassword.TabIndex = 8;
            txtConfirmPassword.UseSystemPasswordChar = true;

            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10F);
            chkShowPassword.Location = new Point(25, 330);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(125, 25);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show password";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(25, 370);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(40, 20);
            lblRole.TabIndex = 10;
            lblRole.Text = "Role:";

            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.Font = new Font("Segoe UI", 10F);
            cbRole.Items.AddRange(new object[] { "Admin", "Cashier" });
            cbRole.Location = new Point(150, 367);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(150, 28);
            cbRole.TabIndex = 11;

            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(330, 370);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(95, 25);
            chkActive.TabIndex = 12;
            chkActive.Text = "Active user";

            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(25, 410);
            lblError.Name = "lblError";
            lblError.Size = new Size(400, 20);
            lblError.TabIndex = 13;

            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(210, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 36);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save User";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(330, 450);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 36);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(470, 510);
            Controls.Add(lblTitle);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(lblRole);
            Controls.Add(cbRole);
            Controls.Add(chkActive);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowPassword;
        private Label lblRole;
        private ComboBox cbRole;
        private CheckBox chkActive;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
