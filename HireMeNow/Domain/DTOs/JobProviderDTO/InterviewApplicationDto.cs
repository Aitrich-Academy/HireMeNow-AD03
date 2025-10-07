using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
    public class InterviewApplicationDto
    {
        public Guid JobApplicationId { get; set; }
        public string CoverLetter { get; set; } = string.Empty;
        public DateTime AppliedDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        public JobSeekerSummaryDto JobSeeker { get; set; } = null!;
        public JobPostSummaryDto JobPost { get; set; } = null!;
    }
}
