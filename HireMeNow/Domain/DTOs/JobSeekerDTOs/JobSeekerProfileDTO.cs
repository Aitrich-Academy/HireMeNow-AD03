using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTOs
{
    public class JobSeekerProfileDTO
    {
        public Guid JobSeekerProfileId { get; set; }
        public Guid JobSeekerId { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileSummary { get; set; }

        public List<JobSeekerProfileSkillDTO> JobSeekerProfileSkills { get; set; } = new();
        public List<QualificationDTO> Qualifications { get; set; } = new();
        public List<ResumeDTO> Resumes { get; set; } = new();
        public List<WorkExperienceDTO> WorkExperiences { get; set; } = new();
    }
}
