using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/bill-discounting")]
    public class BillDiscountingController : ControllerBase
    {
        private readonly BillDiscountingService _service;

        public BillDiscountingController(BillDiscountingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string status = "all",
            [FromQuery] string search = "")
        {
            var data = await _service.GetAllAsync(status, search);
            return Ok(data);
        }

        [HttpPost("draft")]
        public async Task<IActionResult> Draft([FromBody] CreateBillDiscountingDto dto)
        {
            var item = await _service.CreateAsync(dto, "Draft");
            return Ok(item);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] CreateBillDiscountingDto dto)
        {
            var item = await _service.CreateAsync(dto, "Active");
            return Ok(item);
        }
    }
}
