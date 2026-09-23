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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            textBox2 = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(7, 132, 59);
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1078, 809);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(338, 99);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(7, 132, 59);
            label1.Location = new Point(1089, 76);
            label1.Name = "label1";
            label1.Size = new Size(620, 112);
            label1.TabIndex = 2;
            label1.Text = "Welcome Back";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1078, 365);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(727, 70);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(1078, 287);
            label2.Name = "label2";
            label2.Size = new Size(270, 72);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Gray;
            checkBox1.Location = new Point(1419, 713);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(386, 66);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(1182, 1079);
            label4.Name = "label4";
            label4.Size = new Size(541, 62);
            label4.TabIndex = 8;
            label4.Text = "Don't have any account?";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            linkLabel1.LinkColor = Color.FromArgb(7, 132, 59);
            linkLabel1.Location = new Point(1302, 1165);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(317, 62);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Register here";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1078, 600);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(727, 70);
            textBox2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(1078, 522);
            label3.Name = "label3";
            label3.Size = new Size(253, 72);
            label3.TabIndex = 11;
            label3.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._937e9d6e_3296_4b5c_bdd5_be5d8b4dada0;
            pictureBox1.Location = new Point(1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(985, 1265);
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
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(checkBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label4;
        private LinkLabel linkLabel1;
        private TextBox textBox2;
        private Label label3;
        private PictureBox pictureBox1;
    }
}