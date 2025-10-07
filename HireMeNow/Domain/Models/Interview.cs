using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;
public partial class Interview
{
    [Key]
    [Column("InterviewID")]
    public Guid InterviewId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InterviewDate { get; set; }

    [StringLength(50)]
    public string? InterviewTime { get; set; }

    [Required]
    public InterviewMode InterviewMode { get; set; }

    [Required]
    public InterviewStatus InterviewStatus { get; set; }

    [Column("JobSeekerID")]
    [ForeignKey("JobSeekerId")]
    public Guid JobSeekerId { get; set; }

    [ForeignKey("ShortListId")]
    public Guid ShortListId { get; set; }

    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    // Navigation property to JobApplication
    [ForeignKey("ApplicationID")]
    public JobApplication JobApplication { get; set; }
}
