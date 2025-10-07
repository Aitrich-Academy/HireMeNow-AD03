using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class CompanyUser
{
    [Key]
    [Column("CompanyUserID")]
    public Guid CompanyUserId { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? CompanyUserRole { get; set; }

    [StringLength(200)]
    public string? CompanyName { get; set; }

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    [Required]
    public Roles Role { get; set; }

    [Column("JobProviderID")]
    public Guid JobProviderId { get; set; }

    [Column("SystemUserID")]
    public Guid SystemUserId { get; set; }
    // 🔹 Navigation to SystemUser
    [ForeignKey(nameof(SystemUserId))]
    [InverseProperty(nameof(SystemUser.CompanyUsers))]
    public virtual SystemUser CompanyUserNavigation { get; set; } = null!;
    // 🔹 Navigation to JobProviderCompany
    [ForeignKey(nameof(JobProviderId))]
    [InverseProperty(nameof(JobProviderCompany.CompanyUsers))]
    public virtual JobProviderCompany JobProviderNavigation { get; set; } = null!;
    // 🔹 One-to-many: ShortLists
    [InverseProperty(nameof(ShortList.CompanyUser))]
    public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();
    // 🔹 One-to-many: JobPosts posted by this company user
    [InverseProperty(nameof(JobPost.PostedByUser))]
    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();


    //[ForeignKey("SystemUserId")]
    //[InverseProperty("CompanyUsers")]
    //public virtual SystemUser CompanyUserNavigation { get; set; } = null!;

    //[ForeignKey("JobProviderId")]
    //[InverseProperty("CompanyUsers")]
    //public virtual JobProviderCompany JobProviderNavigation { get; set; } = null!;

    //[InverseProperty("CompanyUser")]   // <-- matches ShortList.CompanyUser
    //public virtual ICollection<ShortList> ShortLists { get; set; } = new List<ShortList>();

    //public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
