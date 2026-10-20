using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mart_Management_System.UI
{
    public class SegmentedToggle : Panel
    {
        private readonly List<string> _items = new();
        private int _selectedIndex = -1;
        private int _hoverIndex = -1;

        public SegmentedToggle()
        {
            SetStyle(
                ControlStyles.UserPaint
                    | ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.ResizeRedraw
                    | ControlStyles.SupportsTransparentBackColor,
                true
            );
            BackColor = Color.FromArgb(238, 241, 244);
            Height = 34;
            Cursor = Cursors.Hand;
        }

        public event EventHandler? SelectedIndexChanged;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                int clamped = Math.Clamp(value, -1, _items.Count - 1);
                if (clamped == _selectedIndex)
                {
                    return;
                }

                _selectedIndex = clamped;
                Invalidate();
            }
        }

        public void SetItems(params string[] items)
        {
            _items.Clear();
            _items.AddRange(items);
            if (_selectedIndex >= _items.Count)
            {
                _selectedIndex = _items.Count - 1;
            }

            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.FromArgb(238, 241, 244));

            if (_items.Count == 0)
            {
                return;
            }

            Rectangle track = new(0, 0, Width - 1, Height - 1);
            using GraphicsPath trackPath = RoundedRect(track, 8);
            using SolidBrush trackBrush = new(Color.White);
            using Pen trackPen = new(Color.FromArgb(216, 221, 226));
            graphics.FillPath(trackBrush, trackPath);
            graphics.DrawPath(trackPen, trackPath);

            int innerPadding = 3;
            int segmentWidth = (track.Width - (innerPadding * 2)) / _items.Count;

            for (int index = 0; index < _items.Count; index++)
            {
                Rectangle segment = new(
                    track.X + innerPadding + (index * segmentWidth),
                    track.Y + innerPadding,
                    segmentWidth - (index == _items.Count - 1 ? innerPadding : 0),
                    track.Height - (innerPadding * 2)
                );

                bool isSelected = index == _selectedIndex;
                bool isHovered = index == _hoverIndex && !isSelected;

                if (isSelected)
                {
                    using GraphicsPath selectedPath = RoundedRect(segment, 6);
                    using SolidBrush selectedBrush = new(UiTheme.ActiveGreen);
                    graphics.FillPath(selectedBrush, selectedPath);
                }
                else if (isHovered)
                {
                    using GraphicsPath hoverPath = RoundedRect(segment, 6);
                    using SolidBrush hoverBrush = new(Color.FromArgb(234, 245, 236));
                    graphics.FillPath(hoverBrush, hoverPath);
                }

                Color textColor = isSelected
                    ? Color.White
                    : isHovered
                        ? Color.FromArgb(40, 120, 60)
                        : Color.FromArgb(95, 100, 105);

                TextRenderer.DrawText(
                    graphics,
                    _items[index],
                    new Font("Segoe UI", 9F, FontStyle.Bold),
                    segment,
                    textColor,
                    TextFormatFlags.HorizontalCenter
                        | TextFormatFlags.VerticalCenter
                );
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int index = IndexFromX(e.X);
            if (index != _hoverIndex)
            {
                _hoverIndex = index;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverIndex != -1)
            {
                _hoverIndex = -1;
                Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int index = IndexFromX(e.X);
            if (index < 0 || index == _selectedIndex)
            {
                return;
            }

            SelectedIndex = index;
            SelectedIndexChanged?.Invoke(this, System.EventArgs.Empty);
        }

        private int IndexFromX(int x)
        {
            if (_items.Count == 0 || x < 3 || x > Width - 3)
            {
                return -1;
            }

            int segmentWidth = (Width - 1 - 6) / _items.Count;
            int index = (x - 3) / Math.Max(1, segmentWidth);
            return Math.Clamp(index, 0, _items.Count - 1);
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
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
