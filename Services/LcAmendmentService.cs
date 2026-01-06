using TradeFinance.API.Dtos;

namespace backend.Services;

public class LcAmendmentService
{
    private static readonly List<LcAmendmentListDto> _data = new();

    public IEnumerable<LcAmendmentListDto> GetAll(string? status, string? search)
    {
        var query = _data.AsQueryable();

        if (!string.IsNullOrWhiteSpace(status) && status != "all")
            query = query.Where(x => x.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(x => x.LcReference.Contains(search, StringComparison.OrdinalIgnoreCase));

        return query.OrderByDescending(x => x.RequestDate).ToList();
    }

    public Guid Create(CreateLcAmendmentDto dto)
    {
        var amendment = new LcAmendmentListDto
        {
            Id = Guid.NewGuid(),
            AmendmentRef = $"AMD-{DateTime.UtcNow.Ticks}",
            LcReference = dto.LcReference,
            AmendmentType = dto.AmendmentType,
            RequestedBy = dto.RequestedBy,
            Status = "Pending",
            RequestDate = DateTime.UtcNow
        };

        _data.Add(amendment);
        return amendment.Id;
    }
}
