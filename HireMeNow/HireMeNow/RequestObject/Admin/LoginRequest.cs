using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace HireMeNowAD03.RequestObject.Admin
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
       // [Required]
       // public Roles Role { get; set; } // JobSeeker, JobProvider, etc.
    }
}
