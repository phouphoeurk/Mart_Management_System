using System.Collections.Generic;

namespace Mart_Management_System.Models
{
    public sealed class DashboardSnapshot
    {
        public DashboardSummary Summary { get; set; } = new();

        public RangeSummary Current { get; set; } = new();

        public RangeSummary Previous { get; set; } = new();

        public List<ReportRow> Trend { get; set; } = new();

        public List<ReportRow> TopProducts { get; set; } = new();

        public List<ReportRow> PaymentMix { get; set; } = new();

        public List<SaleSummary> RecentSales { get; set; } = new();

        public List<ReportRow> LowStock { get; set; } = new();
    }
}
