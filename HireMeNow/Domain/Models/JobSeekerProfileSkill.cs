using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("JobSeekerProfileSkill")]
public partial class JobSeekerProfileSkill
{
    [Key]
    [Column("JobSeekerProfileSkillID")]
    public Guid JobSeekerProfileSkillId { get; set; }

    [Column("JobSeekerProfileID")]
    public Guid JobSeekerProfileId { get; set; }

    public Guid SkillId { get; set; }

    [ForeignKey("JobSeekerProfileId")]
    [InverseProperty("JobSeekerProfileSkills")]
    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    [ForeignKey("SkillId")]
    [InverseProperty("JobSeekerProfileSkills")]
    public virtual Skill Skill { get; set; } = null!;
}
