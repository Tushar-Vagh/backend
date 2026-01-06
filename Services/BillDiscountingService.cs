using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class BillDiscountingService
    {
        private readonly AppDbContext _context;

        public BillDiscountingService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<BillDiscounting>> GetAllAsync(string status, string search)
        {
            var q = _context.BillDiscountings.AsQueryable();

            if (!string.IsNullOrEmpty(status) && status != "all")
                q = q.Where(x => x.Status == status);

            if (!string.IsNullOrEmpty(search))
                q = q.Where(x =>
                    x.Reference.Contains(search) ||
                    x.Customer.Contains(search));

            return await q
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        // CREATE (Draft / Active)
        public async Task<BillDiscounting> CreateAsync(
            CreateBillDiscountingDto dto,
            string status)
        {
            var days = (dto.MaturityDate - dto.BillDate).Days;

            var discount =
                dto.BillAmount * dto.DiscountRate / 100 * days / 360;

            var item = new BillDiscounting
            {
                Reference = $"BD-{Guid.NewGuid():N}".Substring(0, 10),
                Customer = dto.Customer,
                BillType = dto.BillType,
                BillNumber = dto.BillNumber,
                Drawee = dto.Drawee,
                BillAmount = dto.BillAmount,
                DiscountRate = dto.DiscountRate,
                DiscountAmount = discount,
                NetAmount = dto.BillAmount - discount,
                Currency = dto.Currency,
                BillDate = dto.BillDate,
                MaturityDate = dto.MaturityDate,
                Status = status,
                CreatedAt = DateTime.UtcNow
            };

            _context.BillDiscountings.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
