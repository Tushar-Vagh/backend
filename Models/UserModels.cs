namespace AuthAPI.Models;

public record CreateUserDto(
    string Name,
    string Email,
    string Role,
    string Branch
);

public class SystemUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string Branch { get; set; } = "";
    public string Status { get; set; } = "Active";
    public DateTime LastLogin { get; set; } = DateTime.Now;
}
