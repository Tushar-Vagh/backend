using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class OtpService
    {
        private readonly AppDbContext _context;

        public OtpService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Otp> GenerateOtpAsync(string email)
        {
            var normalizedEmail = email.Trim().ToLower();

            var otp = new Otp
            {
                Email = normalizedEmail,
                Code = new Random().Next(100000, 999999).ToString(),
                Expiry = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            _context.Otps.Add(otp);
            await _context.SaveChangesAsync();

            return otp;
        }

        public async Task<bool> ValidateOtpAsync(string email, string code)
        {
            var otp = _context.Otps
                .Where(x => x.Email == email && !x.IsUsed)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();

            if (otp == null) return false;
            if (otp.Expiry < DateTime.UtcNow) return false;
            if (otp.Code != code) return false;

            otp.IsUsed = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
