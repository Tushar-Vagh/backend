using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/post-shipment")]
    public class PostShipmentController : ControllerBase
    {
        private readonly PostShipmentService _service;

        public PostShipmentController(PostShipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string status = "all",
            [FromQuery] string search = "")
        {
            var data = await _service.GetAllAsync(status, search);
            return Ok(data);
        }

        [HttpPost("draft")]
        public async Task<IActionResult> SaveDraft([FromBody] CreatePostShipmentDto dto)
        {
            await _service.SaveDraftAsync(dto);
            return Ok(new { message = "Post-shipment draft saved" });
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] CreatePostShipmentDto dto)
        {
            await _service.SubmitAsync(dto);
            return Ok(new { message = "Post-shipment submitted" });
        }
    }
}
