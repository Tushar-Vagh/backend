using TradeFinance.Application.DTOs;
using TradeFinance.Domain.Models;

namespace TradeFinance.Application.Services;

public class LetterOfCreditService
{
    public LetterOfCredit Create(CreateLcDto dto, string status)
    {
        return new LetterOfCredit
        {
            LcType = dto.LcType,
            Direction = dto.Direction,
            Applicant = dto.Applicant,
            Beneficiary = dto.Beneficiary,
            AdvisingBank = dto.AdvisingBank,
            Amount = dto.Amount,
            Currency = dto.Currency,
            TenorDays = dto.TenorDays,
            ExpiryDate = dto.ExpiryDate,
            Tolerance = dto.Tolerance,
            GoodsDescription = dto.GoodsDescription,
            PortOfLoading = dto.PortOfLoading,
            PortOfDischarge = dto.PortOfDischarge,
            LatestShipmentDate = dto.LatestShipmentDate,
            Status = status
        };
    }
}
