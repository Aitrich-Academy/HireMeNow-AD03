using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
   
    public class JobPostSummaryDto
    {
        public Guid JobPostId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        public JobType JobType { get; set; }
        public DateTime PostedDate { get; set; }
       // public string CompanyName { get; set; } = null!;

        // No JobApplications collection to avoid circular references
        // No navigation properties that could cause cycles
    }
}
