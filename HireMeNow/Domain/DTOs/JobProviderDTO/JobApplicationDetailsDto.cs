using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobSeekerDTO;
using Domain.Enums;
using Domain.Models;

namespace Domain.DTOs.JobProviderDTO
{
    public class JobApplicationDetailsDto
    {
        public Guid JobApplicationId { get; set; }
        public ApplicantDto JobSeeker { get; set; }  
        public JobPostDto JobPost { get; set; }       
      // public DateTime AppliedOn { get; set; }
    }
}
