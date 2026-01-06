using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/aml")]
    [Authorize] // 🔐 JWT required
    public class AMLController : ControllerBase
    {
        private readonly AMLService _amlService;
        private readonly CountryRiskService _countryRiskService;

        public AMLController(
            AMLService amlService,
            CountryRiskService countryRiskService)
        {
            _amlService = amlService;
            _countryRiskService = countryRiskService;
        }

        // ------------------------------
        // ▶ MANUAL AML SCREENING
        // POST: /api/aml/screen
        // ------------------------------
        [HttpPost("screen")]
        public IActionResult Screen([FromBody] AMLScreenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.EntityName) ||
                string.IsNullOrWhiteSpace(request.EntityType) ||
                string.IsNullOrWhiteSpace(request.Country))
            {
                return BadRequest(new { message = "EntityName, EntityType & Country are mandatory" });
            }

            var countryRisk = _countryRiskService.GetRisk(request.Country);

            var result = _amlService.RunScreening(
                request.EntityName,
                request.EntityType,
                request.Country,
                countryRisk,
                User.Identity?.Name ?? "system"
            );

            return Ok(result);
        }

        // ------------------------------
        // ⏳ PENDING REVIEWS
        // GET: /api/aml/pending
        // ------------------------------
        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            return Ok(_amlService.GetPending());
        }

        // ------------------------------
        // 📜 SCREENING HISTORY
        // GET: /api/aml/history
        // ------------------------------
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            return Ok(_amlService.GetHistory());
        }

        // ------------------------------
        // ✅ APPROVE SCREENING
        // POST: /api/aml/{id}/approve
        // ------------------------------
        [HttpPost("{id}/approve")]
        public IActionResult Approve(Guid id)
        {
            var reviewer = User.FindFirstValue(ClaimTypes.Email) ?? "compliance";

            var success = _amlService.Review(id, "Approved", reviewer);
            if (!success) return NotFound();

            return Ok(new { message = "Screening approved" });
        }

        // ------------------------------
        // ❌ REJECT SCREENING
        // POST: /api/aml/{id}/reject
        // ------------------------------
        [HttpPost("{id}/reject")]
        public IActionResult Reject(Guid id)
        {
            var reviewer = User.FindFirstValue(ClaimTypes.Email) ?? "compliance";

            var success = _amlService.Review(id, "Rejected", reviewer);
            if (!success) return NotFound();

            return Ok(new { message = "Screening rejected" });
        }
    }

    // ==============================
    // DTO
    // ==============================
    public record AMLScreenRequest(
        string EntityName,
        string EntityType,
        string Country
    );
}
