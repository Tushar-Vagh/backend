using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class TradeApplicationService
    {
        private readonly AppDbContext _context;

        public TradeApplicationService(AppDbContext context)
        {
            _context = context;
        }

        // SAVE DRAFT / SUBMIT
        public async Task<Guid> CreateAsync(CreateTradeApplicationDto dto, string status)
        {
            var app = new TradeApplication
            {
                TradeType = dto.TradeType,
                ImportExport = dto.ImportExport,
                Applicant = dto.Applicant,
                Beneficiary = dto.Beneficiary,
                Amount = dto.Amount,
                Currency = dto.Currency,
                TenorDays = dto.TenorDays,
                ExpiryDate = dto.ExpiryDate,
                Description = dto.Description,
                Status = status
            };

            _context.TradeApplications.Add(app);
            await _context.SaveChangesAsync();

            return app.Id;
        }

        // GET ALL
        public async Task<List<TradeApplication>> GetAllAsync()
        {
            return await _context.TradeApplications
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
