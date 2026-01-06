namespace AuthAPI.DTOs
{
    public class AMLScreeningDto
    {
        public string EntityName { get; set; } = "";
        public string EntityType { get; set; } = "";
        public string Country { get; set; } = "";
        public string? DateOfBirth { get; set; }
        public string? IdNumber { get; set; }
        public List<string> ScreenLists { get; set; } = new();
    }
}
