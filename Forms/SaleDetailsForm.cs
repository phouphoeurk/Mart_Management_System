using Mart_Management_System.Models;
using Mart_Management_System.Services;

namespace Mart_Management_System.Forms
{
    public partial class SaleDetailsForm : Form
    {
        private readonly Sale _sale;

        public SaleDetailsForm()
            : this(new Sale())
        {
        }

        public SaleDetailsForm(Sale sale)
        {
            InitializeComponent();
            Mart_Management_System.UI.UiTheme.Apply(this);
            _sale = sale;

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

        private void btnReprint_Click(object sender, EventArgs e)
        {
            ReceiptData receipt = new()
            {
                ShopName = ReceiptPrinter.ShopName,
                Title = "PAYMENT RECEIPT",
                SaleId = _sale.SaleId,
                Date = _sale.SaleDate,
                CashierName = string.IsNullOrWhiteSpace(_sale.CashierName)
                    ? "-"
                    : _sale.CashierName,
                Items = _sale.SaleDetails
                    .Select(detail => new ReceiptLineItem(
                        detail.ProductName,
                        detail.Quantity,
                        detail.UnitPrice,
                        detail.LineSubtotal
                    ))
                    .ToList(),
                Subtotal = _sale.Subtotal,
                Discount = _sale.DiscountAmount,
                Total = _sale.TotalAmount,
                PaymentMethod = _sale.PaymentMethod.ToString(),
                AmountReceived = _sale.AmountReceived,
                ChangeAmount = _sale.ChangeAmount,
                Footer = "Thank you"
            };

            try
            {
                ReceiptPrinter.Print(receipt, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to print the receipt. {ex.Message}",
                    "Sale Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
