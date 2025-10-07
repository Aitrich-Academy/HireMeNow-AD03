using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class UpdateJobPostRequest
    {
        
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public JobType JobType { get; set; }
        public Guid CreatorID { get; set; }
        public Guid JobProviderID { get; set; }

        public Guid LocationId { get; set; }

        public Guid IndustryId { get; set; }
    }
}
