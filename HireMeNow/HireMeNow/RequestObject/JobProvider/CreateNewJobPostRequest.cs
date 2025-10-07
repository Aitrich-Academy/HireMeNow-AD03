using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class CreateNewJobPostRequest
    {
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        [Required]
        public string? CompanyName { get; set; } 
        [Required]
        public JobType JobType { get; set; }

        public Guid LocationId { get; set; }

        public Guid IndustryId { get; set; }
    }
}
