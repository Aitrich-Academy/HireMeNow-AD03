using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobProviderDTO
{
   
    public class JobSeekerSummaryDto
    {
        public Guid JobSeekerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
      //  public byte[]? Image { get; set; }
        //public string? UserName { get; set; }

        // No JobApplications collection to avoid circular references
    }
}
