using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class ShortList
{
    [Key]
    [Column("ShortListID")]
    public Guid ShortListId { get; set; }

    [Column("ApplicationID")]
    [ForeignKey(nameof(JobApplication))]
    public Guid ApplicationId { get; set; }

    [Column("JobSeekerID")]
    [ForeignKey(nameof(JobSeeker))]
    public Guid JobSeekerId { get; set; }

    [Column("CompanyUserID")]
    [ForeignKey(nameof(CompanyUser))]
    public Guid CompanyUserId { get; set; }

    [Column("JobProviderID")]
    [ForeignKey(nameof(JobProviderCompany))]
    public Guid JobProviderId { get; set; }

    [StringLength(50)]
    public ShortListStatus ShortListStatus { get; set; }

    [ForeignKey("CompanyUserId")]
    [InverseProperty("ShortLists")]   // <-- matches CompanyUser.ShortLists
    public virtual CompanyUser CompanyUser { get; set; } = null!;

    [ForeignKey("JobProviderId")]
    [InverseProperty("ShortLists")]   // <-- matches JobProviderCompany.ShortLists
    public virtual JobProviderCompany JobProvider { get; set; } = null!;
}
