using System.Text.Json.Serialization;

namespace backend.DTOs
{
    public class VerifyOtpDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("otp")]
        public string Otp { get; set; } = string.Empty;
    }
}
