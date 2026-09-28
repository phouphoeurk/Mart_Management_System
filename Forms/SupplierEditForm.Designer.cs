namespace Mart_Management_System.Forms
{
    partial class SupplierEditForm
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
            lblSupplierName = new Label();
            txtSupplierName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            chkActive = new CheckBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Supplier";

            lblSupplierName.AutoSize = true;
            lblSupplierName.Font = new Font("Segoe UI", 10F);
            lblSupplierName.Location = new Point(25, 75);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(100, 20);
            lblSupplierName.TabIndex = 1;
            lblSupplierName.Text = "Supplier name:";

            txtSupplierName.Font = new Font("Segoe UI", 10F);
            txtSupplierName.Location = new Point(25, 100);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(420, 28);
            txtSupplierName.TabIndex = 2;

            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.Location = new Point(25, 145);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone:";

            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(150, 142);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(295, 28);
            txtPhone.TabIndex = 4;

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(25, 185);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 20);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";

            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(150, 182);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(295, 28);
            txtEmail.TabIndex = 6;

            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.Location = new Point(25, 225);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 20);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Address:";

            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(25, 250);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new Size(420, 75);
            txtAddress.TabIndex = 8;

            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(25, 345);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(120, 25);
            chkActive.TabIndex = 9;
            chkActive.Text = "Active supplier";

            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(25, 380);
            lblError.Name = "lblError";
            lblError.Size = new Size(420, 20);
            lblError.TabIndex = 10;

            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(230, 420);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 36);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save Supplier";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(350, 420);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 36);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(480, 480);
            Controls.Add(lblTitle);
            Controls.Add(lblSupplierName);
            Controls.Add(txtSupplierName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(chkActive);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SupplierEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Supplier";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSupplierName;
        private TextBox txtSupplierName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private CheckBox chkActive;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
