using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.DTOs;
using backend.Services;
using BCrypt.Net;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OtpService _otpService;
        private readonly JwtService _jwtService;
        private readonly EmailService _emailService;

        public AuthController(
            AppDbContext context,
            OtpService otpService,
            JwtService jwtService,
            EmailService emailService)
        {
            _context = context;
            _otpService = otpService;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        // ---------------- LOGIN ----------------
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            Console.WriteLine("========== LOGIN ATTEMPT ==========");

            // 🔴 STEP 1: LOG WHAT BACKEND RECEIVES
            Console.WriteLine($"DTO NULL        : {dto == null}");
            Console.WriteLine($"EMAIL RECEIVED  : [{dto?.Email}]");
            Console.WriteLine($"PASSWORD RECEIVED: [{dto?.Password}]");

            // 1️⃣ DTO safety check
            if (dto == null)
            {
                Console.WriteLine("LOGIN FAIL: DTO IS NULL");
                return Unauthorized("Invalid credentials");
            }

            if (string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password))
            {
                Console.WriteLine("LOGIN FAIL: EMPTY EMAIL OR PASSWORD");
                return Unauthorized("Invalid credentials");
            }

            // 2️⃣ Normalize email
            var email = dto.Email.Trim().ToLower();
            Console.WriteLine($"NORMALIZED EMAIL: [{email}]");

            // 3️⃣ Check DB connection
            var userCount = await _context.Users.CountAsync();
            Console.WriteLine($"TOTAL USERS IN DB: {userCount}");

            // 4️⃣ Fetch user
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email);

            if (user == null)
            {
                Console.WriteLine($"LOGIN FAIL: USER NOT FOUND [{email}]");
                return Unauthorized("Invalid credentials");
            }

            Console.WriteLine($"EMAIL IN DB     : [{user.Email}]");
            Console.WriteLine($"HASH IN DB      : {user.PasswordHash}");

            // 5️⃣ Verify password
            var passwordValid = BCrypt.Net.BCrypt.Verify(
                dto.Password.Trim(),
                user.PasswordHash
            );

            Console.WriteLine($"PASSWORD MATCH RESULT: {passwordValid}");

            if (!passwordValid)
            {
                Console.WriteLine("LOGIN FAIL: PASSWORD MISMATCH");
                return Unauthorized("Invalid credentials");
            }

            // 6️⃣ Generate OTP (store normalized email)
            var otp = await _otpService.GenerateOtpAsync(email);

            // 7️⃣ Send OTP
            _emailService.SendOtp(user.Email, otp.Code);

            Console.WriteLine("LOGIN SUCCESS: OTP SENT");
            Console.WriteLine("=================================");

            return Ok(new { message = "OTP sent to your email" });
        }

        // ---------------- VERIFY OTP ----------------
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            Console.WriteLine("========== OTP VERIFY ==========");

            if (dto == null ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Otp))
            {
                Console.WriteLine("OTP FAIL: INVALID REQUEST");
                return Unauthorized("Invalid or expired OTP");
            }

            var email = dto.Email.Trim().ToLower();
            Console.WriteLine($"OTP EMAIL: [{email}]");
            Console.WriteLine($"OTP CODE : [{dto.Otp}]");

            var valid = await _otpService.ValidateOtpAsync(email, dto.Otp);

            Console.WriteLine($"OTP VALID RESULT: {valid}");

            if (!valid)
                return Unauthorized("Invalid or expired OTP");

            var user = await _context.Users
                .AsNoTracking()
                .FirstAsync(u => u.Email.ToLower() == email);

            var token = _jwtService.GenerateToken(user.Email, user.Role);

            Console.WriteLine("OTP VERIFIED → JWT GENERATED");
            Console.WriteLine("==============================");

            return Ok(new { token });
        }
    }
}
