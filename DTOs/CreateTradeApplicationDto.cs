namespace backend.DTOs
{
    public class CreateTradeApplicationDto
    {
        public string TradeType { get; set; } = string.Empty;
        public string ImportExport { get; set; } = string.Empty;
        public string Applicant { get; set; } = string.Empty;
        public string Beneficiary { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public int TenorDays { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
