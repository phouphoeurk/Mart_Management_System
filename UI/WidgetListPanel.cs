using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mart_Management_System.UI
{
    public sealed class WidgetRow
    {
        public string LeftText { get; init; } = string.Empty;

        public string RightText { get; init; } = string.Empty;

        public Color RightColor { get; init; } = Color.FromArgb(70, 70, 70);

        public float? BarFraction { get; init; }

        public Color BarColor { get; init; } = UiTheme.ActiveGreen;
    }

    public class WidgetListPanel : RoundedPanel
    {
        private readonly List<WidgetRow> _rows = new();
        private string _title = string.Empty;
        private string _emptyText = "No data yet";

        public WidgetListPanel()
        {
            Padding = new Padding(14, 10, 14, 10);
            HoverEffect = false;
        }

        public void SetContent(string title, IEnumerable<WidgetRow> rows, string? emptyText = null)
        {
            _title = title;
            _rows.Clear();
            _rows.AddRange(rows);
            _emptyText = emptyText ?? "No data yet";
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            RectangleF titleArea = new(
                Padding.Left,
                Padding.Top,
                Width - Padding.Horizontal - 4,
                22
            );
            using (Font titleFont = new("Segoe UI", 10F, FontStyle.Bold))
            using (SolidBrush titleBrush = new(Color.FromArgb(40, 40, 40)))
            {
                graphics.DrawString(_title, titleFont, titleBrush, titleArea);
            }

            int dividerY = (int)titleArea.Bottom + 2;
            using (Pen dividerPen = new(Color.FromArgb(236, 239, 242)))
            {
                graphics.DrawLine(
                    dividerPen,
                    Padding.Left,
                    dividerY,
                    Width - Padding.Right - 4,
                    dividerY
                );
            }

            RectangleF rowsArea = new(
                Padding.Left,
                dividerY + 8,
                Width - Padding.Horizontal - 4,
                Height - dividerY - Padding.Bottom - 12
            );

            if (_rows.Count == 0)
            {
                using Font emptyFont = new("Segoe UI", 9F);
                using SolidBrush emptyBrush = new(Color.Gray);
                graphics.DrawString(
                    _emptyText,
                    emptyFont,
                    emptyBrush,
                    rowsArea,
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
                return;
            }

            float rowHeight = rowsArea.Height / _rows.Count;
            using Font rowFont = new("Segoe UI", 9F);
            using Font valueFont = new("Segoe UI", 9F, FontStyle.Bold);
            using SolidBrush leftBrush = new(Color.FromArgb(70, 70, 70));

            for (int index = 0; index < _rows.Count; index++)
            {
                WidgetRow row = _rows[index];
                float rowTop = rowsArea.Top + (index * rowHeight);
                float barHeight = row.BarFraction.HasValue ? 5f : 0f;
                float textHeight = rowHeight - barHeight - 3f;

                RectangleF leftArea = new(
                    rowsArea.Left,
                    rowTop,
                    rowsArea.Width * 0.62f,
                    Math.Max(14, textHeight)
                );
                RectangleF rightArea = new(
                    rowsArea.Left + (rowsArea.Width * 0.62f),
                    rowTop,
                    rowsArea.Width * 0.38f,
                    Math.Max(14, textHeight)
                );

                graphics.DrawString(
                    Truncate(row.LeftText, leftArea.Width, rowFont),
                    rowFont,
                    leftBrush,
                    leftArea
                );

                using (SolidBrush rightBrush = new(row.RightColor))
                {
                    graphics.DrawString(
                        row.RightText,
                        valueFont,
                        rightBrush,
                        rightArea,
                        new StringFormat { Alignment = StringAlignment.Far }
                    );
                }

                if (row.BarFraction.HasValue)
                {
                    float barTop = rowTop + textHeight + 2f;
                    float barWidth = Math.Max(
                        0,
                        rowsArea.Width * Math.Clamp(row.BarFraction.Value, 0f, 1f)
                    );
                    RectangleF track = new(rowsArea.Left, barTop, rowsArea.Width, barHeight);
                    RectangleF fill = new(rowsArea.Left, barTop, barWidth, barHeight);

                    using SolidBrush trackBrush = new(Color.FromArgb(236, 239, 242));
                    using SolidBrush fillBrush = new(row.BarColor);
                    graphics.FillRectangle(trackBrush, track);
                    if (barWidth > 0)
                    {
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.FillRectangle(fillBrush, fill);
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                }
            }
        }

        private static string Truncate(string text, float width, Font font)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            using Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            if (g.MeasureString(text, font).Width <= width)
            {
                return text;
            }

            const string suffix = "…";
            while (
                text.Length > 0
                && g.MeasureString(text + suffix, font).Width > width
            )
            {
                text = text[..^1];
            }

            return text + suffix;
        }
    }
}
