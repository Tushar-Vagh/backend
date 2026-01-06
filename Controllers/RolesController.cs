using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/admin/roles")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(new[]
            {
                new { name = "Admin", description = "System administrator" },
                new { name = "TradeOfficer", description = "Trade operations" },
                new { name = "Compliance", description = "AML & compliance" },
                new { name = "Approver", description = "Final approvals" }
            });
        }
    }
}
