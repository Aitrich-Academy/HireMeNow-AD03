using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class CreateJobProviderCompanyRequest
    {
        [Required]
        public string CompanyName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public Guid IndustryId { get; set; }
    }
}
