using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public class BankGuaranteeService
    {
        private static readonly List<BankGuarantee> _bgs = new();

        public void SaveDraft(CreateBgDto dto)
        {
            _bgs.Add(Map(dto, "Draft"));
        }

        public void Submit(CreateBgDto dto)
        {
            _bgs.Add(Map(dto, "Submitted"));
        }

        public List<BankGuarantee> GetAll()
        {
            return _bgs.OrderByDescending(x => x.CreatedAt).ToList();
        }

        private static BankGuarantee Map(CreateBgDto dto, string status)
        {
            return new BankGuarantee
            {
                BgType = dto.BgType,
                Applicant = dto.Applicant,
                Beneficiary = dto.Beneficiary,
                BeneficiaryAddress = dto.BeneficiaryAddress,
                Amount = dto.Amount,
                Currency = dto.Currency,
                IssueDate = dto.IssueDate,
                ExpiryDate = dto.ExpiryDate,
                ClaimPeriod = dto.ClaimPeriod,
                ContractRef = dto.ContractRef,
                Purpose = dto.Purpose,
                ClaimConditions = dto.ClaimConditions,
                SpecialConditions = dto.SpecialConditions,
                Status = status
            };
        }
    }
}
