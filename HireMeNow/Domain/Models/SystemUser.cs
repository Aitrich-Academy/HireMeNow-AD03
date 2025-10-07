using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SystemUser")]
public partial class SystemUser
{
    [Key]
    [Column("SystemUserID")]
    public Guid SystemUserId { get; set; }

    public string? UserName { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Phone { get; set; } = null!;

    [StringLength(450)]
    public string Email { get; set; } = null!;

    [Required]
    public Roles Role { get; set; }
    // 1:1 relationship with JobSeeker

    [InverseProperty(nameof(JobSeeker.JobSeekerNavigation))]
    public virtual JobSeeker? JobSeeker { get; set; }

    // 1:N relationship with CompanyUser
    [InverseProperty(nameof(CompanyUser.CompanyUserNavigation))]
    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    // 1:N relationship with JobProviderCompany
    [InverseProperty(nameof(JobProviderCompany.JobProviderNavigation))]
    public virtual ICollection<JobProviderCompany> JobProviderCompanies { get; set; } = new List<JobProviderCompany>();
}
