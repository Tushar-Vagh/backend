namespace TradeFinance.API.Dtos;

public class LcAmendmentListDto
{
    public Guid Id { get; set; }
    public string AmendmentRef { get; set; } = string.Empty;
    public string LcReference { get; set; } = string.Empty;
    public string AmendmentType { get; set; } = string.Empty;
    public string RequestedBy { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
}
