namespace TradeFinance.API.Dtos;

public class CreateLcAmendmentDto
{
    public string LcReference { get; set; } = string.Empty;
    public string AmendmentType { get; set; } = string.Empty; // Amount / Expiry / Shipment etc
    public string RequestedBy { get; set; } = string.Empty;
    public string Remarks { get; set; } = string.Empty;
}
