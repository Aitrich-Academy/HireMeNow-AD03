using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;
public partial class JobApplication
{
    [Key]
    [Column("JobApplicationID")]
    public Guid JobApplicationId { get; set; }

    public Guid JobSeekerId { get; set; }

    public Guid JobPostId { get; set; }

    public Guid ResumeId { get; set; }

    public string CoverLetter { get; set; } = null!;

    public DateTime AppliedDate { get; set; }

    public ApplicationStatus ApplicationStatus { get; set; }

    [ForeignKey("JobPostId")]
    [InverseProperty(nameof(JobPost.JobApplications))]   // ✅ point to JobPost.JobApplications
    public virtual JobPost JobPost { get; set; } = null!;

    [ForeignKey("JobSeekerId")]
    [InverseProperty(nameof(JobSeeker.JobApplications))]
    public virtual JobSeeker JobSeeker { get; set; } = null!;

    [ForeignKey("ResumeId")]
    [InverseProperty("JobApplications")]
    public virtual Resume Resume { get; set; } = null!;
}
