namespace backend.Services;

public class AMLService
{
    private readonly List<AMLRecord> _records = new();

    public AMLRecord RunScreening(
        string entityName,
        string entityType,
        string country,
        string countryRisk,
        string createdBy)
    {
        var score = countryRisk switch
        {
            "Sanctioned" => 95,
            "High" => 80,
            "Medium" => 50,
            _ => 20
        };

        var riskLevel = score >= 80 ? "High" :
                        score >= 50 ? "Medium" : "Low";

        var record = new AMLRecord
        {
            Id = Guid.NewGuid(),
            EntityName = entityName,
            EntityType = entityType,
            Country = country,
            MatchScore = score,
            RiskLevel = riskLevel,
            Status = "Pending",
            ScreenedAt = DateTime.UtcNow,
            CreatedBy = createdBy
        };

        _records.Add(record);
        return record;
    }

    public IEnumerable<AMLRecord> GetPending()
        => _records.Where(x => x.Status == "Pending");

    public IEnumerable<AMLRecord> GetHistory()
        => _records.Where(x => x.Status != "Pending");

    public bool Review(Guid id, string status, string reviewer)
    {
        var record = _records.FirstOrDefault(x => x.Id == id);
        if (record == null) return false;

        record.Status = status;
        record.ReviewedBy = reviewer;
        record.ReviewedAt = DateTime.UtcNow;

        return true;
    }
}

public class AMLRecord
{
    public Guid Id { get; set; }
    public string EntityName { get; set; }
    public string EntityType { get; set; }
    public string Country { get; set; }
    public int MatchScore { get; set; }
    public string RiskLevel { get; set; }
    public string Status { get; set; }
    public DateTime ScreenedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
}
