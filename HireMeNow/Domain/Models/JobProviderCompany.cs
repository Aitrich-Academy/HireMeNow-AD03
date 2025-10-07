using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("JobProviderCompany")]
public partial class JobProviderCompany
{
    [Key]
    [Column("JobProviderID")]
    public Guid JobProviderId { get; set; }

    [StringLength(200)]
    public string CompanyName { get; set; } = null!;

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [ForeignKey(nameof(Location))]
    public Guid LocationId { get; set; }

    [Required]
    public Roles Role { get; set; }

    [ForeignKey(nameof(Industry))]
    public Guid IndustryId { get; set; }

    
    public Guid SystemUserId { get; set; }
    [ForeignKey(nameof(SystemUserId))]
    public virtual SystemUser? JobProviderNavigation { get; set; }


    //// 1:1 navigation back to SystemUser
    //[ForeignKey("JobProviderId")]
    //[InverseProperty(nameof(SystemUser.JobProviderCompanies))]
    //public virtual SystemUser JobProviderNavigation { get; set; } = null!;

    // 1:N CompanyUsers under this company
    [InverseProperty(nameof(CompanyUser.JobProviderNavigation))]
    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    [InverseProperty(nameof(ShortList.JobProvider))]
    public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();

    [InverseProperty(nameof(JobPost.JobProviderCompany))]
    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();


    // ✅ Navigation back to SystemUser
    //[ForeignKey("JobProviderId")]
    //[InverseProperty("JobProviderCompanies")]
    //public virtual SystemUser JobProviderNavigation { get; set; } = null!;

    //[InverseProperty("JobProviderNavigation")]
    //public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();


    //[InverseProperty("JobProvider")]   // <-- matches ShortList.JobProvider
    //public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();
}
