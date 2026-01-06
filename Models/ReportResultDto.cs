namespace TradeFlow.Backend.Models.Reports
{
    public class ReportResultDto
    {
        public string ReportName { get; set; } = string.Empty;
        public List<Dictionary<string, object>> Rows { get; set; } = new();
    }
}
