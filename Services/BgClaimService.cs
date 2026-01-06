using backend.DTOs;
using backend.Models;

namespace backend.Services;

public class BgClaimService
{
    private static readonly List<BgClaim> _claims = new();

    public List<BgClaimListDto> GetAll(string? status, string? search)
    {
        var query = _claims.AsQueryable();

        if (!string.IsNullOrEmpty(status) && status != "all")
            query = query.Where(x => x.Status == status);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x =>
                x.BgReference.Contains(search) ||
                x.Claimant.Contains(search));

        return query.Select(x => new BgClaimListDto
        {
            ClaimRef = x.ClaimRef,
            BgReference = x.BgReference,
            Claimant = x.Claimant,
            ClaimAmount = x.ClaimAmount,
            ClaimDate = x.ClaimDate,
            Status = x.Status
        }).ToList();
    }

    public string Create(CreateBgClaimDto dto)
    {
        var claim = new BgClaim
        {
            Id = Guid.NewGuid().ToString(),
            ClaimRef = "CLM-" + DateTime.UtcNow.Ticks,
            BgReference = dto.BgReference,
            Claimant = dto.Claimant,
            ClaimAmount = dto.ClaimAmount,
            ClaimDate = DateTime.UtcNow,
            Status = "Pending"
        };

        _claims.Add(claim);
        return claim.Id;
    }
}
