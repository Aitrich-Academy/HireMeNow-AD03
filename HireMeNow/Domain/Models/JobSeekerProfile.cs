using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("JobSeekerProfile")]
public partial class JobSeekerProfile
{
    [Key]
    [Column("JobSeekerProfileID")]
    public Guid JobSeekerProfileId { get; set; }

    public Guid JobSeekerId { get; set; }

    [Column("ResumeID")]
    public Guid ResumeId { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    [ForeignKey("JobSeekerId")]
    [InverseProperty("JobSeekerProfiles")]
    public virtual JobSeeker JobSeeker { get; set; } = null!;

    [InverseProperty("JobSeekerProfile")]
    public virtual ICollection<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; } = new List<JobSeekerProfileSkill>();

    [InverseProperty("JobseekerProfile")]
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    [ForeignKey("ResumeId")]
    [InverseProperty("JobSeekerProfiles")]
    public virtual Resume Resume { get; set; } = null!;

    [InverseProperty("JobSeekerProfile")]
    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}
