using backend.Models;

namespace backend.Services
{
    public class ApprovalService
    {
        private readonly ApprovalStore _store;

        public ApprovalService(ApprovalStore store)
        {
            _store = store;
        }

        public List<ApprovalItem> GetPending()
        {
            return _store.GetAll()
                .Where(x => x.Status == "Pending")
                .ToList();
        }

        public List<ApprovalItem> GetEscalated()
        {
            return _store.GetAll()
                .Where(x => x.IsSlaBreached)
                .ToList();
        }

        public List<ApprovalItem> GetMyActions(string userEmail)
        {
            return _store.GetAll()
                .Where(x => x.ActionBy == userEmail)
                .ToList();
        }

        public void Approve(string id, string remarks, string user)
        {
            var item = _store.GetAll().FirstOrDefault(x => x.Id == id);
            if (item == null) return;

            item.Status = "Approved";
            item.Action = "Approved";        // ⭐ IMPORTANT
            item.ActionBy = user;            // ⭐ IMPORTANT

            item.ReviewRemarks = remarks;
            item.ReviewedBy = user;
            item.ReviewedAt = DateTime.UtcNow;
        }

        public void Reject(string id, string remarks, string user)
        {
            var item = _store.GetAll().FirstOrDefault(x => x.Id == id);
            if (item == null) return;

            item.Status = "Rejected";
            item.Action = "Rejected";        // ⭐ IMPORTANT
            item.ActionBy = user;            // ⭐ IMPORTANT

            item.ReviewRemarks = remarks;
            item.ReviewedBy = user;
            item.ReviewedAt = DateTime.UtcNow;
        }
    }
}
