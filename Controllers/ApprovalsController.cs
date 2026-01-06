using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/approvals")]
    public class ApprovalsController : ControllerBase
    {
        private readonly ApprovalService _service;

        public ApprovalsController(ApprovalService service)
        {
            _service = service;
        }

        [HttpGet("pending")]
        public IActionResult Pending()
        {
            return Ok(_service.GetPending());
        }

        [HttpGet("escalated")]
        public IActionResult Escalated()
        {
            return Ok(_service.GetEscalated());
        }

        [HttpGet("my-actions")]
        public IActionResult MyActions()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return Ok(_service.GetMyActions(email));
        }

        [HttpPost("{id}/approve")]
        public IActionResult Approve(string id, [FromBody] RemarksDto dto)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            _service.Approve(id, dto.Remarks, email);
            return Ok();
        }

        [HttpPost("{id}/reject")]
        public IActionResult Reject(string id, [FromBody] RemarksDto dto)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            _service.Reject(id, dto.Remarks, email);
            return Ok();
        }
    }

    public class RemarksDto
    {
        public string Remarks { get; set; }
    }
}
