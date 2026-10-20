using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Mart_Management_System.Services
{
    public enum ReceiptPaperSize
    {
        Thermal80,
        A5,
        A4
    }

    public sealed class ReceiptLineItem
    {
        public ReceiptLineItem(
            string productName,
            int quantity,
            decimal unitPrice,
            decimal lineSubtotal
        )
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            LineSubtotal = lineSubtotal;
        }

        public string ProductName { get; }

        public int Quantity { get; }

        public decimal UnitPrice { get; }

        public decimal LineSubtotal { get; }
    }

    public sealed class ReceiptData
    {
        public string ShopName { get; init; } = ReceiptPrinter.DefaultShopName;

        public string Title { get; init; } = "PAYMENT RECEIPT";

        public string? Subtitle { get; init; }

        public int? SaleId { get; init; }

        public DateTime Date { get; init; } = DateTime.Now;

        public string CashierName { get; init; } = string.Empty;

        public IReadOnlyList<ReceiptLineItem> Items { get; init; } =
            Array.Empty<ReceiptLineItem>();

        public decimal Subtotal { get; init; }

        public decimal Discount { get; init; }

        public decimal Total { get; init; }

        public string? PaymentMethod { get; init; }

        public decimal? AmountReceived { get; init; }

        public decimal? ChangeAmount { get; init; }

        public string Footer { get; init; } = string.Empty;
    }

    public static class ReceiptPrinter
    {
        public const string DefaultShopName = "Smart Mart";

        public static string ShopName { get; } = ReadShopName();

        public static string FormatMoney(decimal value)
        {
            return "$" + value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public static void Print(
            ReceiptData data,
            IWin32Window? owner,
            ReceiptPaperSize paperSize = ReceiptPaperSize.Thermal80
        )
        {
            ArgumentNullException.ThrowIfNull(data);

            using ReceiptPrintJob job = new(data, paperSize);
            using PrintPreviewDialog preview = new()
            {
                Document = job.Document,
                Width = 1000,
                Height = 750,
                StartPosition = FormStartPosition.CenterParent,
                HelpButton = false
            };
            preview.ShowDialog(owner);
        }

        private static string ReadShopName()
        {
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile("appsettings.Development.json", optional: true)
                    .Build();

                string? shopName = configuration["ShopName"];
                return string.IsNullOrWhiteSpace(shopName)
                    ? DefaultShopName
                    : shopName.Trim();
            }
            catch (Exception)
            {
                return DefaultShopName;
            }
        }

        private sealed class ReceiptPrintJob : IDisposable
        {
            private const int MaxNameLines = 3;

            private readonly ReceiptData _data;
            private readonly bool _isThermal;
            private readonly Font _titleFont;
            private readonly Font _subtitleFont;
            private readonly Font _bodyFont;
            private readonly Font _bodyBoldFont;
            private readonly Font _totalFont;
            private int _itemIndex;
            private bool _firstPage = true;

            public ReceiptPrintJob(ReceiptData data, ReceiptPaperSize paperSize)
            {
                _data = data;
                _isThermal = paperSize == ReceiptPaperSize.Thermal80;

                string fontFamily = _isThermal ? "Courier New" : "Segoe UI";
                _titleFont = new Font(fontFamily, 12F, FontStyle.Bold);
                _subtitleFont = new Font(fontFamily, 10F, FontStyle.Bold);
                _bodyFont = new Font(fontFamily, 9F);
                _bodyBoldFont = new Font(fontFamily, 9F, FontStyle.Bold);
                _totalFont = new Font(fontFamily, 11F, FontStyle.Bold);

                Document = new PrintDocument
                {
                    DocumentName = $"{data.Title} - {data.ShopName}"
                };
                Document.DefaultPageSettings.PaperSize =
                    CreatePaperSize(paperSize);
                Document.DefaultPageSettings.Margins =
                    CreateMargins(paperSize);
                Document.PrintPage += Document_PrintPage;
            }

            public PrintDocument Document { get; }

            public void Dispose()
            {
                Document.PrintPage -= Document_PrintPage;
                Document.Dispose();
                _titleFont.Dispose();
                _subtitleFont.Dispose();
                _bodyFont.Dispose();
                _bodyBoldFont.Dispose();
                _totalFont.Dispose();
            }

            private static PaperSize CreatePaperSize(ReceiptPaperSize paperSize)
            {
                return paperSize switch
                {
                    ReceiptPaperSize.A5 => new PaperSize("A5", 583, 827),
                    ReceiptPaperSize.A4 => new PaperSize("A4", 827, 1169),
                    _ => new PaperSize("Thermal 80mm", 315, 500)
                };
            }

            private static Margins CreateMargins(ReceiptPaperSize paperSize)
            {
                return paperSize == ReceiptPaperSize.Thermal80
                    ? new Margins(15, 15, 15, 15)
                    : new Margins(50, 50, 50, 50);
            }

            private void Document_PrintPage(
                object? sender,
                PrintPageEventArgs e
            )
            {
                if (e.Graphics is not Graphics graphics)
                {
                    e.HasMorePages = false;
                    return;
                }
                float left = e.MarginBounds.Left;
                float width = e.MarginBounds.Width;
                float bottom = e.MarginBounds.Bottom;
                float y = e.MarginBounds.Top;
                float lineHeight = _bodyFont.GetHeight(graphics);
                float moneyColumnWidth =
                    graphics.MeasureString("$999999.99", _bodyBoldFont).Width
                    + 8;

                if (_firstPage)
                {
                    DrawCentered(
                        graphics,
                        _data.ShopName,
                        _titleFont,
                        left,
                        width,
                        ref y
                    );
                    DrawCentered(
                        graphics,
                        _data.Title,
                        _subtitleFont,
                        left,
                        width,
                        ref y
                    );
                    if (!string.IsNullOrWhiteSpace(_data.Subtitle))
                    {
                        DrawCentered(
                            graphics,
                            _data.Subtitle!,
                            _subtitleFont,
                            left,
                            width,
                            ref y
                        );
                    }

                    y += lineHeight * 0.4f;
                    DrawLeft(
                        graphics,
                        $"Date: {_data.Date:yyyy-MM-dd HH:mm}",
                        _bodyFont,
                        left,
                        width,
                        ref y
                    );
                    DrawLeft(
                        graphics,
                        $"Cashier: {_data.CashierName}",
                        _bodyFont,
                        left,
                        width,
                        ref y
                    );
                    if (_data.SaleId.HasValue)
                    {
                        DrawLeft(
                            graphics,
                            $"Sale ID: {_data.SaleId.Value}",
                            _bodyFont,
                            left,
                            width,
                            ref y
                        );
                    }

                    y += lineHeight * 0.3f;
                    DrawRule(graphics, left, width, y);
                    y += lineHeight * 0.5f;
                }
                else
                {
                    DrawCentered(
                        graphics,
                        "(continued)",
                        _bodyFont,
                        left,
                        width,
                        ref y
                    );
                    y += lineHeight * 0.3f;
                    DrawRule(graphics, left, width, y);
                    y += lineHeight * 0.5f;
                }

                while (_itemIndex < _data.Items.Count)
                {
                    ReceiptLineItem item = _data.Items[_itemIndex];
                    List<string> nameLines = WrapText(
                        graphics,
                        item.ProductName,
                        _bodyFont,
                        width - moneyColumnWidth,
                        MaxNameLines
                    );
                    float blockHeight =
                        (nameLines.Count + 1) * lineHeight + lineHeight * 0.4f;
                    if (y + blockHeight > bottom)
                    {
                        e.HasMorePages = true;
                        _firstPage = false;
                        return;
                    }

                    foreach (string nameLine in nameLines)
                    {
                        DrawLeft(
                            graphics,
                            nameLine,
                            _bodyFont,
                            left,
                            width - moneyColumnWidth,
                            ref y
                        );
                    }

                    DrawPair(
                        graphics,
                        $"  {item.Quantity} x {FormatMoney(item.UnitPrice)}",
                        FormatMoney(item.LineSubtotal),
                        left,
                        width,
                        ref y
                    );
                    y += lineHeight * 0.4f;
                    _itemIndex++;
                }

                if (_itemIndex == 0)
                {
                    DrawLeft(
                        graphics,
                        "(no items)",
                        _bodyFont,
                        left,
                        width,
                        ref y
                    );
                }

                DrawRule(graphics, left, width, y);
                y += lineHeight * 0.5f;

                DrawPair(
                    graphics,
                    "Subtotal:",
                    FormatMoney(_data.Subtotal),
                    left,
                    width,
                    ref y
                );
                if (_data.Discount != 0)
                {
                    DrawPair(
                        graphics,
                        "Discount:",
                        FormatMoney(_data.Discount),
                        left,
                        width,
                        ref y
                    );
                }

                DrawPair(
                    graphics,
                    "TOTAL:",
                    FormatMoney(_data.Total),
                    left,
                    width,
                    ref y,
                    _totalFont
                );

                if (!string.IsNullOrWhiteSpace(_data.PaymentMethod))
                {
                    DrawPair(
                        graphics,
                        "Payment:",
                        _data.PaymentMethod!,
                        left,
                        width,
                        ref y
                    );
                    if (_data.AmountReceived.HasValue)
                    {
                        DrawPair(
                            graphics,
                            "Received:",
                            FormatMoney(_data.AmountReceived.Value),
                            left,
                            width,
                            ref y
                        );
                    }

                    if (_data.ChangeAmount.HasValue)
                    {
                        DrawPair(
                            graphics,
                            "Change:",
                            FormatMoney(_data.ChangeAmount.Value),
                            left,
                            width,
                            ref y
                        );
                    }
                }

                if (!string.IsNullOrWhiteSpace(_data.Footer))
                {
                    y += lineHeight * 0.6f;
                    DrawCentered(
                        graphics,
                        _data.Footer,
                        _bodyFont,
                        left,
                        width,
                        ref y
                    );
                }

                e.HasMorePages = false;
            }

            private void DrawLeft(
                Graphics graphics,
                string text,
                Font font,
                float left,
                float width,
                ref float y
            )
            {
                graphics.DrawString(text, font, Brushes.Black, left, y);
                y += font.GetHeight(graphics);
            }

            private void DrawCentered(
                Graphics graphics,
                string text,
                Font font,
                float left,
                float width,
                ref float y
            )
            {
                SizeF size = graphics.MeasureString(text, font);
                float x = left + Math.Max(0, (width - size.Width) / 2f);
                graphics.DrawString(text, font, Brushes.Black, x, y);
                y += font.GetHeight(graphics);
            }

            private void DrawPair(
                Graphics graphics,
                string label,
                string value,
                float left,
                float width,
                ref float y,
                Font? font = null
            )
            {
                Font useFont = font ?? _bodyFont;
                graphics.DrawString(label, useFont, Brushes.Black, left, y);
                SizeF size = graphics.MeasureString(value, useFont);
                graphics.DrawString(
                    value,
                    useFont,
                    Brushes.Black,
                    left + Math.Max(0, width - size.Width),
                    y
                );
                y += useFont.GetHeight(graphics) + 2f;
            }

            private static void DrawRule(
                Graphics graphics,
                float left,
                float width,
                float y
            )
            {
                using Pen pen = new(Color.Black, 1f);
                graphics.DrawLine(pen, left, y, left + width, y);
            }

            private static List<string> WrapText(
                Graphics graphics,
                string text,
                Font font,
                float maxWidth,
                int maxLines
            )
            {
                List<string> lines = new();
                if (string.IsNullOrWhiteSpace(text))
                {
                    lines.Add(string.Empty);
                    return lines;
                }

                Queue<string> words = new(
                    text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                );
                bool truncated = false;

                while (words.Count > 0 && lines.Count < maxLines)
                {
                    string line = words.Dequeue();
                    while (
                        words.Count > 0
                        && graphics.MeasureString(
                            line + " " + words.Peek(),
                            font
                        ).Width <= maxWidth
                    )
                    {
                        line += " " + words.Dequeue();
                    }

                    while (
                        graphics.MeasureString(line, font).Width > maxWidth
                        && line.Length > 1
                    )
                    {
                        int cut = line.Length - 1;
                        while (
                            cut > 1
                            && graphics.MeasureString(
                                line[..cut],
                                font
                            ).Width > maxWidth
                        )
                        {
                            cut--;
                        }

                        string remainder = line[cut..];
                        line = line[..cut].TrimEnd();
                        Queue<string> rest = new();
                        rest.Enqueue(remainder);
                        while (words.Count > 0)
                        {
                            rest.Enqueue(words.Dequeue());
                        }

                        words = rest;
                    }

                    lines.Add(line);
                }

                if (words.Count > 0)
                {
                    truncated = true;
                }

                if (truncated && lines.Count > 0)
                {
                    string last = lines[^1];
                    lines[^1] = last.Length >= 3
                        ? last[..^3].TrimEnd() + "..."
                        : last + "...";
                }

                return lines;
            }
        }
    }
}
