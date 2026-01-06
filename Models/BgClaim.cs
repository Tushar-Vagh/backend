namespace backend.Models;

public class BgClaim
{
    public string Id { get; set; }              // ✅ ADD THIS
    public string ClaimRef { get; set; }
    public string BgReference { get; set; }
    public string Claimant { get; set; }
    public decimal ClaimAmount { get; set; }
    public DateTime ClaimDate { get; set; }
    public string Status { get; set; }
}
