using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobProviderDTO
{
    public class UpdateCompanyUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }

        public string? CompanyUserRole { get; set; }
        public string? CompanyName { get; set; }

        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
