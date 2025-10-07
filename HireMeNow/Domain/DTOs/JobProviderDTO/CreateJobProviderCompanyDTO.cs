using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobProviderDTO
{
    public class CreateJobProviderCompanyDTO
    {
        [Required]
        public string CompanyName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public Guid IndustryId { get; set; }
    }
}
