namespace backend.Models
{
    public class PreShipmentFacility
    {
        public int Id { get; set; }   // EF Primary Key

        public string FacilityRef { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string LcReference { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }
        public int TenorDays { get; set; }

        public DateTime DisbursementDate { get; set; }
        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "Draft";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
