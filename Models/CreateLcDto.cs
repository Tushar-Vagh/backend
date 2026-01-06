namespace TradeFinance.Application.DTOs;

public class CreateLcDto
{
    public string LcType { get; set; } = null!;
    public string Direction { get; set; } = null!;
    public string Applicant { get; set; } = null!;
    public string Beneficiary { get; set; } = null!;
    public string AdvisingBank { get; set; } = null!;

    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;

    public int TenorDays { get; set; }
    public DateTime ExpiryDate { get; set; }

    public decimal Tolerance { get; set; }
    public string GoodsDescription { get; set; } = null!;

    public string PortOfLoading { get; set; } = null!;
    public string PortOfDischarge { get; set; } = null!;
    public DateTime LatestShipmentDate { get; set; }

    public string Status { get; set; } = "Draft";
}
