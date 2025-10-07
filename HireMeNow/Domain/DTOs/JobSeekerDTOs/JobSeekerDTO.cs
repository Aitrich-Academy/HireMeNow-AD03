using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTOs
{
    public class JobSeekerDTO
    {
        public string? UserName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = null!;
        [StringLength(450)]
        public string Email { get; set; } = null!;
        public Roles Role { get; set; }
        public byte[]? Image { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileSummary { get; set; }
        public List<QualificationDTO> Qualification { get; set; } = new List<QualificationDTO>();
        public List<SkillDTO> JobSeekerProfileSkill { get; set; }= new List<SkillDTO>();
        public List<WorkExperienceDTO> WorkExperience { get; set; }= new List<WorkExperienceDTO>();
    }
}
