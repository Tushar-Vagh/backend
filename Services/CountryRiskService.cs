namespace backend.Services;

public class CountryRiskService
{
    private readonly Dictionary<string, string> _riskMatrix = new()
    {
        { "Afghanistan", "Sanctioned" },
        { "Iran", "High" },
        { "North Korea", "Sanctioned" },
        { "Russia", "High" },
        { "Pakistan", "Medium" },
        { "India", "Low" },
        { "USA", "Low" }
    };

    public string GetRisk(string country)
    {
        return _riskMatrix.TryGetValue(country, out var risk)
            ? risk
            : "Medium";
    }

    public object GetMetrics() => new
    {
        high = _riskMatrix.Count(x => x.Value == "High"),
        medium = _riskMatrix.Count(x => x.Value == "Medium"),
        low = _riskMatrix.Count(x => x.Value == "Low"),
        sanctioned = _riskMatrix.Count(x => x.Value == "Sanctioned")
    };

    public object GetCountries() =>
        _riskMatrix.Select(x => new
        {
            country = x.Key,
            region = "Asia",
            riskRating = x.Value,
            exposureLimit = 10_000_000,
            currentExposure = new Random().Next(100_000, 9_000_000)
        });

    public object GetExposureByRegion() => new[]
    {
        new { region = "Asia", value = 45 },
        new { region = "Europe", value = 30 },
        new { region = "Middle East", value = 15 },
        new { region = "Africa", value = 10 }
    };
}
