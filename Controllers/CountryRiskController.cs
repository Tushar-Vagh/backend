using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/country-risk")]
[Authorize]
public class CountryRiskController : ControllerBase
{
    private readonly CountryRiskService _service;

    public CountryRiskController(CountryRiskService service)
    {
        _service = service;
    }

    // 🔹 Metrics (cards)
    [HttpGet("metrics")]
    public IActionResult GetMetrics()
    {
        return Ok(_service.GetMetrics());
    }

    // 🔹 Country risk table
    [HttpGet("countries")]
    public IActionResult GetCountries()
    {
        return Ok(_service.GetCountries());
    }

    // 🔹 Exposure by region (charts)
    [HttpGet("exposure-by-region")]
    public IActionResult GetExposureByRegion()
    {
        return Ok(_service.GetExposureByRegion());
    }

    // 🔹 Used internally by AML
    [HttpGet("risk/{country}")]
    public IActionResult GetRisk(string country)
    {
        return Ok(new
        {
            country,
            risk = _service.GetRisk(country)
        });
    }
}
