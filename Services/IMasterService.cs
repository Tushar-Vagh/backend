using TradeFlow.Backend.Masters.Models;

namespace backend.Services
{
    public interface IMasterService
    {
        List<MasterItemDto> GetBranches();
        List<MasterItemDto> GetCurrencies();
        List<MasterItemDto> GetReportTypes();
    }
}
