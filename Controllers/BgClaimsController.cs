using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/bg-claims")]
public class BgClaimsController : ControllerBase
{
    private readonly BgClaimService _service;

    public BgClaimsController(BgClaimService service)
    {
        _service = service;
    }

    // GET: api/bg-claims
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? status,
        [FromQuery] string? search)
    {
        return Ok(_service.GetAll(status, search));
    }

    // POST: api/bg-claims
    [HttpPost]
    public IActionResult Create([FromBody] CreateBgClaimDto dto)
    {
        var id = _service.Create(dto);
        return Ok(new { id });
    }
}
