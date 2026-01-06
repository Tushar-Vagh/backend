using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace backend.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendOtp(string toEmail, string otp)
        {
            try
            {
                var emailConfig = _config.GetSection("EmailSettings");

                var message = new MailMessage
                {
                    From = new MailAddress(
                        emailConfig["SenderEmail"]!,
                        "TradeFlow Security"
                    ),
                    Subject = "Your Login OTP",
                    Body = $"<h2>{otp}</h2><p>This OTP is valid for 5 minutes.</p>",
                    IsBodyHtml = true
                };

                message.To.Add(toEmail);

                var client = new SmtpClient(emailConfig["SmtpServer"]!)
                {
                    Port = int.Parse(emailConfig["Port"]!),
                    Credentials = new NetworkCredential(
                        emailConfig["Username"],
                        emailConfig["Password"]
                    ),
                    EnableSsl = true
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ EMAIL SEND FAILED");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
