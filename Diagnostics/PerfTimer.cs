#if DEBUG
using System.Diagnostics;

namespace Mart_Management_System.Diagnostics
{
    internal static class PerfTimer
    {
        public static bool Enabled { get; set; } = true;

        public static IDisposable Measure(string label)
        {
            if (!Enabled)
            {
                return NoopScope.Instance;
            }

            return new Scope(label, Stopwatch.GetTimestamp());
        }

        public static void Log(string label, long startTimestamp)
        {
            if (!Enabled)
            {
                return;
            }

            double milliseconds =
                (Stopwatch.GetTimestamp() - startTimestamp)
                * 1000.0
                / Stopwatch.Frequency;
            Debug.WriteLine(
                $"[PERF] {label}: {milliseconds:0.0} ms (thread {Environment.CurrentManagedThreadId}, t={DateTime.Now:HH:mm:ss.fff})"
            );
        }

        private sealed class Scope : IDisposable
        {
            private readonly string _label;
            private readonly long _start;
            private bool _disposed;

            public Scope(string label, long start)
            {
                _label = label;
                _start = start;
            }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;
                Log(_label, _start);
            }
        }

        private sealed class NoopScope : IDisposable
        {
            public static readonly NoopScope Instance = new();

            private NoopScope()
            {
            }

            public void Dispose()
            {
            }
        }
    }
}
#else
namespace Mart_Management_System.Diagnostics
{
    // Release builds carry no timing instrumentation; every call site compiles
    // down to a shared no-op so there is no allocation and no logging overhead.
    internal static class PerfTimer
    {
        public static bool Enabled { get; set; }

        public static IDisposable Measure(string label)
        {
            return NoopScope.Instance;
        }

        public static void Log(string label, long startTimestamp)
        {
        }

        private sealed class NoopScope : IDisposable
        {
            public static readonly NoopScope Instance = new();

            private NoopScope()
            {
            }

            public void Dispose()
            {
            }
        }
    }
}
#endif
