using Microsoft.AspNetCore.Mvc;
using TradeFinance.API.Dtos;
using backend.Services;

namespace TradeFinance.API.Controllers;

[ApiController]
[Route("api/lc-amendments")]
public class LcAmendmentsController : ControllerBase
{
    private readonly LcAmendmentService _service;

    public LcAmendmentsController(LcAmendmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? status,
        [FromQuery] string? search)
    {
        return Ok(_service.GetAll(status, search));
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateLcAmendmentDto dto)
    {
        var id = _service.Create(dto);
        return Ok(new { id });
    }
}
