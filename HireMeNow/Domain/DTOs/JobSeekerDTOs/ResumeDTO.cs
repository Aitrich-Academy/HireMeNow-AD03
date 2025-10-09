using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTOs
{
    public class ResumeDTO
    {
        public Guid ResumeId { get; set; }
        public string? ResumeTitle { get; set; }
        public byte[]? File { get; set; }
    }
}
