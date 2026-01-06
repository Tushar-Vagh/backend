using backend.Models;

namespace backend.Services
{
    public class ApprovalStore
    {
        private readonly List<ApprovalItem> _approvals = new()
        {
            new ApprovalItem
            {
                Module = "LC",
                ReferenceNo = "LC-1001",
                CustomerName = "ABC Traders",
                RiskLevel = "High",
                Flags = "AML",
                IsSlaBreached = true
            },
            new ApprovalItem
            {
                Module = "BG",
                ReferenceNo = "BG-2001",
                CustomerName = "XYZ Exports",
                RiskLevel = "Medium",
                Flags = "",
                IsSlaBreached = false
            }
        };

        public List<ApprovalItem> GetAll() => _approvals;
    }
}
