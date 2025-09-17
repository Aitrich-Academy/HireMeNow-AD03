using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("Resume")]
public partial class Resume
{
    [Key]
    [Column("ResumeID")]
    public Guid ResumeId { get; set; }

    public string? ResumeTitle { get; set; }

    public byte[]? File { get; set; }

    [InverseProperty("Resume")]
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    [InverseProperty("Resume")]
    public virtual ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();
}
