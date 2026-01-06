namespace backend.DTOs
{
    public class CreateBgDto
    {
        public string BgType { get; set; }
        public string Applicant { get; set; }
        public string Beneficiary { get; set; }
        public string BeneficiaryAddress { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ClaimPeriod { get; set; }

        public string ContractRef { get; set; }
        public string Purpose { get; set; }

        public string ClaimConditions { get; set; }
        public string SpecialConditions { get; set; }

        public string Status { get; set; }
    }
}
