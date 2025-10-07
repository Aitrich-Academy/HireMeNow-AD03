namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class ApplyJobRequest
    {
        public Guid JobPostId { get; set; }
        //public Guid JobSeekerId { get; set; }
        public Guid ResumeId { get; set; }
        public string CoverLetter { get; set; } = string.Empty;
        
    }
}
