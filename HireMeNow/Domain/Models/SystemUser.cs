using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [InverseProperty("JobSeekerNavigation")]
    public virtual JobSeeker? JobSeeker { get; set; }

    [InverseProperty("CompanyUserNavigation")]
    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    [InverseProperty("JobProviderNavigation")]
    public virtual ICollection<JobProviderCompany> JobProviderCompanies { get; set; } = new List<JobProviderCompany>();
}
