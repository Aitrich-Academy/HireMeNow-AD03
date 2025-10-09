namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class ApplyJobRequestDTO
    {
        public Guid JobPost_id { get; set; }
        public Guid Applicant { get; set; }
        public Guid Resume_id { get; set; }
        public string CoverLetter { get; set; }
    }
}
