using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
    public class InterviewResponseDto
    {
        public Guid InterviewId { get; set; }
        public DateTime InterviewDate { get; set; }
        public string? InterviewTime { get; set; }
        public InterviewMode InterviewMode { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
    }
}
