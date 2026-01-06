namespace backend.DTOs
{
    public class CreateBgClaimDto
    {
        public string BgReference { get; set; } = "";
        public string Claimant { get; set; } = "";
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class BgClaimListDto
    {
        public string ClaimRef { get; set; } = "";
        public string BgReference { get; set; } = "";
        public string Claimant { get; set; } = "";
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Status { get; set; } = "";
    }
}
