using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradeFlow.Backend.Models.Reports;
using backend.Services;
using TradeFlow.Backend.Reports.Generators;

namespace TradeFlow.Backend.Reports.Controllers
{
    [Authorize(Roles = "Admin,Operations,Compliance,Manager,User")]
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _s;
        public ReportsController(IReportsService s) => _s = s;

        // ---------- LC ----------
        [HttpPost("lc/outstanding")] public IActionResult LcOutstanding(ReportFilterDto f) => Ok(_s.LcOutstanding(f));
        [HttpPost("lc/maturity")] public IActionResult LcMaturity(ReportFilterDto f) => Ok(_s.LcMaturity(f));
        [HttpPost("lc/utilization")] public IActionResult LcUtilization(ReportFilterDto f) => Ok(_s.LcUtilization(f));

        [HttpPost("lc/outstanding/download")] public IActionResult DLcOutstanding(ReportFilterDto f) => Excel(_s.LcOutstanding(f));
        [HttpPost("lc/maturity/download")] public IActionResult DLcMaturity(ReportFilterDto f) => Excel(_s.LcMaturity(f));
        [HttpPost("lc/utilization/download")] public IActionResult DLcUtilization(ReportFilterDto f) => Excel(_s.LcUtilization(f));

        // ---------- BG ----------
        [HttpPost("bg/liability")] public IActionResult BgLiability(ReportFilterDto f) => Ok(_s.BgLiability(f));
        [HttpPost("bg/expiry")] public IActionResult BgExpiry(ReportFilterDto f) => Ok(_s.BgExpiry(f));
        [HttpPost("bg/claims")] public IActionResult BgClaims(ReportFilterDto f) => Ok(_s.BgClaims(f));

        [HttpPost("bg/liability/download")] public IActionResult DBgLiability(ReportFilterDto f) => Excel(_s.BgLiability(f));
        [HttpPost("bg/expiry/download")] public IActionResult DBgExpiry(ReportFilterDto f) => Excel(_s.BgExpiry(f));
        [HttpPost("bg/claims/download")] public IActionResult DBgClaims(ReportFilterDto f) => Excel(_s.BgClaims(f));

        // ---------- TRADE LOANS ----------
        [HttpPost("trade-loans/outstanding")] public IActionResult TradeLoanOutstanding(ReportFilterDto f) => Ok(_s.TradeLoanOutstanding(f));
        [HttpPost("trade-loans/overdue")] public IActionResult TradeLoanOverdue(ReportFilterDto f) => Ok(_s.TradeLoanOverdue(f));
        [HttpPost("trade-loans/interest-accrual")] public IActionResult TradeLoanInterest(ReportFilterDto f) => Ok(_s.TradeLoanInterest(f));

        [HttpPost("trade-loans/outstanding/download")] public IActionResult DTradeLoanOutstanding(ReportFilterDto f) => Excel(_s.TradeLoanOutstanding(f));
        [HttpPost("trade-loans/overdue/download")] public IActionResult DTradeLoanOverdue(ReportFilterDto f) => Excel(_s.TradeLoanOverdue(f));
        [HttpPost("trade-loans/interest-accrual/download")] public IActionResult DTradeLoanInterest(ReportFilterDto f) => Excel(_s.TradeLoanInterest(f));

        // ---------- EXPOSURE ----------
        [HttpPost("exposure/country")] public IActionResult ExposureCountry(ReportFilterDto f) => Ok(_s.ExposureCountry(f));
        [HttpPost("exposure/currency")] public IActionResult ExposureCurrency(ReportFilterDto f) => Ok(_s.ExposureCurrency(f));
        [HttpPost("exposure/customer")] public IActionResult ExposureCustomer(ReportFilterDto f) => Ok(_s.ExposureCustomer(f));

        [HttpPost("exposure/country/download")] public IActionResult DExposureCountry(ReportFilterDto f) => Excel(_s.ExposureCountry(f));
        [HttpPost("exposure/currency/download")] public IActionResult DExposureCurrency(ReportFilterDto f) => Excel(_s.ExposureCurrency(f));
        [HttpPost("exposure/customer/download")] public IActionResult DExposureCustomer(ReportFilterDto f) => Excel(_s.ExposureCustomer(f));

        // ---------- REGULATORY ----------
        [HttpPost("regulatory/central-bank")] public IActionResult CentralBank(ReportFilterDto f) => Ok(_s.CentralBank(f));
        [HttpPost("regulatory/aml-summary")] public IActionResult AmlSummary(ReportFilterDto f) => Ok(_s.AmlSummary(f));
        [HttpPost("regulatory/audit-trail")] public IActionResult AuditTrail(ReportFilterDto f) => Ok(_s.AuditTrail(f));

        [HttpPost("regulatory/central-bank/download")] public IActionResult DCentralBank(ReportFilterDto f) => Excel(_s.CentralBank(f));
        [HttpPost("regulatory/aml-summary/download")] public IActionResult DAmlSummary(ReportFilterDto f) => Excel(_s.AmlSummary(f));
        [HttpPost("regulatory/audit-trail/download")] public IActionResult DAuditTrail(ReportFilterDto f) => Excel(_s.AuditTrail(f));

        // ---------- SCHEDULED ----------
        [HttpGet("scheduled")] public IActionResult GetScheduled() => Ok(_s.GetScheduled());
        [HttpPost("scheduled")] public IActionResult CreateScheduled(ScheduledReportDto d) { _s.CreateScheduled(d); return Ok(); }
        [HttpPut("scheduled/{id}/status")] public IActionResult UpdateStatus(int id, bool active) { _s.UpdateScheduledStatus(id, active); return Ok(); }
        [HttpDelete("scheduled/{id}")] public IActionResult Delete(int id) { _s.DeleteScheduled(id); return Ok(); }

        private IActionResult Excel(ReportResultDto r)
        {
            var bytes = ExcelReportGenerator.GenerateExcel(r.ReportName, r.Rows);
            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"{r.ReportName}.xlsx");
        }
    }
}
