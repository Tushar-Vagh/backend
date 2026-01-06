using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/pre-shipment")]
    public class PreShipmentController : ControllerBase
    {
        private readonly PreShipmentService _service;

        public PreShipmentController(PreShipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var data = await _service.GetAllAsync(status, search);
            return Ok(data);
        }

        [HttpPost("draft")]
        public async Task<IActionResult> SaveDraft([FromBody] CreatePreShipmentDto dto)
        {
            var refNo = await _service.CreateAsync(dto, "Draft");
            return Ok(new { facilityRef = refNo });
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] CreatePreShipmentDto dto)
        {
            var refNo = await _service.CreateAsync(dto, "Active");
            return Ok(new { facilityRef = refNo });
        }
    }
}
