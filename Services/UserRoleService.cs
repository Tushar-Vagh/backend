using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public class UserRoleService
    {
        private readonly List<SystemUser> _users = new();

        private readonly List<object> _roles = new()
        {
            new { name = "Admin", description = "System administrator" },
            new { name = "Compliance", description = "AML & sanctions" },
            new { name = "Trade Officer", description = "Trade processing" }
        };

        public List<SystemUser> GetUsers() => _users;

        public SystemUser AddUser(CreateUserDto dto)
        {
            var user = new SystemUser
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role,
                Branch = dto.Branch
            };

            _users.Add(user);
            return user;
        }

        public List<object> GetRoles() => _roles;
    }
}
