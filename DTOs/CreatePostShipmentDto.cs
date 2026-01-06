namespace backend.DTOs
{
    public class CreatePostShipmentDto
    {
        public string FacilityType { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string LcReference { get; set; } = string.Empty;

        public decimal BillAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
