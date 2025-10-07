using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;
public partial class JobSeekerProfile
{
    [Key]
    public Guid JobSeekerProfileId { get; set; }
    public Guid JobSeekerId { get; set; }
    public string? ProfileName { get; set; }
    public string? ProfileSummary { get; set; }
    public List<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }

    public virtual JobSeeker JobSeeker { get; set; } = null!;
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}
