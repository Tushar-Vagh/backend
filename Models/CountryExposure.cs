namespace AuthAPI.Models;

public class CountryExposure
{
    public string Country { get; set; }
    public string Product { get; set; } // LC / BG / Loans
    public decimal Funded { get; set; }
    public decimal NonFunded { get; set; }

    public decimal Total => Funded + NonFunded;
}
