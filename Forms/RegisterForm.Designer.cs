
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
            lbRegister = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            txtConfirmPassword = new TextBox();
            label3 = new Label();
            btnRegister = new Button();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbRegister
            // 
            lbRegister.AutoSize = true;
            lbRegister.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbRegister.ForeColor = Color.White;
            lbRegister.Location = new Point(224, 67);
            lbRegister.Margin = new Padding(5, 0, 5, 0);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(450, 89);
            lbRegister.TabIndex = 0;
            lbRegister.Text = "Sign Up Now";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(119, 276);
            label1.Name = "label1";
            label1.Size = new Size(459, 62);
            label1.TabIndex = 1;
            label1.Text = "Enter your username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(119, 358);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(733, 70);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(119, 553);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(733, 70);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(125, 479);
            label2.Name = "label2";
            label2.Size = new Size(453, 62);
            label2.TabIndex = 3;
            label2.Text = "Enter your password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(119, 720);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(733, 70);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(119, 655);
            label3.Name = "label3";
            label3.Size = new Size(404, 62);
            label3.TabIndex = 5;
            label3.Text = "Confirm password";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.SeaGreen;
            btnRegister.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRegister.ForeColor = SystemColors.HighlightText;
            btnRegister.Location = new Point(291, 977);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(365, 97);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register Now";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(7, 132, 59);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(lbRegister);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(958, 1170);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(466, 813);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(386, 66);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 1165);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "RegisterForm";
            Text = "AddEditForm";
            Load += AddEditForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Label lbRegister;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtConfirmPassword;
        private Label label3;
        private Button btnRegister;
        private Panel panel1;
        private CheckBox checkBox1;
    }
}