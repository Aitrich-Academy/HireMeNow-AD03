using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("JobPost")]
public partial class JobPost
{
    [Key]
    [Column("JobPostID")]
    public Guid JobPostId { get; set; }

    [StringLength(10)]
    public string JobTitle { get; set; } = null!;

    [StringLength(250)]
    public string JobSummary { get; set; } = null!;

    [Required]
    public JobType JobType { get; set; }

    [ForeignKey(nameof(Location))]
    public Guid LocationId { get; set; }

    public Guid Company { get; set; }

    [ForeignKey(nameof(Industry))]
    public Guid IndustryId { get; set; }

    [ForeignKey(nameof(CompanyUser))]
    public Guid PostedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PostedDate { get; set; }

    [InverseProperty(nameof(JobApplication.JobPost))]   // ✅ point to JobApplication.JobPost
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    [InverseProperty(nameof(SavedJob.JobPost))]   // ✅ match SavedJob.JobPost
    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
}
