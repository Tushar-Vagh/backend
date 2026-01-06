namespace backend.Models
{
    public class PostShipmentFacility
    {
        public int Id { get; set; } // EF primary key

        public string FacilityRef { get; set; } = string.Empty;
        public string FacilityType { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string LcReference { get; set; } = string.Empty;

        public decimal BillAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public decimal InterestRate { get; set; }
        public DateTime? DueDate { get; set; }

        public string Status { get; set; } = "Draft";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
