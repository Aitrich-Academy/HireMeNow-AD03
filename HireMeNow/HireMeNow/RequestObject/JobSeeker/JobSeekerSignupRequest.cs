using System.ComponentModel.DataAnnotations;

namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class JobSeekerSignupRequest
    {
        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = null!;
    }
}
