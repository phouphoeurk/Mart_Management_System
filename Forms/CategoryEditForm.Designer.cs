namespace Mart_Management_System.Forms
{
    partial class CategoryEditForm
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
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
            lblTitle.Size = new Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Category";

            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 10F);
            lblCategoryName.Location = new Point(25, 75);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(100, 20);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Category name:";

            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.Location = new Point(25, 100);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(390, 28);
            txtCategoryName.TabIndex = 2;

            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(25, 145);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(80, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description:";

            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(25, 170);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(390, 80);
            txtDescription.TabIndex = 4;

            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(25, 270);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(110, 25);
            chkActive.TabIndex = 5;
            chkActive.Text = "Active category";

            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(25, 305);
            lblError.Name = "lblError";
            lblError.Size = new Size(390, 20);
            lblError.TabIndex = 6;

            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(190, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 36);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save Category";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(310, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 36);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(450, 400);
            Controls.Add(lblTitle);
            Controls.Add(lblCategoryName);
            Controls.Add(txtCategoryName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(chkActive);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoryEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;
        private CheckBox chkActive;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
