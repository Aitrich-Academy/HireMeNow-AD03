using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("WorkExperience")]
public partial class WorkExperience
{
    [Key]
    [Column("WorkExperienceID")]
    public Guid WorkExperienceId { get; set; }

    [Column("JobSeekerProfileID")]
    public Guid JobSeekerProfileId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public DateTime ServiceStart { get; set; }

    public DateTime ServiceEnd { get; set; }

    [ForeignKey("JobSeekerProfileId")]
    [InverseProperty("WorkExperiences")]
    public virtual JobSeekerProfile JobSeekerProfile { get; set; } = null!;
}
