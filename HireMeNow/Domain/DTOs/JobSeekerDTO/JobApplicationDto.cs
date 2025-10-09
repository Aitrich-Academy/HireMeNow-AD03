using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobSeekerDTO
{
    public class JobApplicationDto
    {
        //public Guid JobSeekerId { get; set; }
        //public Guid JobPostId { get; set; }
        //public Guid ResumeId { get; set; }
        //public string CoverLetter { get; set; } = string.Empty;
        public Guid JobApplicationId { get; set; }
        public Guid JobPostId { get; set; }
        public Guid JobSeekerId { get; set; }
        public Guid ResumeId { get; set; }
        public string CoverLetter { get; set; } = null!;
        public DateTime AppliedDate { get; set; }= DateTime.Now;
        public string ApplicationStatus { get; set; } = "Pending";



    }
       
       
}
