using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mart_Management_System.UI
{
    public static class UiTheme
    {
        public static Color ActiveGreen { get; } = Color.FromArgb(91, 174, 99);

        private static readonly ConditionalWeakTable<Control, object> AppliedControls =
            new();

        private static readonly ConditionalWeakTable<Button, ButtonState> ButtonStates =
            new();

        public static void Apply(Control root)
        {
            if (root is Button button)
            {
                ApplyButton(button);
            }
            else if (root is DataGridView grid)
            {
                ApplyGrid(grid);
            }

            foreach (Control child in root.Controls)
            {
                Apply(child);
            }
        }

        public static void SetActive(
            Button button,
            bool isActive,
            Color? activeColor = null
        )
        {
            if (!ButtonStates.TryGetValue(button, out ButtonState? state))
            {
                ApplyButton(button);
                ButtonStates.TryGetValue(button, out state);
            }

            if (state is null)
            {
                return;
            }

            state.IsActive = isActive;
            state.ActiveColor = activeColor ?? ActiveGreen;
            button.BackColor = state.IsActive
                ? state.ActiveColor
                : state.NormalColor;
        }

        private static void ApplyButton(Button button)
        {
            if (AppliedControls.TryGetValue(button, out _))
            {
                return;
            }

            AppliedControls.Add(button, new object());
            Color normalColor = button.BackColor;
            ButtonState state = new()
            {
                NormalColor = normalColor,
                HoverColor = ControlPaint.Light(
                    normalColor,
                    normalColor.GetBrightness() < 0.35 ? 0.18f : 0.12f
                )
            };
            ButtonStates.Add(button, state);

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.MouseEnter += (_, _) =>
            {
                button.BackColor = state.IsActive
                    ? ControlPaint.Light(state.ActiveColor, 0.12f)
                    : state.HoverColor;
            };
            button.MouseLeave += (_, _) =>
            {
                button.BackColor = state.IsActive
                    ? state.ActiveColor
                    : state.NormalColor;
            };
        }

        private static void ApplyGrid(DataGridView grid)
        {
            if (AppliedControls.TryGetValue(grid, out _))
            {
                return;
            }

            AppliedControls.Add(grid, new object());
            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 251, 252);
            grid.CellMouseEnter += (_, eventArgs) =>
            {
                if (eventArgs.RowIndex >= 0)
                {
                    grid.Rows[eventArgs.RowIndex].DefaultCellStyle.BackColor =
                        Color.FromArgb(234, 245, 236);
                }
            };
            grid.CellMouseLeave += (_, eventArgs) =>
            {
                if (eventArgs.RowIndex >= 0)
                {
                    DataGridViewRow row = grid.Rows[eventArgs.RowIndex];
                    row.DefaultCellStyle.BackColor = eventArgs.RowIndex % 2 == 0
                        ? Color.White
                        : Color.FromArgb(249, 251, 252);
                }
            };
        }

        private sealed class ButtonState
        {
            public Color NormalColor { get; init; }

            public Color HoverColor { get; init; }

            public Color ActiveColor { get; set; } = ActiveGreen;

            public bool IsActive { get; set; }
        }
    }
}
