using TradeFlow.Backend.Models.Reports;

namespace backend.Services
{
    public interface IReportsService
    {
        ReportResultDto LcOutstanding(ReportFilterDto f);
        ReportResultDto LcMaturity(ReportFilterDto f);
        ReportResultDto LcUtilization(ReportFilterDto f);

        ReportResultDto BgLiability(ReportFilterDto f);
        ReportResultDto BgExpiry(ReportFilterDto f);
        ReportResultDto BgClaims(ReportFilterDto f);

        ReportResultDto TradeLoanOutstanding(ReportFilterDto f);
        ReportResultDto TradeLoanOverdue(ReportFilterDto f);
        ReportResultDto TradeLoanInterest(ReportFilterDto f);

        ReportResultDto ExposureCountry(ReportFilterDto f);
        ReportResultDto ExposureCurrency(ReportFilterDto f);
        ReportResultDto ExposureCustomer(ReportFilterDto f);

        ReportResultDto CentralBank(ReportFilterDto f);
        ReportResultDto AmlSummary(ReportFilterDto f);
        ReportResultDto AuditTrail(ReportFilterDto f);

        List<ScheduledReportDto> GetScheduled();
        void CreateScheduled(ScheduledReportDto dto);
        void UpdateScheduledStatus(int id, bool status);
        void DeleteScheduled(int id);
    }
}
