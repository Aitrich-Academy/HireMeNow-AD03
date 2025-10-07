using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    // ✅ Navigation back to SystemUser
    [ForeignKey("JobProviderId")]
    [InverseProperty("JobProviderCompanies")]
    public virtual SystemUser JobProviderNavigation { get; set; } = null!;

    [InverseProperty("JobProviderNavigation")]
    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();


    [InverseProperty("JobProvider")]   // <-- matches ShortList.JobProvider
    public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();
}
