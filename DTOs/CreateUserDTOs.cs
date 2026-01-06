namespace AuthAPI.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public string Branch { get; set; } = "";
    }
}
