using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("ShortList")]
public partial class ShortList
{
    [Key]
    [Column("ShortListID")]
    public Guid ShortListId { get; set; }

    // 🔹 Foreign key to JobApplication
    [Column("ApplicationID")]
    public Guid ApplicationId { get; set; }

    [ForeignKey(nameof(ApplicationId))]
    [InverseProperty(nameof(JobApplication.ShortListStatus))]
    public virtual JobApplication JobApplication { get; set; } = null!;

    // 🔹 Foreign key to JobSeeker
    [Column("JobSeekerID")]
    public Guid JobSeekerId { get; set; }

    [ForeignKey(nameof(JobSeekerId))]
    [InverseProperty(nameof(JobSeeker.ShortLists))]
    public virtual JobSeeker JobSeeker { get; set; } = null!;

    // 🔹 Foreign key to CompanyUser
    [Column("CompanyUserID")]
    public Guid CompanyUserId { get; set; }

    [ForeignKey(nameof(CompanyUserId))]
    [InverseProperty(nameof(CompanyUser.ShortLists))]
    public virtual CompanyUser CompanyUser { get; set; } = null!;

    // 🔹 Foreign key to JobProviderCompany
    [Column("JobProviderID")]
    public Guid JobProviderId { get; set; }

    [ForeignKey(nameof(JobProviderId))]
    [InverseProperty(nameof(JobProviderCompany.ShortLists))]
    public virtual JobProviderCompany JobProvider { get; set; } = null!;

    // 🔹 Status of the shortlist
    [Required]
    public ShortListStatus ShortListStatus { get; set; }

    //[Column("ApplicationID")]
    //[ForeignKey(nameof(JobApplication))]
    //public Guid ApplicationId { get; set; }

    //[Column("JobSeekerID")]
    //[ForeignKey(nameof(JobSeeker))]
    //public Guid JobSeekerId { get; set; }

    //[Column("CompanyUserID")]
    //[ForeignKey(nameof(CompanyUser))]
    //public Guid CompanyUserId { get; set; }

    //[Column("JobProviderID")]
    //[ForeignKey(nameof(JobProviderCompany))]
    //public Guid JobProviderId { get; set; }

    //[StringLength(50)]
    //public ShortListStatus ShortListStatus { get; set; }

    //[ForeignKey("CompanyUserId")]
    //[InverseProperty("ShortLists")]   // <-- matches CompanyUser.ShortLists
    //public virtual CompanyUser CompanyUser { get; set; } = null!;

    //[ForeignKey("JobProviderId")]
    //[InverseProperty("ShortLists")]   // <-- matches JobProviderCompany.ShortLists
    //public virtual JobProviderCompany JobProvider { get; set; } = null!;
}
