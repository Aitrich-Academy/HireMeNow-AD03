using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
    public class CreateInterviewDto
    {
        public DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; } = null!;
        public InterviewMode InterviewMode { get; set; }
        public InterviewStatus InterviewStatus { get; set; }

        public Guid JobSeekerId { get; set; }
        public Guid ShortListId { get; set; }
        public Guid ApplicationId { get; set; }   // Link to JobApplication
    }
}
