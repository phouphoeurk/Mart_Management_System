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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            lbRegister = new Label();
            label1 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            lblUsernameError = new Label();
            lblPasswordError = new Label();
            lblConfirmPasswordError = new Label();
            lnkGoToLogin = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(lbRegister);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblUsernameError);
            panel1.Controls.Add(lblPasswordError);
            panel1.Controls.Add(lblConfirmPasswordError);
            panel1.Controls.Add(lnkGoToLogin);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(2064, 1337);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1043, 1309);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(1352, 1050);
            label4.Name = "label4";
            label4.Size = new Size(473, 54);
            label4.TabIndex = 27;
            label4.Text = "Already have an account?";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10F);
            checkBox1.ForeColor = Color.FromArgb(55, 55, 55);
            checkBox1.Location = new Point(1263, 748);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(289, 50);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtConfirmPassword.BackColor = Color.FromArgb(224, 224, 224);
            txtConfirmPassword.Font = new Font("Segoe UI", 12F);
            txtConfirmPassword.Location = new Point(1263, 659);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "  Enter confirm password";
            txtConfirmPassword.Size = new Size(617, 61);
            txtConfirmPassword.TabIndex = 20;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(7, 132, 59);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(1352, 886);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(429, 75);
            btnRegister.TabIndex = 21;
            btnRegister.Text = "Register Now";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // lbRegister
            // 
            lbRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRegister.AutoSize = true;
            lbRegister.BackColor = Color.FromArgb(7, 132, 59);
            lbRegister.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbRegister.ForeColor = Color.White;
            lbRegister.Location = new Point(1366, 61);
            lbRegister.Margin = new Padding(5, 0, 5, 0);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(450, 89);
            lbRegister.TabIndex = 14;
            lbRegister.Text = "Sign Up Now";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(55, 55, 55);
            label1.Location = new Point(1263, 243);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(415, 54);
            label1.TabIndex = 15;
            label1.Text = "Enter your username";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(55, 55, 55);
            label3.Location = new Point(1263, 586);
            label3.Name = "label3";
            label3.Size = new Size(366, 54);
            label3.TabIndex = 19;
            label3.Text = "Confirm password";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUsername.BackColor = Color.FromArgb(224, 224, 224);
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(1263, 314);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "  Enter your username";
            txtUsername.Size = new Size(617, 61);
            txtUsername.TabIndex = 16;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(224, 224, 224);
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(1263, 479);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "  Enter your password";
            txtPassword.Size = new Size(617, 61);
            txtPassword.TabIndex = 18;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(55, 55, 55);
            label2.Location = new Point(1263, 407);
            label2.Name = "label2";
            label2.Size = new Size(410, 54);
            label2.TabIndex = 17;
            label2.Text = "Enter your password";
            // 
            // lblUsernameError
            // 
            lblUsernameError.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsernameError.Font = new Font("Segoe UI", 9F);
            lblUsernameError.ForeColor = Color.Firebrick;
            lblUsernameError.Location = new Point(1318, 373);
            lblUsernameError.Name = "lblUsernameError";
            lblUsernameError.Size = new Size(480, 10);
            lblUsernameError.TabIndex = 23;
            // 
            // lblPasswordError
            // 
            lblPasswordError.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPasswordError.Font = new Font("Segoe UI", 9F);
            lblPasswordError.ForeColor = Color.Firebrick;
            lblPasswordError.Location = new Point(1318, 524);
            lblPasswordError.Name = "lblPasswordError";
            lblPasswordError.Size = new Size(480, 10);
            lblPasswordError.TabIndex = 24;
            // 
            // lblConfirmPasswordError
            // 
            lblConfirmPasswordError.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblConfirmPasswordError.Font = new Font("Segoe UI", 9F);
            lblConfirmPasswordError.ForeColor = Color.Firebrick;
            lblConfirmPasswordError.Location = new Point(1318, 669);
            lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            lblConfirmPasswordError.Size = new Size(480, 10);
            lblConfirmPasswordError.TabIndex = 25;
            // 
            // lnkGoToLogin
            // 
            lnkGoToLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lnkGoToLogin.AutoSize = true;
            lnkGoToLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lnkGoToLogin.ForeColor = Color.FromArgb(91, 174, 99);
            lnkGoToLogin.LinkColor = Color.FromArgb(7, 132, 59);
            lnkGoToLogin.Location = new Point(1550, 1116);
            lnkGoToLogin.Name = "lnkGoToLogin";
            lnkGoToLogin.Size = new Size(138, 54);
            lnkGoToLogin.TabIndex = 26;
            lnkGoToLogin.TabStop = true;
            lnkGoToLogin.Text = "Log in";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            ClientSize = new Size(2087, 1399);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEditForm";
            Load += AddEditForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private CheckBox checkBox1;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Label lbRegister;
        private Label label1;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private Label lblUsernameError;
        private Label lblPasswordError;
        private Label lblConfirmPasswordError;
        private LinkLabel lnkGoToLogin;
    }
}
