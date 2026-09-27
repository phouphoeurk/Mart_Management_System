namespace Mart_Management_System.Forms
{
    partial class StockAdjustmentForm
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
            lblProduct = new Label();
            lblCurrentStock = new Label();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblNotes = new Label();
            txtNotes = new TextBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 17, 17);
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Adjust Stock";

            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProduct.Location = new Point(25, 70);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(250, 20);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product:";

            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Font = new Font("Segoe UI", 10F);
            lblCurrentStock.ForeColor = Color.Gray;
            lblCurrentStock.Location = new Point(25, 105);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(140, 20);
            lblCurrentStock.TabIndex = 2;
            lblCurrentStock.Text = "Current stock:";

            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.Location = new Point(25, 145);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(140, 20);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Quantity change (+/-):";

            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(25, 170);
            numQuantity.Maximum = new decimal(2000000000, 0, 0, false, 0);
            numQuantity.Minimum = new decimal(2000000000, 0, 0, true, 0);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(130, 26);
            numQuantity.TabIndex = 4;
            numQuantity.Value = 1;

            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 10F);
            lblNotes.Location = new Point(25, 215);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(90, 20);
            lblNotes.TabIndex = 5;
            lblNotes.Text = "Notes (optional):";

            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(25, 240);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(390, 70);
            txtNotes.TabIndex = 6;

            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(25, 325);
            lblError.Name = "lblError";
            lblError.Size = new Size(390, 20);
            lblError.TabIndex = 7;

            btnSave.BackColor = Color.FromArgb(91, 174, 99);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(195, 365);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 36);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Adjustment";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(310, 365);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 36);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 241, 244);
            CancelButton = btnCancel;
            ClientSize = new Size(460, 440);
            Controls.Add(lblTitle);
            Controls.Add(lblProduct);
            Controls.Add(lblCurrentStock);
            Controls.Add(lblQuantity);
            Controls.Add(numQuantity);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockAdjustmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adjust Stock";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblProduct;
        private Label lblCurrentStock;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblNotes;
        private TextBox txtNotes;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
