using TradeFlow.Backend.Models.Reports;

namespace backend.Services
{
    public class ReportsService : IReportsService
    {
        private static readonly List<ScheduledReportDto> _scheduled = new();

        private ReportResultDto Dummy(string name) =>
            new()
            {
                ReportName = name,
                Rows = new()
                {
                    new Dictionary<string, object>
                    {
                        { "Reference", "REF001" },
                        { "Customer", "ABC Traders" },
                        { "Amount", 100000 },
                        { "Currency", "USD" },
                        { "Status", "Active" }
                    }
                }
            };

        public ReportResultDto LcOutstanding(ReportFilterDto f) => Dummy("LC Outstanding");
        public ReportResultDto LcMaturity(ReportFilterDto f) => Dummy("LC Maturity");
        public ReportResultDto LcUtilization(ReportFilterDto f) => Dummy("LC Utilization");

        public ReportResultDto BgLiability(ReportFilterDto f) => Dummy("BG Liability");
        public ReportResultDto BgExpiry(ReportFilterDto f) => Dummy("BG Expiry");
        public ReportResultDto BgClaims(ReportFilterDto f) => Dummy("BG Claims");

        public ReportResultDto TradeLoanOutstanding(ReportFilterDto f) => Dummy("Trade Loan Outstanding");
        public ReportResultDto TradeLoanOverdue(ReportFilterDto f) => Dummy("Trade Loan Overdue");
        public ReportResultDto TradeLoanInterest(ReportFilterDto f) => Dummy("Interest Accrual");

        public ReportResultDto ExposureCountry(ReportFilterDto f) => Dummy("Country Exposure");
        public ReportResultDto ExposureCurrency(ReportFilterDto f) => Dummy("Currency Exposure");
        public ReportResultDto ExposureCustomer(ReportFilterDto f) => Dummy("Customer Exposure");

        public ReportResultDto CentralBank(ReportFilterDto f) => Dummy("Central Bank");
        public ReportResultDto AmlSummary(ReportFilterDto f) => Dummy("AML Summary");
        public ReportResultDto AuditTrail(ReportFilterDto f) => Dummy("Audit Trail");

        public List<ScheduledReportDto> GetScheduled() => _scheduled;

        public void CreateScheduled(ScheduledReportDto dto) => _scheduled.Add(dto);

        public void UpdateScheduledStatus(int id, bool status)
            => _scheduled.First(x => x.Id == id).IsActive = status;

        public void DeleteScheduled(int id)
            => _scheduled.RemoveAll(x => x.Id == id);
    }
}
