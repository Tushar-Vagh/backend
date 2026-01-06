namespace AuthAPI.Models;

public class CountryRisk
{
    public string Country { get; set; }
    public string Region { get; set; }
    public string RiskRating { get; set; } // High / Medium / Low / Prohibited
    public decimal ExposureLimit { get; set; }
    public decimal CurrentExposure { get; set; }
}
