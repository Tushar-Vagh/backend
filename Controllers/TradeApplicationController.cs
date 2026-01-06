using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/trade-applications")]
    public class TradeApplicationController : ControllerBase
    {
        private readonly TradeApplicationService _service;

        public TradeApplicationController(TradeApplicationService service)
        {
            _service = service;
        }

        // SAVE DRAFT
        [HttpPost("draft")]
        public async Task<IActionResult> SaveDraft([FromBody] CreateTradeApplicationDto dto)
        {
            var id = await _service.CreateAsync(dto, "Draft");
            return Ok(new { id });
        }

        // SUBMIT
        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] CreateTradeApplicationDto dto)
        {
            var id = await _service.CreateAsync(dto, "Submitted");
            return Ok(new { id });
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
    }
}
