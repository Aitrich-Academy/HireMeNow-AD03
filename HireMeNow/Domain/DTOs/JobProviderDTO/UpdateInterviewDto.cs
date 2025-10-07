using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
    public class UpdateInterviewDto
    {
        public Guid InterviewId { get; set; }   // required to know which interview to update
        public DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; } = null!;
        public InterviewMode InterviewMode { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
    }
}
