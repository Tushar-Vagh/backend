namespace AuthAPI.DTOs;

public class AMLRequestDto
{
    public string EntityName { get; set; } = "";
    public string EntityType { get; set; } = "";
    public string Country { get; set; } = "";
    public DateTime? DateOfBirth { get; set; }
    public string IdNumber { get; set; } = "";
    public List<string> ScreenLists { get; set; } = new();
}
