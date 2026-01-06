using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/bg")]
    public class BankGuaranteeController : ControllerBase
    {
        private readonly BankGuaranteeService _service;

        public BankGuaranteeController(BankGuaranteeService service)
        {
            _service = service;
        }

        [HttpPost("draft")]
        public IActionResult SaveDraft([FromBody] CreateBgDto dto)
        {
            _service.SaveDraft(dto);
            return Ok(new { message = "BG saved as draft" });
        }

        [HttpPost("submit")]
        public IActionResult Submit([FromBody] CreateBgDto dto)
        {
            _service.Submit(dto);
            return Ok(new { message = "BG submitted for approval" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
    }
}
