using TradeFlow.Backend.Masters.Models;

namespace backend.Services
{
    public class MasterService : IMasterService
    {
        public List<MasterItemDto> GetBranches() => new()
        {
            new() { Code = "MUM", Name = "Mumbai" },
            new() { Code = "DEL", Name = "Delhi" },
            new() { Code = "CHE", Name = "Chennai" },
            new() { Code = "BLR", Name = "Bangalore" }
        };

        public List<MasterItemDto> GetCurrencies() => new()
        {
            new() { Code = "INR", Name = "Indian Rupee" },
            new() { Code = "USD", Name = "US Dollar" },
            new() { Code = "EUR", Name = "Euro" },
            new() { Code = "GBP", Name = "British Pound" }
        };

        public List<MasterItemDto> GetReportTypes() => new()
        {
            new() { Code = "LC_OUT", Name = "LC Outstanding" },
            new() { Code = "LC_MAT", Name = "LC Maturity" },
            new() { Code = "BG_LIAB", Name = "BG Liability" },
            new() { Code = "TL_OUT", Name = "Trade Loan Outstanding" },
            new() { Code = "AML_SUM", Name = "AML Summary" }
        };
    }
}
