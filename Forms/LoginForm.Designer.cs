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
            btnLogin = new Button();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            cbShowPW = new CheckBox();
            label4 = new Label();
            registerLink = new LinkLabel();
            txtPassword = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(7, 132, 59);
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1104, 805);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(338, 99);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(7, 132, 59);
            label1.Location = new Point(1131, 65);
            label1.Name = "label1";
            label1.Size = new Size(620, 112);
            label1.TabIndex = 2;
            label1.Text = "Welcome Back";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(1104, 356);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(727, 70);
            txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(7, 132, 59);
            label2.Location = new Point(1104, 278);
            label2.Name = "label2";
            label2.Size = new Size(283, 72);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // cbShowPW
            // 
            cbShowPW.AutoSize = true;
            cbShowPW.ForeColor = Color.FromArgb(7, 132, 59);
            cbShowPW.Location = new Point(1445, 704);
            cbShowPW.Name = "cbShowPW";
            cbShowPW.Size = new Size(386, 66);
            cbShowPW.TabIndex = 7;
            cbShowPW.Text = "Show Password";
            cbShowPW.UseVisualStyleBackColor = true;
            cbShowPW.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(1210, 1100);
            label4.Name = "label4";
            label4.Size = new Size(541, 62);
            label4.TabIndex = 8;
            label4.Text = "Don't have any account?";
            // 
            // registerLink
            // 
            registerLink.AutoSize = true;
            registerLink.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            registerLink.LinkColor = Color.FromArgb(7, 132, 59);
            registerLink.Location = new Point(1330, 1186);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(317, 62);
            registerLink.TabIndex = 9;
            registerLink.TabStop = true;
            registerLink.Text = "Register here";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(1104, 591);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(727, 70);
            txtPassword.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(7, 132, 59);
            label3.Location = new Point(1104, 513);
            label3.Name = "label3";
            label3.Size = new Size(269, 72);
            label3.TabIndex = 11;
            label3.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(-1, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1052, 1257);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1867, 1275);
            Controls.Add(pictureBox1);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(registerLink);
            Controls.Add(label4);
            Controls.Add(cbShowPW);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private CheckBox cbShowPW;
        private Label label4;
        private LinkLabel registerLink;
        private TextBox txtPassword;
        private Label label3;
        private PictureBox pictureBox1;
    }
}