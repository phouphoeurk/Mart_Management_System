namespace Mart_Management_System.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cardsPanel = new System.Windows.Forms.Panel();
            this.card1 = new System.Windows.Forms.Panel();
            this.lblCard1Value = new System.Windows.Forms.Label();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.card2 = new System.Windows.Forms.Panel();
            this.lblCard2Value = new System.Windows.Forms.Label();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.card3 = new System.Windows.Forms.Panel();
            this.lblCard3Value = new System.Windows.Forms.Label();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.card4 = new System.Windows.Forms.Panel();
            this.lblCard4Value = new System.Windows.Forms.Label();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.chartsPanel = new System.Windows.Forms.Panel();
            this.chart1Panel = new System.Windows.Forms.Panel();
            this.lblChart1Placeholder = new System.Windows.Forms.Label();
            this.chart2Panel = new System.Windows.Forms.Panel();
            this.lblChart2Placeholder = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.cardsPanel.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.chartsPanel.SuspendLayout();
            this.chart1Panel.SuspendLayout();
            this.chart2Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(20, 20);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1060, 50);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(117, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "REPORTS";
            // 
            // cardsPanel
            // 
            this.cardsPanel.Controls.Add(this.card4);
            this.cardsPanel.Controls.Add(this.card3);
            this.cardsPanel.Controls.Add(this.card2);
            this.cardsPanel.Controls.Add(this.card1);
            this.cardsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardsPanel.Location = new System.Drawing.Point(20, 70);
            this.cardsPanel.Name = "cardsPanel";
            this.cardsPanel.Size = new System.Drawing.Size(1060, 130);
            this.cardsPanel.TabIndex = 1;
            // 
            // card1 (Daily Sales)
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.Controls.Add(this.lblCard1Value);
            this.card1.Controls.Add(this.lblCard1Title);
            this.card1.Location = new System.Drawing.Point(0, 15);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(240, 100);
            this.card1.TabIndex = 0;
            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCard1Title.ForeColor = System.Drawing.Color.Gray;
            this.lblCard1Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard1Title.Text = "Daily Sales";
            this.lblCard1Value.AutoSize = true;
            this.lblCard1Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCard1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(174)))), ((int)(((byte)(99)))));
            this.lblCard1Value.Location = new System.Drawing.Point(15, 45);
            this.lblCard1Value.Text = "$ 450.00";
            // 
            // card2 (Weekly Sales)
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.Controls.Add(this.lblCard2Value);
            this.card2.Controls.Add(this.lblCard2Title);
            this.card2.Location = new System.Drawing.Point(260, 15);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(240, 100);
            this.card2.TabIndex = 1;
            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCard2Title.ForeColor = System.Drawing.Color.Gray;
            this.lblCard2Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard2Title.Text = "Weekly Sales";
            this.lblCard2Value.AutoSize = true;
            this.lblCard2Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCard2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(174)))), ((int)(((byte)(99)))));
            this.lblCard2Value.Location = new System.Drawing.Point(15, 45);
            this.lblCard2Value.Text = "$ 2,840.50";
            // 
            // card3 (Monthly Sales)
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.Controls.Add(this.lblCard3Value);
            this.card3.Controls.Add(this.lblCard3Title);
            this.card3.Location = new System.Drawing.Point(520, 15);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(240, 100);
            this.card3.TabIndex = 2;
            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCard3Title.ForeColor = System.Drawing.Color.Gray;
            this.lblCard3Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard3Title.Text = "Monthly Sales";
            this.lblCard3Value.AutoSize = true;
            this.lblCard3Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCard3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(174)))), ((int)(((byte)(99)))));
            this.lblCard3Value.Location = new System.Drawing.Point(15, 45);
            this.lblCard3Value.Text = "$ 12,500.00";
            // 
            // card4 (Total Revenue)
            // 
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.Controls.Add(this.lblCard4Value);
            this.card4.Controls.Add(this.lblCard4Title);
            this.card4.Location = new System.Drawing.Point(780, 15);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(260, 100);
            this.card4.TabIndex = 3;
            this.lblCard4Title.AutoSize = true;
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCard4Title.ForeColor = System.Drawing.Color.Gray;
            this.lblCard4Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard4Title.Text = "Total Revenue";
            this.lblCard4Value.AutoSize = true;
            this.lblCard4Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCard4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lblCard4Value.Location = new System.Drawing.Point(15, 45);
            this.lblCard4Value.Text = "$ 145,000.00";
            // 
            // chartsPanel
            // 
            this.chartsPanel.Controls.Add(this.chart2Panel);
            this.chartsPanel.Controls.Add(this.chart1Panel);
            this.chartsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartsPanel.Location = new System.Drawing.Point(20, 200);
            this.chartsPanel.Name = "chartsPanel";
            this.chartsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.chartsPanel.Size = new System.Drawing.Size(1060, 480);
            this.chartsPanel.TabIndex = 2;
            // 
            // chart1Panel (Placeholder for Line Chart)
            // 
            this.chart1Panel.BackColor = System.Drawing.Color.White;
            this.chart1Panel.Controls.Add(this.lblChart1Placeholder);
            this.chart1Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.chart1Panel.Location = new System.Drawing.Point(0, 10);
            this.chart1Panel.Name = "chart1Panel";
            this.chart1Panel.Size = new System.Drawing.Size(600, 470);
            this.chart1Panel.TabIndex = 0;
            this.lblChart1Placeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart1Placeholder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChart1Placeholder.ForeColor = System.Drawing.Color.Gray;
            this.lblChart1Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChart1Placeholder.Text = "📈 Sales Trend Chart\n(UI Placeholder)";
            // 
            // chart2Panel (Placeholder for Pie Chart)
            // 
            this.chart2Panel.BackColor = System.Drawing.Color.White;
            this.chart2Panel.Controls.Add(this.lblChart2Placeholder);
            this.chart2Panel.Location = new System.Drawing.Point(620, 10);
            this.chart2Panel.Name = "chart2Panel";
            this.chart2Panel.Size = new System.Drawing.Size(420, 470);
            this.chart2Panel.TabIndex = 1;
            this.lblChart2Placeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart2Placeholder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChart2Placeholder.ForeColor = System.Drawing.Color.Gray;
            this.lblChart2Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChart2Placeholder.Text = "🥧 Top Products by Category\n(UI Placeholder)";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.chartsPanel);
            this.Controls.Add(this.cardsPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "ReportsForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "ReportsForm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.cardsPanel.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.chartsPanel.ResumeLayout(false);
            this.chart1Panel.ResumeLayout(false);
            this.chart2Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardsPanel;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCard1Value;
        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Value;
        private System.Windows.Forms.Panel card3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblCard3Value;
        private System.Windows.Forms.Panel card4;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblCard4Value;
        private System.Windows.Forms.Panel chartsPanel;
        private System.Windows.Forms.Panel chart1Panel;
        private System.Windows.Forms.Label lblChart1Placeholder;
        private System.Windows.Forms.Panel chart2Panel;
        private System.Windows.Forms.Label lblChart2Placeholder;
    }
}