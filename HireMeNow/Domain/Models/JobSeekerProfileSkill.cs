using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class JobSeekerProfileSkill
{
    public Guid JobSeekerProfileId { get; set; }
    public JobSeekerProfile JobSeekerProfile { get; set; }
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; }
}
