namespace AuthAPI.DTOs;

public class ApprovalReviewDto
{
    public Guid Id { get; set; }
    public string Decision { get; set; } = ""; // Approved / Rejected
    public string Remarks { get; set; } = "";
}
