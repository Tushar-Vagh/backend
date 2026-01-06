using Microsoft.AspNetCore.Mvc;
using TradeFinance.Application.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/lc")]
public class LetterOfCreditController : ControllerBase
{
    // In-memory store (NO DB, for local testing)
    private static readonly List<CreateLcDto> _lcs = new();

    // ===============================
    // GET ALL LCs (FOR LC OVERVIEW)
    // ===============================
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_lcs);
    }

    // ===============================
    // SAVE DRAFT
    // ===============================
    [HttpPost("draft")]
    public IActionResult SaveDraft([FromBody] CreateLcDto dto)
    {
        dto.Status = "Draft";

        _lcs.Add(dto);

        return Ok(new
        {
            message = "LC saved as draft",
            data = dto
        });
    }

    // ===============================
    // SUBMIT LC
    // ===============================
    [HttpPost("submit")]
    public IActionResult Submit([FromBody] CreateLcDto dto)
    {
        dto.Status = "Submitted";

        _lcs.Add(dto);

        return Ok(new
        {
            message = "LC submitted successfully",
            data = dto
        });
    }
}
