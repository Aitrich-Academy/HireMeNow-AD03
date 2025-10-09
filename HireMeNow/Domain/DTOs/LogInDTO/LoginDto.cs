using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.LogInDTO
{
    public class LoginDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public Roles Role { get; set; }
        public string? Token { get; set; }
    }
}
