namespace backend.Models
{
    public class BillDiscounting
    {
        public int Id { get; set; } // EF Primary Key

        public string Reference { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string BillType { get; set; } = string.Empty;
        public string BillNumber { get; set; } = string.Empty;
        public string Drawee { get; set; } = string.Empty;

        public decimal BillAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }

        public string Currency { get; set; } = string.Empty;
        public DateTime BillDate { get; set; }
        public DateTime MaturityDate { get; set; }

        public string Status { get; set; } = "Draft"; // Draft | Active
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
