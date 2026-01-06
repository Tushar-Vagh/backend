namespace backend.DTOs
{
    public class CreatePreShipmentDto
    {
        public string Customer { get; set; } = string.Empty;
        public string LcReference { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }
        public int TenorDays { get; set; }

        public DateTime DisbursementDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
