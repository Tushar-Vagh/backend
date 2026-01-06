namespace TradeFlow.Backend.Models.Reports
{
    public class ReportFilterDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Branch { get; set; }
        public string? Currency { get; set; }
    }
}
