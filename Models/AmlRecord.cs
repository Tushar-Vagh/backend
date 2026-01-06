namespace AuthAPI.Models;

public class AMLRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EntityName { get; set; }
    public string RiskLevel { get; set; }
    public string MatchType { get; set; }
    public int MatchScore { get; set; }
    public string Status { get; set; } // Pending, Cleared, Rejected
    public string ReviewedBy { get; set; }
    public DateTime ScreenedAt { get; set; } = DateTime.UtcNow;
}
