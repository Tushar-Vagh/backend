namespace TradeFlow.Models
{
public class LcAmendment
{
public Guid Id { get; set; }
public string AmendmentRef { get; set; }
public string LcReference { get; set; }
public string AmendmentType { get; set; }
public string RequestedBy { get; set; }
public string Status { get; set; } // Pending / Approved / Rejected
public DateTime RequestDate { get; set; }
}
}