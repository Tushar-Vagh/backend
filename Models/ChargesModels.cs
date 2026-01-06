namespace AuthAPI.Models;

public class Charge
{
    public int Id { get; set; }
    public string ChargeCode { get; set; } = "";
    public string Description { get; set; } = "";
    public string Product { get; set; } = "";
    public string CalculationType { get; set; } = ""; // Percentage / Flat
    public decimal Rate { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
}

public class ChargeSlab
{
    public int Id { get; set; }
    public string ChargeCode { get; set; } = "";
    public decimal FromAmount { get; set; }
    public decimal ToAmount { get; set; }
    public decimal RatePercent { get; set; }
    public decimal FlatFee { get; set; }
}

public class InterestRate
{
    public int Id { get; set; }
    public string Product { get; set; } = "";
    public string Currency { get; set; } = "";
    public decimal BaseRate { get; set; }
    public decimal Spread { get; set; }
    public string DayCount { get; set; } = "360";
}
