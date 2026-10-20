using System.Windows.Forms;

namespace Mart_Management_System.UI
{
    internal sealed class SearchDebouncer : IDisposable
    {
        private readonly System.Windows.Forms.Timer _timer;
        private readonly Action _action;
        private bool _disposed;

        public SearchDebouncer(int intervalMilliseconds, Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _timer = new System.Windows.Forms.Timer
            {
                Interval = intervalMilliseconds
            };
            _timer.Tick += OnTick;
        }

        public void Trigger()
        {
            if (_disposed)
            {
                return;
            }

            _timer.Stop();
            _timer.Start();
        }

        public void Flush()
        {
            if (_disposed || !_timer.Enabled)
            {
                return;
            }

            _timer.Stop();
            _action();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _timer.Stop();
            _timer.Tick -= OnTick;
            _timer.Dispose();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            _timer.Stop();
            _action();
        }
    }
}
