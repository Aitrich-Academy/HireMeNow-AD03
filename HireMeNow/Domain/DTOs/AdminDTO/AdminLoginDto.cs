using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AdminDTO
{
    public class AdminLoginDto
    {
        public string Email { get; set; }
        public string? Token { get; set; }
    }
}
