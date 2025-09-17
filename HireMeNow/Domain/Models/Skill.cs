using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("Skill")]
public partial class Skill
{
    [Key]
    [Column("SkillID")]
    public Guid SkillId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [InverseProperty("Skill")]
    public virtual ICollection<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; } = new List<JobSeekerProfileSkill>();
}
