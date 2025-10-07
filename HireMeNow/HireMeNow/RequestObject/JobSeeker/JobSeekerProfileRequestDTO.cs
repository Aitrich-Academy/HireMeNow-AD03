namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class JobSeekerProfileRequestDTO
    {
        public Guid JobSeekerId { get; set; }
        public Guid JobSeekerProfileId { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileSummary { get; set; }
    }
}
