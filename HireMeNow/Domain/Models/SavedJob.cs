using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class SavedJob
{
    [Key]
    [Column("SavedJobID")]
    public Guid SavedJobId { get; set; }

    [Column("JobSeekerID")]
    public Guid JobSeekerId { get; set; }

    public Guid JobPostId { get; set; }

    public DateTime SavedDate { get; set; }

    [ForeignKey("JobPostId")]
    [InverseProperty(nameof(JobPost.SavedJobs))]   // ✅ match JobPost.SavedJobs
    public virtual JobPost JobPost { get; set; } = null!;

    [ForeignKey("JobSeekerId")]
    [InverseProperty("SavedJobs")]
    public virtual JobSeeker JobSeeker { get; set; } = null!;
}
