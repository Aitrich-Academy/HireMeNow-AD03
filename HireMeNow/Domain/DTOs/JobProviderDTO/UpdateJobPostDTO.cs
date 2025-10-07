using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobProviderDTO
{
    public class UpdateJobPostDTO
    {
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public JobType JobType { get; set; }

        public Guid CreatorID { get; set; }
        public Guid JobProviderID { get; set; }

        public Guid LocationId { get; set; }

        public Guid IndustryId { get; set; }
    }
}
