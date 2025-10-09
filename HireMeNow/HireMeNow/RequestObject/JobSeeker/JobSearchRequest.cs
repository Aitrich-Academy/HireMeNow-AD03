using Domain.Enums;

namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class JobSearchRequest
    {
        public Guid? LocationId { get; set; } // Optional filter by location
        public string? JobTitle { get; set; } // Optional filter by job title
        public JobType? JobType { get; set; } // Optional filter by job type
    }
}
