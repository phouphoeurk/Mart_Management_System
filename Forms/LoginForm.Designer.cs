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
<<<<<<< HEAD
            pictureBox1 = new PictureBox();
=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            btnLogin = new Button();
<<<<<<< HEAD
            cbSP = new CheckBox();
=======
            pictureBox1 = new PictureBox();
            label3 = new Label();
            cbShowPW = new CheckBox();
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            label4 = new Label();
            registerLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(1, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1072, 1322);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
<<<<<<< HEAD
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(7, 132, 59);
            label1.Location = new Point(1245, 85);
            label1.Name = "label1";
            label1.Size = new Size(494, 89);
            label1.TabIndex = 1;
            label1.Text = "Welcome Back";
=======
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(1248, 315);
            label1.Name = "label1";
            label1.Size = new Size(270, 72);
            label1.TabIndex = 0;
            label1.Text = "Username";
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            // 
            // label2
            // 
            label2.AutoSize = true;
<<<<<<< HEAD
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(1147, 279);
            label2.Name = "label2";
            label2.Size = new Size(247, 62);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(1147, 361);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(725, 70);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(1147, 566);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(725, 70);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += this.textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(1147, 484);
            label3.Name = "label3";
            label3.Size = new Size(236, 62);
            label3.TabIndex = 4;
            label3.Text = "Password";
            label3.Click += this.label3_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(7, 132, 59);
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.Location = new Point(1160, 783);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(323, 119);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // cbSP
            // 
            cbSP.AutoSize = true;
            cbSP.ForeColor = Color.Gray;
            cbSP.Location = new Point(1496, 676);
            cbSP.Name = "cbSP";
            cbSP.Size = new Size(386, 66);
            cbSP.TabIndex = 7;
            cbSP.Text = "Show Password";
            cbSP.UseVisualStyleBackColor = true;
=======
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(1248, 571);
            label2.Name = "label2";
            label2.Size = new Size(253, 72);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(224, 224, 224);
            txtUsername.Font = new Font("Segoe UI", 16F);
            txtUsername.Location = new Point(1248, 410);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(648, 78);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(224, 224, 224);
            txtPassword.Font = new Font("Segoe UI", 16F);
            txtPassword.Location = new Point(1248, 666);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(648, 78);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(8, 132, 59);
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Location = new Point(1240, 884);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(269, 100);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1066, 1228);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.Location = new Point(1240, 143);
            label3.Name = "label3";
            label3.Size = new Size(295, 72);
            label3.TabIndex = 6;
            label3.Text = "Get Stated";
            // 
            // cbShowPW
            // 
            cbShowPW.AutoSize = true;
            cbShowPW.BackColor = SystemColors.Window;
            cbShowPW.Font = new Font("Segoe UI", 10F);
            cbShowPW.ForeColor = Color.Gray;
            cbShowPW.Location = new Point(1607, 776);
            cbShowPW.Name = "cbShowPW";
            cbShowPW.Size = new Size(289, 50);
            cbShowPW.TabIndex = 7;
            cbShowPW.Text = "Show Password";
            cbShowPW.UseVisualStyleBackColor = false;
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            // 
            // label4
            // 
            label4.AutoSize = true;
<<<<<<< HEAD
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(1269, 1054);
            label4.Name = "label4";
            label4.Size = new Size(482, 54);
            label4.TabIndex = 8;
            label4.Text = "Don't have any account?";
=======
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(1248, 1118);
            label4.Name = "label4";
            label4.Size = new Size(370, 46);
            label4.TabIndex = 8;
            label4.Text = "Don't have an account?";
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            // 
            // registerLink
            // 
            registerLink.AutoSize = true;
<<<<<<< HEAD
            registerLink.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            registerLink.LinkColor = Color.FromArgb(7, 132, 59);
            registerLink.Location = new Point(1356, 1147);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(335, 62);
            registerLink.TabIndex = 9;
            registerLink.TabStop = true;
            registerLink.Text = "Registter here";
=======
            registerLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            registerLink.Location = new Point(1624, 1121);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(229, 46);
            registerLink.TabIndex = 9;
            registerLink.TabStop = true;
            registerLink.Text = "Register here";
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            ClientSize = new Size(1953, 1325);
            Controls.Add(registerLink);
            Controls.Add(label4);
            Controls.Add(cbSP);
=======
            BackColor = Color.White;
            ClientSize = new Size(1973, 1232);
            Controls.Add(registerLink);
            Controls.Add(label4);
            Controls.Add(cbShowPW);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
<<<<<<< HEAD
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 14F);
            ForeColor = Color.White;
            Margin = new Padding(5, 5, 5, 5);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
=======
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "LoginForm";
            Text = "Form1";
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label3;
        private Button btnLogin;
<<<<<<< HEAD
        private CheckBox cbSP;
=======
        private PictureBox pictureBox1;
        private Label label3;
        private CheckBox cbShowPW;
>>>>>>> aed474c02a11dd74e298d2967c844c8136498406
        private Label label4;
        private LinkLabel registerLink;
    }
}