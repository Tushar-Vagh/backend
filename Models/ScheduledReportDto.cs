namespace TradeFlow.Backend.Models.Reports
{
    public class ScheduledReportDto
    {
        public int Id { get; set; }
        public string ReportKey { get; set; } = string.Empty;
        public string Frequency { get; set; } = "Daily";
        public bool IsActive { get; set; } = true;
    }
}
