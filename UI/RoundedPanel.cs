using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mart_Management_System.UI
{
    public class RoundedPanel : Panel
    {
        private bool _hovered;

        public RoundedPanel()
        {
            SetStyle(
                ControlStyles.UserPaint
                    | ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.ResizeRedraw,
                true
            );
            BackColor = Color.White;
            Padding = new Padding(14, 10, 14, 10);
            Margin = new Padding(0, 8, 10, 8);
        }

        public int CornerRadius { get; set; } = 10;

        public Color BorderColor { get; set; } = Color.FromArgb(226, 230, 234);

        public Color HoverBorderColor { get; set; } = UiTheme.ActiveGreen;

        public Color HoverBackColor { get; set; } = Color.FromArgb(250, 253, 250);

        public bool HoverEffect { get; set; } = true;

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!HoverEffect || _hovered)
            {
                return;
            }

            _hovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_hovered)
            {
                return;
            }

            _hovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Parent?.BackColor ?? Color.FromArgb(238, 241, 244));

            Rectangle bounds = new(1, 1, Width - 3, Height - 3);

            using GraphicsPath shadowPath = GetRoundedPath(
                new Rectangle(bounds.X, bounds.Y + 2, bounds.Width, bounds.Height),
                CornerRadius
            );
            using GraphicsPath path = GetRoundedPath(bounds, CornerRadius);

            using SolidBrush shadowBrush = new(Color.FromArgb(24, 0, 0, 0));
            graphics.FillPath(shadowBrush, shadowPath);

            Color fill = _hovered ? HoverBackColor : BackColor;
            using SolidBrush fillBrush = new(fill);
            graphics.FillPath(fillBrush, path);

            using Pen borderPen = new(
                _hovered ? HoverBorderColor : BorderColor,
                _hovered ? 1.6f : 1f
            );
            graphics.DrawPath(borderPen, path);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Painted in OnPaint so the rounded corners show the parent color.
        }

        private static GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            int diameter = Math.Max(2, radius * 2);
            GraphicsPath path = new();
            Rectangle arc = new(bounds.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
