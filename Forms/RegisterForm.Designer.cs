namespace Mart_Management_System.Forms
{
    partial class RegisterForm
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
            if (disposing && components is not null)
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
            mainLayout = new TableLayoutPanel();
            imagePanel = new Panel();
            pictureBox1 = new PictureBox();
            formPanel = new Panel();
            formContent = new TableLayoutPanel();
            lbRegister = new Label();
            lblSubtitle = new Label();
            labelFullName = new Label();
            txtFullName = new TextBox();
            lblFullNameError = new Label();
            labelUsername = new Label();
            txtUsername = new TextBox();
            lblUsernameError = new Label();
            labelPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordError = new Label();
            labelConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPasswordError = new Label();
            checkBox1 = new CheckBox();
            btnRegister = new Button();
            footerLayout = new TableLayoutPanel();
            lblHaveAccount = new Label();
            lnkGoToLogin = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainLayout.SuspendLayout();
            formContent.SuspendLayout();
            footerLayout.SuspendLayout();
            SuspendLayout();

            mainLayout.BackColor = Color.White;
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            mainLayout.Controls.Add(imagePanel, 0, 0);
            mainLayout.Controls.Add(formPanel, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Margin = new Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1200, 820);
            mainLayout.TabIndex = 0;

            imagePanel.BackColor = Color.FromArgb(238, 241, 244);
            imagePanel.Controls.Add(pictureBox1);
            imagePanel.Dock = DockStyle.Fill;
            imagePanel.Location = new Point(0, 0);
            imagePanel.Margin = new Padding(0);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(624, 820);
            imagePanel.TabIndex = 0;

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 820);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;

            formPanel.BackColor = Color.White;
            formPanel.Controls.Add(formContent);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(624, 0);
            formPanel.Margin = new Padding(0);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(576, 820);
            formPanel.TabIndex = 1;

            formContent.ColumnCount = 1;
            formContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formContent.Controls.Add(lbRegister, 0, 1);
            formContent.Controls.Add(lblSubtitle, 0, 2);
            formContent.Controls.Add(labelFullName, 0, 3);
            formContent.Controls.Add(txtFullName, 0, 4);
            formContent.Controls.Add(lblFullNameError, 0, 5);
            formContent.Controls.Add(labelUsername, 0, 6);
            formContent.Controls.Add(txtUsername, 0, 7);
            formContent.Controls.Add(lblUsernameError, 0, 8);
            formContent.Controls.Add(labelPassword, 0, 9);
            formContent.Controls.Add(txtPassword, 0, 10);
            formContent.Controls.Add(lblPasswordError, 0, 11);
            formContent.Controls.Add(labelConfirmPassword, 0, 12);
            formContent.Controls.Add(txtConfirmPassword, 0, 13);
            formContent.Controls.Add(lblConfirmPasswordError, 0, 14);
            formContent.Controls.Add(checkBox1, 0, 15);
            formContent.Controls.Add(btnRegister, 0, 16);
            formContent.Controls.Add(footerLayout, 0, 17);
            formContent.Dock = DockStyle.Fill;
            formContent.Location = new Point(0, 0);
            formContent.Margin = new Padding(0);
            formContent.Name = "formContent";
            formContent.Padding = new Padding(42, 24, 42, 24);
            formContent.RowCount = 19;
            formContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            formContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            formContent.Size = new Size(576, 820);
            formContent.TabIndex = 0;

            lbRegister.Dock = DockStyle.Fill;
            lbRegister.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lbRegister.ForeColor = Color.FromArgb(7, 132, 59);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(492, 56);
            lbRegister.TabIndex = 0;
            lbRegister.Text = "Sign Up Now";
            lbRegister.TextAlign = ContentAlignment.MiddleCenter;

            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(492, 24);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "An administrator approves new accounts before they can sign in.";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            labelFullName.AutoSize = false;
            labelFullName.Dock = DockStyle.Fill;
            labelFullName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelFullName.ForeColor = Color.FromArgb(64, 64, 64);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(492, 30);
            labelFullName.TabIndex = 2;
            labelFullName.Text = "Full name";
            labelFullName.TextAlign = ContentAlignment.MiddleLeft;

            txtFullName.BackColor = Color.Silver;
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.ForeColor = Color.Black;
            txtFullName.Location = new Point(42, 158);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = " Enter your full name";
            txtFullName.Size = new Size(492, 44);
            txtFullName.TabIndex = 3;

            lblFullNameError.AutoSize = false;
            lblFullNameError.Dock = DockStyle.Fill;
            lblFullNameError.Font = new Font("Segoe UI", 9F);
            lblFullNameError.ForeColor = Color.Firebrick;
            lblFullNameError.Name = "lblFullNameError";
            lblFullNameError.Size = new Size(492, 20);
            lblFullNameError.TabIndex = 4;
            lblFullNameError.TextAlign = ContentAlignment.MiddleLeft;

            labelUsername.AutoSize = false;
            labelUsername.Dock = DockStyle.Fill;
            labelUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(64, 64, 64);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(492, 30);
            labelUsername.TabIndex = 5;
            labelUsername.Text = "Username";
            labelUsername.TextAlign = ContentAlignment.MiddleLeft;

            txtUsername.BackColor = Color.Silver;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(42, 252);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = " Enter your username";
            txtUsername.Size = new Size(492, 44);
            txtUsername.TabIndex = 6;

            lblUsernameError.AutoSize = false;
            lblUsernameError.Dock = DockStyle.Fill;
            lblUsernameError.Font = new Font("Segoe UI", 9F);
            lblUsernameError.ForeColor = Color.Firebrick;
            lblUsernameError.Name = "lblUsernameError";
            lblUsernameError.Size = new Size(492, 20);
            lblUsernameError.TabIndex = 7;
            lblUsernameError.TextAlign = ContentAlignment.MiddleLeft;

            labelPassword.AutoSize = false;
            labelPassword.Dock = DockStyle.Fill;
            labelPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(64, 64, 64);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(492, 30);
            labelPassword.TabIndex = 8;
            labelPassword.Text = "Password";
            labelPassword.TextAlign = ContentAlignment.MiddleLeft;

            txtPassword.BackColor = Color.Silver;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(42, 346);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = " Enter your password";
            txtPassword.Size = new Size(492, 44);
            txtPassword.TabIndex = 9;
            txtPassword.UseSystemPasswordChar = true;

            lblPasswordError.AutoSize = false;
            lblPasswordError.Dock = DockStyle.Fill;
            lblPasswordError.Font = new Font("Segoe UI", 9F);
            lblPasswordError.ForeColor = Color.Firebrick;
            lblPasswordError.Name = "lblPasswordError";
            lblPasswordError.Size = new Size(492, 20);
            lblPasswordError.TabIndex = 10;
            lblPasswordError.TextAlign = ContentAlignment.MiddleLeft;

            labelConfirmPassword.AutoSize = false;
            labelConfirmPassword.Dock = DockStyle.Fill;
            labelConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelConfirmPassword.ForeColor = Color.FromArgb(64, 64, 64);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(492, 30);
            labelConfirmPassword.TabIndex = 11;
            labelConfirmPassword.Text = "Confirm password";
            labelConfirmPassword.TextAlign = ContentAlignment.MiddleLeft;

            txtConfirmPassword.BackColor = Color.Silver;
            txtConfirmPassword.Dock = DockStyle.Fill;
            txtConfirmPassword.Font = new Font("Segoe UI", 12F);
            txtConfirmPassword.ForeColor = Color.Black;
            txtConfirmPassword.Location = new Point(42, 440);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = " Enter your password again";
            txtConfirmPassword.Size = new Size(492, 44);
            txtConfirmPassword.TabIndex = 12;
            txtConfirmPassword.UseSystemPasswordChar = true;

            lblConfirmPasswordError.AutoSize = false;
            lblConfirmPasswordError.Dock = DockStyle.Fill;
            lblConfirmPasswordError.Font = new Font("Segoe UI", 9F);
            lblConfirmPasswordError.ForeColor = Color.Firebrick;
            lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            lblConfirmPasswordError.Size = new Size(492, 20);
            lblConfirmPasswordError.TabIndex = 13;
            lblConfirmPasswordError.TextAlign = ContentAlignment.MiddleLeft;

            checkBox1.AutoSize = true;
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.Font = new Font("Segoe UI", 10F);
            checkBox1.ForeColor = Color.Gray;
            checkBox1.Location = new Point(45, 506);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(486, 32);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Show Password";
            checkBox1.TextAlign = ContentAlignment.MiddleLeft;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            btnRegister.BackColor = Color.FromArgb(7, 132, 59);
            btnRegister.Dock = DockStyle.Fill;
            btnRegister.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(42, 546);
            btnRegister.Margin = new Padding(0, 8, 0, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(492, 44);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "Register Now";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;

            footerLayout.ColumnCount = 2;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            footerLayout.Controls.Add(lblHaveAccount, 0, 0);
            footerLayout.Controls.Add(lnkGoToLogin, 1, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(0, 0);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(492, 30);
            footerLayout.TabIndex = 16;

            lblHaveAccount.AutoSize = false;
            lblHaveAccount.Dock = DockStyle.Fill;
            lblHaveAccount.Font = new Font("Segoe UI", 10F);
            lblHaveAccount.ForeColor = Color.FromArgb(64, 64, 64);
            lblHaveAccount.Name = "lblHaveAccount";
            lblHaveAccount.Size = new Size(422, 30);
            lblHaveAccount.TabIndex = 0;
            lblHaveAccount.Text = "Already have an account?";
            lblHaveAccount.TextAlign = ContentAlignment.MiddleLeft;

            lnkGoToLogin.AutoSize = false;
            lnkGoToLogin.Dock = DockStyle.Fill;
            lnkGoToLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lnkGoToLogin.ForeColor = Color.FromArgb(7, 132, 59);
            lnkGoToLogin.LinkColor = Color.FromArgb(7, 132, 59);
            lnkGoToLogin.Location = new Point(422, 0);
            lnkGoToLogin.Name = "lnkGoToLogin";
            lnkGoToLogin.Size = new Size(70, 30);
            lnkGoToLogin.TabIndex = 1;
            lnkGoToLogin.TabStop = true;
            lnkGoToLogin.Text = "Log in";
            lnkGoToLogin.TextAlign = ContentAlignment.MiddleLeft;
            lnkGoToLogin.LinkClicked += lnkGoToLogin_LinkClicked;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 820);
            Controls.Add(mainLayout);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Sizable;
            Margin = new Padding(5);
            MaximumSize = new Size(1600, 1000);
            MinimumSize = new Size(900, 720);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mart Management System - Register";
            mainLayout.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            formPanel.ResumeLayout(false);
            formContent.ResumeLayout(false);
            formContent.PerformLayout();
            footerLayout.ResumeLayout(false);
            footerLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
            Load += RegisterForm_Load;
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Panel imagePanel;
        private PictureBox pictureBox1;
        private Panel formPanel;
        private TableLayoutPanel formContent;
        private Label lbRegister;
        private Label lblSubtitle;
        private Label labelFullName;
        private TextBox txtFullName;
        private Label lblFullNameError;
        private Label labelUsername;
        private TextBox txtUsername;
        private Label lblUsernameError;
        private Label labelPassword;
        private TextBox txtPassword;
        private Label lblPasswordError;
        private Label labelConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPasswordError;
        private CheckBox checkBox1;
        private Button btnRegister;
        private TableLayoutPanel footerLayout;
        private Label lblHaveAccount;
        private LinkLabel lnkGoToLogin;
    }
}
