namespace backend.DTOs
{
    public class CreateBillDiscountingDto
    {
        public string Customer { get; set; } = string.Empty;
        public string BillType { get; set; } = string.Empty;
        public string BillNumber { get; set; } = string.Empty;
        public string Drawee { get; set; } = string.Empty;

        public decimal BillAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public string Currency { get; set; } = string.Empty;

        public DateTime BillDate { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}
