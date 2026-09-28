using Mart_Management_System.Models;

namespace Mart_Management_System.Forms
{
    public partial class SaleDetailsForm : Form
    {
        public SaleDetailsForm()
            : this(new Sale())
        {
        }

        public SaleDetailsForm(Sale sale)
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);

            lblSaleId.Text = $"Sale ID: {sale.SaleId}";
            lblCashier.Text = $"Cashier: {sale.CashierName}";
            lblDate.Text = $"Date: {sale.SaleDate:yyyy-MM-dd HH:mm}";
            lblPayment.Text = $"Payment: {sale.PaymentMethod}";
            lblStatus.Text = $"Status: {sale.Status}";
            lblTotal.Text = $"Total: {sale.TotalAmount:C2}";

            foreach (SaleDetail detail in sale.SaleDetails)
            {
                dgvDetails.Rows.Add(
                    detail.ProductName,
                    detail.Quantity,
                    detail.UnitPrice.ToString("C2"),
                    detail.DiscountAmount.ToString("C2"),
                    detail.LineSubtotal.ToString("C2")
                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
