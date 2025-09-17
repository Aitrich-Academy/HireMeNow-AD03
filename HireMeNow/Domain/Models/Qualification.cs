using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("Qualification")]
public partial class Qualification
{
    [Key]
    [Column("QualificationID")]
    public Guid QualificationId { get; set; }

    public Guid? JobseekerProfileId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [ForeignKey("JobseekerProfileId")]
    [InverseProperty("Qualifications")]
    public virtual JobSeekerProfile? JobseekerProfile { get; set; }
}
