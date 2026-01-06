using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Otp> Otps => Set<Otp>();
        public DbSet<TradeApplication> TradeApplications => Set<TradeApplication>();
        public DbSet<PreShipmentFacility> PreShipmentFacilities => Set<PreShipmentFacility>();
        public DbSet<PostShipmentFacility> PostShipmentFacilities => Set<PostShipmentFacility>();

        // ✅ ADD THIS
        public DbSet<BillDiscounting> BillDiscountings => Set<BillDiscounting>();
    }
}
