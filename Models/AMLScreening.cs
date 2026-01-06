namespace AuthAPI.Models;

public class AMLScreening
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EntityName { get; set; } = "";
    public string EntityType { get; set; } = "";
    public string Country { get; set; } = "";
    public DateTime? DateOfBirth { get; set; }
    public string IdNumber { get; set; } = "";
    public string TransactionRef { get; set; } = "";
    public string ScreeningType { get; set; } = "Manual";
    public List<string> ScreenedLists { get; set; } = new();
    public decimal MatchScore { get; set; }
    public string MatchType { get; set; } = "";
    public string RiskLevel { get; set; } = "Low";
    public string Status { get; set; } = "Pending";
    public DateTime ScreenedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "";
    public string Remarks { get; set; } = "";
}