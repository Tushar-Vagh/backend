namespace AuthAPI.DTOs;

public class AMLReviewDto
{
    public Guid ScreeningId { get; set; }
    public string Decision { get; set; } = "";
    public string Remarks { get; set; } = "";
}
