namespace Mart_Management_System.Forms
{
    partial class LoginForm
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
            loginPanel = new Panel();
            loginContent = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            cbShowPW = new CheckBox();
            btnLogin = new Button();
            label4 = new Label();
            registerLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainLayout.SuspendLayout();
            imagePanel.SuspendLayout();
            loginPanel.SuspendLayout();
            loginContent.SuspendLayout();
            SuspendLayout();

            mainLayout.BackColor = Color.White;
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            mainLayout.Controls.Add(imagePanel, 0, 0);
            mainLayout.Controls.Add(loginPanel, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Margin = new Padding(0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1200, 760);
            mainLayout.TabIndex = 0;

            imagePanel.BackColor = Color.FromArgb(238, 241, 244);
            imagePanel.Controls.Add(pictureBox1);
            imagePanel.Dock = DockStyle.Fill;
            imagePanel.Location = new Point(0, 0);
            imagePanel.Margin = new Padding(0);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(624, 760);
            imagePanel.TabIndex = 0;

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 760);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;

            loginPanel.BackColor = Color.White;
            loginPanel.Controls.Add(loginContent);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(624, 0);
            loginPanel.Margin = new Padding(0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(576, 760);
            loginPanel.TabIndex = 1;

            loginContent.ColumnCount = 1;
            loginContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loginContent.Controls.Add(label1, 0, 1);
            loginContent.Controls.Add(label2, 0, 2);
            loginContent.Controls.Add(txtUsername, 0, 3);
            loginContent.Controls.Add(label3, 0, 4);
            loginContent.Controls.Add(txtPassword, 0, 5);
            loginContent.Controls.Add(cbShowPW, 0, 6);
            loginContent.Controls.Add(btnLogin, 0, 7);
            loginContent.Controls.Add(label4, 0, 8);
            loginContent.Controls.Add(registerLink, 0, 9);
            loginContent.Dock = DockStyle.Fill;
            loginContent.Location = new Point(0, 0);
            loginContent.Margin = new Padding(0);
            loginContent.Name = "loginContent";
            loginContent.Padding = new Padding(42, 24, 42, 24);
            loginContent.RowCount = 11;
            loginContent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            loginContent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            loginContent.Size = new Size(576, 760);
            loginContent.TabIndex = 0;

            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(7, 132, 59);
            label1.Name = "label1";
            label1.Size = new Size(492, 60);
            label1.TabIndex = 0;
            label1.Text = "Welcome Back";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Name = "label2";
            label2.Size = new Size(492, 32);
            label2.TabIndex = 1;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.MiddleLeft;

            txtUsername.BackColor = Color.Silver;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(42, 158);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = " Enter your username";
            txtUsername.Size = new Size(492, 50);
            txtUsername.TabIndex = 2;

            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Name = "label3";
            label3.Size = new Size(492, 32);
            label3.TabIndex = 3;
            label3.Text = "Password";
            label3.TextAlign = ContentAlignment.MiddleLeft;

            txtPassword.BackColor = Color.Silver;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(42, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = " Enter your password";
            txtPassword.Size = new Size(492, 50);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;

            cbShowPW.AutoSize = true;
            cbShowPW.Dock = DockStyle.Fill;
            cbShowPW.Font = new Font("Segoe UI", 10F);
            cbShowPW.ForeColor = Color.Gray;
            cbShowPW.Location = new Point(45, 292);
            cbShowPW.Name = "cbShowPW";
            cbShowPW.Size = new Size(486, 34);
            cbShowPW.TabIndex = 5;
            cbShowPW.Text = "Show Password";
            cbShowPW.TextAlign = ContentAlignment.MiddleLeft;
            cbShowPW.UseVisualStyleBackColor = true;
            cbShowPW.CheckedChanged += cbShowPW_CheckedChanged;

            btnLogin.BackColor = Color.FromArgb(7, 132, 59);
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(42, 334);
            btnLogin.Margin = new Padding(0, 8, 0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(492, 48);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            label4.AutoSize = false;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Name = "label4";
            label4.Size = new Size(492, 22);
            label4.TabIndex = 7;
            label4.Text = "New accounts need admin approval before signing in.";
            label4.TextAlign = ContentAlignment.MiddleCenter;

            registerLink.AutoSize = false;
            registerLink.Dock = DockStyle.Fill;
            registerLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            registerLink.ForeColor = Color.FromArgb(7, 132, 59);
            registerLink.LinkColor = Color.FromArgb(7, 132, 59);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(492, 28);
            registerLink.TabIndex = 8;
            registerLink.TabStop = true;
            registerLink.Text = "Register here";
            registerLink.TextAlign = ContentAlignment.MiddleCenter;
            registerLink.LinkClicked += registerLink_LinkClicked;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 760);
            Controls.Add(mainLayout);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Sizable;
            Margin = new Padding(5);
            MaximumSize = new Size(1600, 1000);
            MinimumSize = new Size(900, 600);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mart Management System - Login";
            mainLayout.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            loginPanel.ResumeLayout(false);
            loginContent.ResumeLayout(false);
            loginContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
            Load += LoginForm_Load;
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Panel imagePanel;
        private PictureBox pictureBox1;
        private Panel loginPanel;
        private TableLayoutPanel loginContent;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private Label label3;
        private TextBox txtPassword;
        private CheckBox cbShowPW;
        private Button btnLogin;
        private Label label4;
        private LinkLabel registerLink;
    }
}
