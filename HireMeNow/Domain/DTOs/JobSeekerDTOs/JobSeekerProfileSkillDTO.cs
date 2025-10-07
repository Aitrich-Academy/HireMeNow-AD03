using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.JobSeekerDTOs
{
    public class JobSeekerProfileSkillDTO
    {
        public Guid JobSeekerProfileId { get; set; }
        public Guid SkillId { get; set; }
        public SkillDTO Skill { get; set; } = new();
    }
}
