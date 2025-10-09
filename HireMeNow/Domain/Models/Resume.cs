using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class Resume
{
    [Key]
    public Guid ResumeId { get; set; }
    public Guid? JobSeekerProfileId { get; set; }
    public string? ResumeTitle { get; set; }
    public byte[]? File { get; set; }

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();  
    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;
}
