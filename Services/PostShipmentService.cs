using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PostShipmentService
    {
        private readonly AppDbContext _context;

        public PostShipmentService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL (with filters)
        public async Task<List<PostShipmentFacility>> GetAllAsync(
            string status,
            string search)
        {
            var query = _context.PostShipmentFacilities.AsQueryable();

            if (!string.IsNullOrEmpty(status) && status != "all")
                query = query.Where(x => x.Status == status);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x =>
                    x.Customer.Contains(search) ||
                    x.LcReference.Contains(search)
                );

            return await query
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
        }

        // SAVE DRAFT
        public async Task SaveDraftAsync(CreatePostShipmentDto dto)
        {
            var facility = Map(dto, "Draft");
            _context.PostShipmentFacilities.Add(facility);
            await _context.SaveChangesAsync();
        }

        // SUBMIT
        public async Task SubmitAsync(CreatePostShipmentDto dto)
        {
            var facility = Map(dto, "Active");
            _context.PostShipmentFacilities.Add(facility);
            await _context.SaveChangesAsync();
        }

        // MAP DTO → ENTITY
        private PostShipmentFacility Map(CreatePostShipmentDto dto, string status)
        {
            return new PostShipmentFacility
            {
                FacilityRef = $"PSF-{DateTime.UtcNow.Ticks}",
                FacilityType = dto.FacilityType,
                Customer = dto.Customer,
                LcReference = dto.LcReference,
                BillAmount = dto.BillAmount,
                AdvanceAmount = dto.AdvanceAmount,
                Currency = dto.Currency,
                InterestRate = dto.InterestRate,
                DueDate = dto.DueDate,
                Status = status
            };
        }
    }
}
