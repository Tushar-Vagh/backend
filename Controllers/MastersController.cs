using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace TradeFlow.Backend.Masters.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/masters")]
    public class MastersController : ControllerBase
    {
        private readonly IMasterService _service;

        public MastersController(IMasterService service)
        {
            _service = service;
        }

        [HttpGet("branches")]
        public IActionResult GetBranches()
        {
            return Ok(_service.GetBranches());
        }

        [HttpGet("currencies")]
        public IActionResult GetCurrencies()
        {
            return Ok(_service.GetCurrencies());
        }

        [HttpGet("report-types")]
        public IActionResult GetReportTypes()
        {
            return Ok(_service.GetReportTypes());
        }
    }
}
