using AuthAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize]
public class AdminController : ControllerBase
{
    private static readonly List<SystemUser> _users = new();
    private static readonly List<string> _roles = new()
    {
        "Admin",
        "Trade Officer",
        "Compliance",
        "Approver"
    };

    // ---------------- USERS ----------------

    [HttpGet("users")]
    public IActionResult GetUsers(
        [FromQuery] string? search,
        [FromQuery] string? role,
        [FromQuery] string? status)
    {
        var query = _users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(u =>
                u.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                u.Email.Contains(search, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(role) && role != "all")
            query = query.Where(u => u.Role == role);

        if (!string.IsNullOrWhiteSpace(status) && status != "all")
            query = query.Where(u => u.Status == status);

        return Ok(query.ToList());
    }

    [HttpPost("users")]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        var user = new SystemUser
        {
            Name = dto.Name,
            Email = dto.Email,
            Role = dto.Role,
            Branch = dto.Branch
        };

        _users.Add(user);
        return Ok(user);
    }

    [HttpPut("users/{id}/status")]
    public IActionResult UpdateUserStatus(string id, [FromBody] string status)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        user.Status = status;
        return Ok(user);
    }

    [HttpDelete("users/{id}")]
    public IActionResult DeleteUser(string id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        _users.Remove(user);
        return NoContent();
    }

}
