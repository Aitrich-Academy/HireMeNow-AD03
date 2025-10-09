using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobSeekerDTO
{
    public class JobSearchResultDto
    {
        public Guid JobPostId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        public JobType JobType { get; set; }
        public DateTime PostedDate { get; set; }
      //  public string CompanyName { get; set; } = null!;
       // public string PostedByName { get; set; } = null!;
    }
}
