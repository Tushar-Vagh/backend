using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PreShipmentService
    {
        private readonly AppDbContext _context;

        public PreShipmentService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL (with filters)
        public async Task<List<PreShipmentFacility>> GetAllAsync(
            string? status,
            string? search)
        {
            var query = _context.PreShipmentFacilities.AsQueryable();

            if (!string.IsNullOrEmpty(status) && status != "all")
                query = query.Where(x => x.Status == status);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x =>
                    x.Customer.Contains(search) ||
                    x.LcReference.Contains(search)
                );

            return await query
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        // CREATE (Draft / Active)
        public async Task<string> CreateAsync(CreatePreShipmentDto dto, string status)
        {
            var facility = new PreShipmentFacility
            {
                FacilityRef = $"PSF-{DateTime.UtcNow.Ticks}",
                Customer = dto.Customer,
                LcReference = dto.LcReference,
                Amount = dto.Amount,
                Currency = dto.Currency,
                InterestRate = dto.InterestRate,
                TenorDays = dto.TenorDays,
                DisbursementDate = dto.DisbursementDate,
                DueDate = dto.DueDate,
                Status = status
            };

            _context.PreShipmentFacilities.Add(facility);
            await _context.SaveChangesAsync();

            return facility.FacilityRef;
        }
    }
}
