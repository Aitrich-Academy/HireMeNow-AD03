using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTOs
{
    public class JobSeekerInfoDTO
    {
        public string? UserName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = null!;
        [StringLength(450)]
        public string Email { get; set; } = null!;
        public Roles Role { get; set; }
        public byte[]? Image { get; set; }        
    }
}
