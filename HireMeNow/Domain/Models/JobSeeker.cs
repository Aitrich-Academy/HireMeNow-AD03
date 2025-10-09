using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class JobSeeker
{
    [Key]
    [Column("JobSeekerID")]
    public Guid JobSeekerId { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    [StringLength(450)]
    public string Email { get; set; } = null!;

    public Roles Role { get; set; }

    public byte[]? Image { get; set; }

    [InverseProperty(nameof(JobApplication.JobSeeker))]
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    [ForeignKey("JobSeekerId")]
    [InverseProperty(nameof(SystemUser.JobSeeker))]
    public virtual SystemUser JobSeekerNavigation { get; set; } = null!;

    [InverseProperty(nameof(JobSeekerProfile.JobSeeker))]
    public virtual ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();

    [InverseProperty(nameof(SavedJob.JobSeeker))]
    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
    // 🔗 Navigation to ShortLists
    [InverseProperty(nameof(ShortList.JobSeeker))]
    public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();
}
