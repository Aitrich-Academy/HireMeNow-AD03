using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTO
{
    public class SavedJobDto
    {
        public Guid SavedJobId { get; set; }
        public Guid JobSeekerId { get; set; }
        public Guid JobPostId { get; set; }
        public DateTime SavedDate { get; set; }

       // public string JobTitle { get; set; }
       // public string CompanyName { get; set; }
    }
}
