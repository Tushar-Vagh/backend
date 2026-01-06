using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/system-config")]
[Authorize]
public class SystemConfigController : ControllerBase
{
    // 🔴 In-memory (replace with DB later)
    private static SystemConfig _config = new()
    {
        Id = 1,
        BaseCurrency = "USD",
        DayCountConvention = "360",
        FiscalYearStart = "April",
        SlaHours = 24,
        AlertDays = 7
    };

    // ✅ GET CONFIG
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_config);
    }

    // ✅ UPDATE CONFIG
    [HttpPut]
    public IActionResult Update(SystemConfigDto dto)
    {
        _config.BankName = dto.BankName;
        _config.BankCode = dto.BankCode;
        _config.SwiftCode = dto.SwiftCode;
        _config.Country = dto.Country;

        _config.BaseCurrency = dto.BaseCurrency;
        _config.DayCountConvention = dto.DayCountConvention;
        _config.FiscalYearStart = dto.FiscalYearStart;

        _config.MakerChecker = dto.MakerChecker;
        _config.FourEyes = dto.FourEyes;
        _config.AutoEscalation = dto.AutoEscalation;
        _config.SlaHours = dto.SlaHours;

        _config.EmailNotifications = dto.EmailNotifications;
        _config.ExpiryAlerts = dto.ExpiryAlerts;
        _config.AlertDays = dto.AlertDays;
        _config.OverdueNotifications = dto.OverdueNotifications;

        return Ok(new { message = "System configuration updated successfully" });
    }
}
