namespace backend.Models
{
    public class ApprovalItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Module { get; set; } = "";
        public string ReferenceNo { get; set; } = "";
        public string CustomerName { get; set; } = "";

        public string RiskLevel { get; set; } = "Medium";
        public string Flags { get; set; } = "";
        public bool IsSlaBreached { get; set; }

        public string Status { get; set; } = "Pending";

        public string CreatedBy { get; set; } = "system";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ ADD THESE TWO
        public string? Action { get; set; }        // Approved / Rejected
        public string? ActionBy { get; set; }      // user email

        public string? ReviewRemarks { get; set; }
        public string? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
