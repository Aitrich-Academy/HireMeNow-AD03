using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTO
{
    public class JobPostDto
    {
        public Guid JobPostId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
       // public string CompanyName { get; set; } = null!;
        public DateTime PostedDate { get; set; }
    }
}
